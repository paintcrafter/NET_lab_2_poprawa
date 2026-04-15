using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Data
{
    public class CocktailCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public ICollection<CocktailEntity> Cocktails { get; set; } = new List<CocktailEntity>();
    }
}
