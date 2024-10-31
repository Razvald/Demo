namespace Demo
{
    public partial class Form1 : Form
    {
        private readonly Database database = new();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            bool isAuthenticated = database.AuthenticateUser(login, password);

            if (isAuthenticated)
            {
                MessageBox.Show("Вход выполнен успешно!");
                CatalogForm catalogForm = new();
                catalogForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль. Повторите попытку.");
            }
        }
    }
}
