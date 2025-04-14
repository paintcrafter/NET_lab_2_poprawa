using System.Text.Json;

namespace NET_lab_2_poprawa
{
    public partial class Form1 : Form
    {
        private HttpClient client;

        public Form1()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        private async void buttonLoad_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string url = "https://cocktails.solvro.pl/api/v1/cocktails";
            string response = await client.GetStringAsync(url);

            var result = JsonSerializer.Deserialize<CocktailResponse>(response, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var cocktails = result?.Data ?? new List<Cocktail>();

            foreach (var cocktail in cocktails)
            {
                listBox1.Items.Add($"id: {cocktail.id}");
                listBox1.Items.Add($"Name: {cocktail.name}");
                listBox1.Items.Add($"Category: {cocktail.category}");
                listBox1.Items.Add($"Alcohol: {cocktail.alcoholic}");
                listBox1.Items.Add("----------------------");
            }
        }
    }
}
