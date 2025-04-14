using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using NET_lab_2_poprawa;

namespace baza_danych
{
    public partial class Form1 : Form
    {
        private CocktailDbContext _dbContext;
        public Form1()
        {
            InitializeComponent();
            _dbContext = new CocktailDbContext();
            comboBoxCategory.DataSource = null;
            comboBoxCategory.DataSource = _dbContext.Categories.ToList();
            comboBoxCategory.DisplayMember = "Name";
            comboBoxCategory.ValueMember = "Id";

        }

        private async void buttonLoad_Click(object sender, EventArgs e)
        {
            listBoxCocktails.Items.Clear();

            if (!_dbContext.Cocktails.Any())
            {
                var cocktails = await FetchCocktailsFromApi();

                var categories = cocktails.Select(c => c.category).Distinct();
                foreach (var cat in categories)
                    _dbContext.Categories.Add(new CocktailCategory { Name = cat });

                await _dbContext.SaveChangesAsync();

                foreach (var c in cocktails)
                {
                    var cat = _dbContext.Categories.First(x => x.Name == c.category);
                    _dbContext.Cocktails.Add(new CocktailEntity
                    {
                        Name = c.name,
                        Alcoholic = c.alcoholic,
                        CategoryId = cat.Id
                    });
                }
                await _dbContext.SaveChangesAsync();
            }

            foreach (var c in _dbContext.Cocktails.Include(c => c.Category))
                listBoxCocktails.Items.Add(c);
        }

        private async Task<List<Cocktail>> FetchCocktailsFromApi()
        {
            using var client = new HttpClient();
            string url = "https://cocktails.solvro.pl/api/v1/cocktails";
            string response = await client.GetStringAsync(url);

            var result = JsonSerializer.Deserialize<CocktailResponse>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result?.Data ?? new();
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            listBoxCocktails.Items.Clear();
            var sorted = _dbContext.Cocktails.Include(c => c.Category).OrderBy(c => c.Name);
            foreach (var c in sorted)
                listBoxCocktails.Items.Add(c);
        }

        private void buttonFilterAlcoholic_Click(object sender, EventArgs e)
        {
            listBoxCocktails.Items.Clear();
            var filtered = _dbContext.Cocktails.Include(c => c.Category).Where(c => c.Alcoholic);
            foreach (var c in filtered)
                listBoxCocktails.Items.Add(c);
        }


        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (comboBoxCategory.SelectedItem is not CocktailCategory selectedCategory)
            {
                MessageBox.Show("Choose category!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Enter cocktail name.");
                return;
            }

            var cocktail = new CocktailEntity
            {
                Name = textBoxName.Text.Trim(),
                Alcoholic = checkBoxAlcoholic.Checked,
                CategoryId = selectedCategory.Id
            };

            _dbContext.Cocktails.Add(cocktail);
            _dbContext.SaveChanges();

            listBoxCocktails.Items.Add(cocktail);
            textBoxName.Clear();
            checkBoxAlcoholic.Checked = false;
        }


        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (listBoxCocktails.SelectedItem is CocktailEntity selectedCocktail)
            {
                _dbContext.Cocktails.Remove(selectedCocktail);
                _dbContext.SaveChanges();
                listBoxCocktails.Items.Remove(selectedCocktail);
            }
            else
            {
                MessageBox.Show("Choose a cocktail to remove.");
            }
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            var name = textBoxNewCategory.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Enter category name.");
                return;
            }

            if (_dbContext.Categories.Any(c => c.Name == name))
            {
                MessageBox.Show("There is such category!");
                return;
            }

            var category = new CocktailCategory { Name = name };
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();

            comboBoxCategory.DataSource = null;
            comboBoxCategory.DataSource = _dbContext.Categories.ToList();
            comboBoxCategory.DisplayMember = "Name";
            comboBoxCategory.ValueMember = "Id";

            textBoxNewCategory.Clear();
            MessageBox.Show("New category has been added.");
        }




    }
}
