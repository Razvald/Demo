using System.Data;
using System.Data.SqlClient;

namespace Demo
{
    public class Database
    {
        private readonly string connectionString = @"Database=(local);Initial Catalog=demo;Integrated Security=True";

        public DataTable GetCategories()
        {
            using SqlConnection connection = new(connectionString);
            string query = "SELECT DISTINCT Категория FROM Товар";
            SqlDataAdapter adapter = new(query, connection);
            DataTable categories = new();
            adapter.Fill(categories);
            return categories;
        }

        public bool AuthenticateUser(string login, string password)
        {
            using SqlConnection connection = new(connectionString);
            try
            {
                connection.Open();
                
                string query = "SELECT COUNT(1) FROM Клиент WHERE Логин = @Login AND Пароль = @Password";
                
                SqlCommand cmd = new(query, connection);

                cmd.Parameters.AddWithValue("@Login", login);
                cmd.Parameters.AddWithValue("@Password", password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                
                return count == 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        // Метод для получения списка товаров с постраничным выводом и фильтрацией по категории
        public DataTable GetProducts(string category, int pageSize, int pageNumber)
        {
            using SqlConnection connection = new(connectionString);
            connection.Open();

            string query = "SELECT * FROM Товар";
            if (!string.IsNullOrEmpty(category))
            {
                query += " WHERE Категория = @Category";
            }
            query += " ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";

            SqlCommand cmd = new(query, connection);
            cmd.Parameters.AddWithValue("@PageSize", pageSize);
            cmd.Parameters.AddWithValue("@Offset", (pageNumber - 1) * pageSize);
            if (!string.IsNullOrEmpty(category))
            {
                cmd.Parameters.AddWithValue("@Category", category);
            }

            SqlDataAdapter adapter = new(cmd);
            DataTable products = new();
            adapter.Fill(products);
            return products;
        }
    }
}
