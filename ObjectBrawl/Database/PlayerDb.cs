using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using ObjectBrawl.Helpers;
using ObjectBrawl.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ObjectBrawl.Database
{
    public class PlayerDb
    {
        private const string Name = "player";
        private static string _connectionString;
        private static int _playerSeed;

        public PlayerDb()
        {
            _connectionString = new MySqlConnectionStringBuilder
            {
                Server = "127.0.0.1",
                Database = "objectbrawl",
                UserID = "root",
                Password = "",
                SslMode = MySqlSslMode.None,
                MinimumPoolSize = 4,
                MaximumPoolSize = 20,
                CharacterSet = "utf8mb4"
            }.ToString();

            _playerSeed = MaxPlayerId();

            if (_playerSeed > -1) return;

            Console.WriteLine("Unable to connect to MySql!");
            Environment.Exit(-1);
        }

        public static async Task ExecuteAsync(MySqlCommand cmd)
        {
            #region Execute

            try
            {
                cmd.Connection = new MySqlConnection(_connectionString);
                await cmd.Connection.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
            catch (MySqlException exception)
            {
            }
            finally
            {
                cmd.Connection?.Close();
            }

            #endregion
        }

        public static int MaxPlayerId()
        {
            #region MaxId

            try
            {
                int seed;

                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    using (var cmd = new MySqlCommand($"SELECT coalesce(MAX(Id), 0) FROM {Name}", connection))
                    {
                        seed = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    connection.Close();
                }

                return seed;
            }
            catch (Exception exception)
            {
                return -1;
            }

            #endregion
        }

        public static async Task<long> CountAsync()
        {
            #region Count

            try
            {
                long seed;

                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var cmd = new MySqlCommand($"SELECT COUNT(*) FROM {Name}", connection))
                    {
                        seed = Convert.ToInt64(await cmd.ExecuteScalarAsync());
                    }

                    await connection.CloseAsync();
                }

                return seed;
            }
            catch (Exception exception)
            {
                return 0;
            }

            #endregion
        }

        public static async Task<Player> CreateAsync()
        {
            #region Create

            try
            {
                var id = _playerSeed++;
                if (id <= -1)
                    return null;

                var player = new Player(id + 1);

                player.UserToken = Utils.GenerateToken();

                using (var cmd =
                    new MySqlCommand(
                        $"INSERT INTO {Name} (`Id`, `Score`, `Avatar`) VALUES ({id + 1}, {player.Score}, @avatar)")
                )
                {
#pragma warning disable 618
                    cmd.Parameters?.AddWithValue("@avatar",
                        JsonConvert.SerializeObject(player, ServerCore.JsonSettings));
#pragma warning restore 618

                    await ExecuteAsync(cmd);
                }

                return player;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                return null;
            }

            #endregion
        }

        public static async Task<Player> GetAsync(int id)
        {
            #region Get

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    Player player = null;

                    using (var cmd = new MySqlCommand($"SELECT * FROM {Name} WHERE Id = '{id}'", connection))
                    {
                        var reader = await cmd.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                        {
                            player = JsonConvert.DeserializeObject<Player>((string)reader["Avatar"],
                                    ServerCore.JsonSettings);
                            break;
                        }
                    }

                    await connection.CloseAsync();

                    return player;
                }
            }
            catch (Exception exception)
            {
                return null;
            }

            #endregion
        }

        public static async Task SaveAsync(Player player)
        {
            #region Save

            try
            {
                using (var cmd =
                    new MySqlCommand(
                        $"UPDATE {Name} SET `Score`='{player.Score}', `Avatar`=@avatar WHERE Id = '{player.LowID}'")
                )
                {
#pragma warning disable 618
                    cmd.Parameters?.AddWithValue("@avatar",
                        JsonConvert.SerializeObject(player, ServerCore.JsonSettings));
#pragma warning restore 618

                    await ExecuteAsync(cmd);
                }
            }
            catch (Exception exception)
            {
            }

            #endregion
        }

        public static async Task<List<Player>> GetGlobalPlayerRankingAsync()
        {
            #region GetGlobal

            var list = new List<Player>();

            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    using (var cmd = new MySqlCommand($"SELECT * FROM {Name} ORDER BY `Score` DESC LIMIT 200",
                        connection))
                    {
                        var reader = await cmd.ExecuteReaderAsync();
                        Player player = null;
                        while (await reader.ReadAsync())
                            list.Add(player = JsonConvert.DeserializeObject<Player>((string)reader["Avatar"],
                                    ServerCore.JsonSettings));
                    }

                    await connection.CloseAsync();
                }

                return list;
            }
            catch (Exception exception)
            {
                return list;
            }

            #endregion
        }
    }
}
