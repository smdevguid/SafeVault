using Microsoft.Data.SqlClient;

namespace SafeVault.Data
{
    public class UserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<string?> GetUserAsync(string username)
        {
            using SqlConnection conn =
                new SqlConnection(_connectionString);

            string query =
                "SELECT Username FROM Users WHERE Username = @Username";

            using SqlCommand cmd =
                new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue(
                "@Username",
                username
            );

            await conn.OpenAsync();

            var result = await cmd.ExecuteScalarAsync();

            return result?.ToString();
        }
    }
}