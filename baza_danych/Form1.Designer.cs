namespace baza_danych
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.Button buttonFilterAlcoholic;
        private System.Windows.Forms.ListBox listBoxCocktails;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.CheckBox checkBoxAlcoholic;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textBoxNewCategory;
        private System.Windows.Forms.Button buttonAddCategory;




        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            buttonLoad = new Button();
            buttonSort = new Button();
            buttonFilterAlcoholic = new Button();
            listBoxCocktails = new ListBox();
            textBoxName = new TextBox();
            checkBoxAlcoholic = new CheckBox();
            comboBoxCategory = new ComboBox();
            buttonAdd = new Button();
            buttonDelete = new Button();
            textBoxNewCategory = new TextBox();
            buttonAddCategory = new Button();
            SuspendLayout();
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(12, 12);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(180, 30);
            buttonLoad.TabIndex = 0;
            buttonLoad.Text = "Load data";
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonSort
            // 
            buttonSort.Location = new Point(200, 12);
            buttonSort.Name = "buttonSort";
            buttonSort.Size = new Size(180, 30);
            buttonSort.TabIndex = 1;
            buttonSort.Text = "Sort";
            buttonSort.Click += buttonSort_Click;
            // 
            // buttonFilterAlcoholic
            // 
            buttonFilterAlcoholic.Location = new Point(388, 12);
            buttonFilterAlcoholic.Name = "buttonFilterAlcoholic";
            buttonFilterAlcoholic.Size = new Size(180, 30);
            buttonFilterAlcoholic.TabIndex = 2;
            buttonFilterAlcoholic.Text = "Alcoholic;)";
            buttonFilterAlcoholic.Click += buttonFilterAlcoholic_Click;
            // 
            // listBoxCocktails
            // 
            listBoxCocktails.FormattingEnabled = true;
            listBoxCocktails.Location = new Point(12, 60);
            listBoxCocktails.Name = "listBoxCocktails";
            listBoxCocktails.Size = new Size(744, 364);
            listBoxCocktails.TabIndex = 3;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(12, 440);
            textBoxName.Name = "textBoxName";
            textBoxName.PlaceholderText = "Cocktail name";
            textBoxName.Size = new Size(150, 27);
            textBoxName.TabIndex = 4;
            // 
            // checkBoxAlcoholic
            // 
            checkBoxAlcoholic.Location = new Point(170, 440);
            checkBoxAlcoholic.Name = "checkBoxAlcoholic";
            checkBoxAlcoholic.Size = new Size(104, 24);
            checkBoxAlcoholic.TabIndex = 5;
            checkBoxAlcoholic.Text = "Alcoholic";
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.Location = new Point(300, 440);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(150, 28);
            comboBoxCategory.TabIndex = 6;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(460, 440);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(94, 27);
            buttonAdd.TabIndex = 7;
            buttonAdd.Text = "Add";
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(570, 440);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(140, 27);
            buttonDelete.TabIndex = 8;
            buttonDelete.Text = "Remove";
            buttonDelete.Click += buttonDelete_Click;
            // 
            // textBoxNewCategory
            // 
            textBoxNewCategory.Location = new Point(12, 480);
            textBoxNewCategory.Name = "textBoxNewCategory";
            textBoxNewCategory.PlaceholderText = "Nowa kategoria";
            textBoxNewCategory.Size = new Size(200, 27);
            textBoxNewCategory.TabIndex = 9;
            // 
            // buttonAddCategory
            // 
            buttonAddCategory.Location = new Point(220, 480);
            buttonAddCategory.Name = "buttonAddCategory";
            buttonAddCategory.Size = new Size(130, 27);
            buttonAddCategory.TabIndex = 10;
            buttonAddCategory.Text = "Dodaj kategorię";
            buttonAddCategory.Click += buttonAddCategory_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(770, 450);
            Controls.Add(buttonLoad);
            Controls.Add(buttonSort);
            Controls.Add(buttonFilterAlcoholic);
            Controls.Add(listBoxCocktails);
            Controls.Add(textBoxName);
            Controls.Add(checkBoxAlcoholic);
            Controls.Add(comboBoxCategory);
            Controls.Add(buttonAdd);
            Controls.Add(buttonDelete);
            Controls.Add(textBoxNewCategory);
            Controls.Add(buttonAddCategory);
            Name = "Form1";
            Text = "Koktajle – Baza danych + API";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
