using System.Data;
using System.Data.SqlClient;

namespace Demo
{
    public partial class CatalogForm : Form
    {
        private Database database = new();
        private int currentPage = 1;
        private int pageSize = 25;

        public CatalogForm()
        {
            InitializeComponent();
            LoadCategories();
            LoadProducts();
        }

        // Загрузка категорий в ComboBox для фильтрации
        private void LoadCategories()
        {
            DataTable categories = database.GetCategories();

            // Добавляем опцию "Все категории" вручную
            DataRow allCategoriesRow = categories.NewRow();
            allCategoriesRow["Категория"] = "Все категории";
            categories.Rows.InsertAt(allCategoriesRow, 0);

            comboBoxCategory.DataSource = categories;
            comboBoxCategory.DisplayMember = "Категория";
            comboBoxCategory.ValueMember = "Категория";
            comboBoxCategory.SelectedIndex = 0; // Установим "Все категории" по умолчанию
        }

        // Загрузка товаров с учетом фильтра и постраничного вывода
        private void LoadProducts(string category = null)
        {
            if (category == "Все категории")
            {
                category = null;
            }

            DataTable products = database.GetProducts(category, pageSize, currentPage);
            dataGridViewProducts.DataSource = products;

            // Проверяем, есть ли еще товары на следующей странице
            DataTable nextPageProducts = database.GetProducts(category, pageSize, currentPage + 1);
            btnNextPage.Enabled = nextPageProducts.Rows.Count > 0;

            // Обновляем отображение текущей страницы
            UpdatePageLabel();

            // Отключаем кнопку "Предыдущая страница", если мы на первой странице
            btnPreviousPage.Enabled = currentPage > 1;
        }

        // Обновление информации о текущей странице
        private void UpdatePageLabel()
        {
            lblPage.Text = $"Страница {currentPage}";
        }

        // Обработчик для ComboBox фильтрации по категории
        private void comboBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentPage = 1;
            string selectedCategory = comboBoxCategory.SelectedValue?.ToString();
            LoadProducts(selectedCategory);
        }

        // Обработчик для кнопки "Следующая страница"
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            currentPage++;
            LoadProducts(comboBoxCategory.SelectedValue?.ToString());
        }

        // Обработчик для кнопки "Предыдущая страница"
        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadProducts(comboBoxCategory.SelectedValue?.ToString());
            }
        }
    }
}
