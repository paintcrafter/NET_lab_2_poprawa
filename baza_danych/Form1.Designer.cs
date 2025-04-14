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
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSort = new System.Windows.Forms.Button();
            this.buttonFilterAlcoholic = new System.Windows.Forms.Button();
            this.listBoxCocktails = new System.Windows.Forms.ListBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.checkBoxAlcoholic = new System.Windows.Forms.CheckBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textBoxNewCategory = new System.Windows.Forms.TextBox();
            this.textBoxNewCategory.Location = new System.Drawing.Point(12, 480);
            this.textBoxNewCategory.Size = new System.Drawing.Size(200, 27);
            this.textBoxNewCategory.PlaceholderText = "Nowa kategoria";
            this.SuspendLayout();

            // buttonLoad
            this.buttonLoad.Location = new System.Drawing.Point(12, 12);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(180, 30);
            this.buttonLoad.Text = "Load data";
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);

            // buttonSort
            this.buttonSort.Location = new System.Drawing.Point(200, 12);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(180, 30);
            this.buttonSort.Text = "Sort";
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);

            // buttonFilterAlcoholic
            this.buttonFilterAlcoholic.Location = new System.Drawing.Point(388, 12);
            this.buttonFilterAlcoholic.Name = "buttonFilterAlcoholic";
            this.buttonFilterAlcoholic.Size = new System.Drawing.Size(180, 30);
            this.buttonFilterAlcoholic.Text = "Alcoholic;)";
            this.buttonFilterAlcoholic.Click += new System.EventHandler(this.buttonFilterAlcoholic_Click);


            // listBoxCocktails
            this.listBoxCocktails.FormattingEnabled = true;
            this.listBoxCocktails.ItemHeight = 20;
            this.listBoxCocktails.Location = new System.Drawing.Point(12, 60);
            this.listBoxCocktails.Name = "listBoxCocktails";
            this.listBoxCocktails.Size = new System.Drawing.Size(744, 364);
            // textBoxName
            this.textBoxName.Location = new System.Drawing.Point(12, 440);
            this.textBoxName.Size = new System.Drawing.Size(150, 27);
            this.textBoxName.PlaceholderText = "Cocktail name";

            // checkBoxAlcoholic
            this.checkBoxAlcoholic.Location = new System.Drawing.Point(170, 440);
            this.checkBoxAlcoholic.Text = "Alcoholic";

            // comboBoxCategory
            this.comboBoxCategory.Location = new System.Drawing.Point(300, 440);
            this.comboBoxCategory.Size = new System.Drawing.Size(150, 27);

            // buttonAdd
            this.buttonAdd.Location = new System.Drawing.Point(460, 440);
            this.buttonAdd.Size = new System.Drawing.Size(94, 27);
            this.buttonAdd.Text = "Add";
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);

            // buttonDelete
            this.buttonDelete.Location = new System.Drawing.Point(570, 440);
            this.buttonDelete.Size = new System.Drawing.Size(140, 27);
            this.buttonDelete.Text = "Remove";
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);

            // buttonAddCategory
            this.buttonAddCategory = new System.Windows.Forms.Button();
            this.buttonAddCategory.Location = new System.Drawing.Point(220, 480);
            this.buttonAddCategory.Size = new System.Drawing.Size(130, 27);
            this.buttonAddCategory.Text = "Dodaj kategorię";
            this.buttonAddCategory.Click += new System.EventHandler(this.buttonAddCategory_Click);


            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 450);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.buttonFilterAlcoholic);
            this.Controls.Add(this.listBoxCocktails);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.checkBoxAlcoholic);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.textBoxNewCategory);
            this.Controls.Add(this.buttonAddCategory);
            this.Name = "Form1";
            this.Text = "Koktajle – Baza danych + API";
            this.ResumeLayout(false);
        }
    }
}
