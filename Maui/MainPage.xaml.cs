using System.Collections.ObjectModel;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Maui.Data;

namespace Maui
{
    public partial class MainPage : ContentPage
    {
        private readonly CocktailDbContext _dbContext;
        private readonly ObservableCollection<CocktailListItem> _cocktails = new();

        public MainPage()
        {
            InitializeComponent();

            _dbContext = new CocktailDbContext();
            _dbContext.Database.EnsureCreated();
            CocktailsCollectionView.ItemsSource = _cocktails;

            LoadCategories();
        }


        private async void OnLoadClicked(object sender, EventArgs e)
        {
            try
            {
                await EnsureCocktailsLoadedAsync();
                await RefreshCocktailsAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private async Task EnsureCocktailsLoadedAsync()
        {
            if (await _dbContext.Cocktails.AnyAsync())
                return;

            var cocktails = await FetchCocktailsFromApiAsync();
            var categories = cocktails.Select(c => c.category).Distinct();

            foreach (var name in categories)
                _dbContext.Categories.Add(new CocktailCategory { Name = name });

            await _dbContext.SaveChangesAsync();

            foreach (var c in cocktails)
            {
                var category = await _dbContext.Categories.FirstAsync(x => x.Name == c.category);

                _dbContext.Cocktails.Add(new CocktailEntity
                {
                    Name = c.name,
                    Alcoholic = c.alcoholic,
                    CategoryId = category.Id
                });
            }

            await _dbContext.SaveChangesAsync();
            LoadCategories();
        }

        private async Task<List<Cocktail>> FetchCocktailsFromApiAsync()
        {
            using var client = new HttpClient();
            var json = await client.GetStringAsync("https://cocktails.solvro.pl/api/v1/cocktails");

            var result = JsonSerializer.Deserialize<CocktailResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result?.Data ?? new List<Cocktail>();
        }


        private async void OnSortClicked(object sender, EventArgs e)
        {
            var data = await _dbContext.Cocktails
                .Include(c => c.Category)
                .OrderBy(c => c.Name)
                .ToListAsync();

            ShowCocktails(data);
        }


        private async void OnFilterAlcoholicClicked(object sender, EventArgs e)
        {
            var data = await _dbContext.Cocktails
                .Include(c => c.Category)
                .Where(c => c.Alcoholic)
                .ToListAsync();

            ShowCocktails(data);
        }


        private async void OnAddClicked(object sender, EventArgs e)
        {
            if (CategoryPicker.SelectedItem is not CocktailCategory category)
            {
                await DisplayAlert("Warning", "Choose category", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(NameEntry.Text))
            {
                await DisplayAlert("Warning", "Enter name", "OK");
                return;
            }

            var cocktail = new CocktailEntity
            {
                Name = NameEntry.Text,
                Alcoholic = AlcoholicCheckBox.IsChecked,
                CategoryId = category.Id
            };

            _dbContext.Cocktails.Add(cocktail);
            await _dbContext.SaveChangesAsync();

            cocktail.Category = category;
            _cocktails.Add(CocktailListItem.FromEntity(cocktail));

            NameEntry.Text = "";
            AlcoholicCheckBox.IsChecked = false;
        }


        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (CocktailsCollectionView.SelectedItem is not CocktailListItem item)
            {
                await DisplayAlert("Warning", "Select cocktail", "OK");
                return;
            }

            var entity = await _dbContext.Cocktails.FirstOrDefaultAsync(c => c.Id == item.Id);
            if (entity == null) return;

            _dbContext.Cocktails.Remove(entity);
            await _dbContext.SaveChangesAsync();

            _cocktails.Remove(item);
            CocktailsCollectionView.SelectedItem = null;
        }


        private async void OnAddCategoryClicked(object sender, EventArgs e)
        {
            var name = NewCategoryEntry.Text?.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                await DisplayAlert("Warning", "Enter category", "OK");
                return;
            }

            if (await _dbContext.Categories.AnyAsync(c => c.Name == name))
            {
                await DisplayAlert("Warning", "Already exists", "OK");
                return;
            }

            _dbContext.Categories.Add(new CocktailCategory { Name = name });
            await _dbContext.SaveChangesAsync();

            LoadCategories();
            NewCategoryEntry.Text = "";
        }


        private async Task RefreshCocktailsAsync()
        {
            var data = await _dbContext.Cocktails
                .Include(c => c.Category)
                .ToListAsync();

            ShowCocktails(data);
        }

        private void ShowCocktails(IEnumerable<CocktailEntity> list)
        {
            _cocktails.Clear();

            foreach (var c in list)
                _cocktails.Add(CocktailListItem.FromEntity(c));
        }

        private void LoadCategories()
        {
            try
            {
                CategoryPicker.ItemsSource = _dbContext.Categories
                    .OrderBy(c => c.Name)
                    .ToList();
            }
            catch (Exception ex)
            {
                Application.Current?.MainPage?.DisplayAlert("DB error", ex.Message, "OK");
            }
        }


        private class CocktailListItem
        {
            public int Id { get; set; }
            public string Name { get; set; } = "";
            public bool Alcoholic { get; set; }
            public CategoryInfo Category { get; set; } = new();

            public string DisplayText =>
                $"{(Alcoholic ? "Alcoholic" : "Non-alcoholic")}";

            public static CocktailListItem FromEntity(CocktailEntity e)
            {
                return new CocktailListItem
                {
                    Id = e.Id,
                    Name = e.Name,
                    Alcoholic = e.Alcoholic,
                    Category = new CategoryInfo { Name = e.Category?.Name ?? "" }
                };
            }
        }

        private class CategoryInfo
        {
            public string Name { get; set; } = "";
        }
    }

}
