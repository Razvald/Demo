namespace Demo
{
    partial class CatalogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            comboBoxCategory = new ComboBox();
            dataGridViewProducts = new DataGridView();
            lblPage = new Label();
            btnNextPage = new Button();
            btnPreviousPage = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            SuspendLayout();
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(12, 12);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(121, 23);
            comboBoxCategory.TabIndex = 0;
            comboBoxCategory.SelectedIndexChanged += comboBoxCategory_SelectedIndexChanged;
            // 
            // dataGridViewProducts
            // 
            dataGridViewProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProducts.Location = new Point(12, 41);
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.Size = new Size(598, 397);
            dataGridViewProducts.TabIndex = 1;
            // 
            // lblPage
            // 
            lblPage.AutoSize = true;
            lblPage.Location = new Point(139, 15);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(38, 15);
            lblPage.TabIndex = 2;
            lblPage.Text = "label1";
            // 
            // btnNextPage
            // 
            btnNextPage.Location = new Point(535, 11);
            btnNextPage.Name = "btnNextPage";
            btnNextPage.Size = new Size(75, 23);
            btnNextPage.TabIndex = 3;
            btnNextPage.Text = "button1";
            btnNextPage.UseVisualStyleBackColor = true;
            btnNextPage.Click += btnNextPage_Click;
            // 
            // btnPreviousPage
            // 
            btnPreviousPage.Location = new Point(454, 11);
            btnPreviousPage.Name = "btnPreviousPage";
            btnPreviousPage.Size = new Size(75, 23);
            btnPreviousPage.TabIndex = 4;
            btnPreviousPage.Text = "button2";
            btnPreviousPage.UseVisualStyleBackColor = true;
            btnPreviousPage.Click += btnPreviousPage_Click;
            // 
            // CatalogForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(622, 450);
            Controls.Add(btnPreviousPage);
            Controls.Add(btnNextPage);
            Controls.Add(lblPage);
            Controls.Add(dataGridViewProducts);
            Controls.Add(comboBoxCategory);
            Name = "CatalogForm";
            Text = "CatalogForm";
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxCategory;
        private DataGridView dataGridViewProducts;
        private Label lblPage;
        private Button btnNextPage;
        private Button btnPreviousPage;
    }
}