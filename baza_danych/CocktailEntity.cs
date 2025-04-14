using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace baza_danych
{
    internal class CocktailEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Alcoholic { get; set; }

        public int CategoryId { get; set; }
        public CocktailCategory Category { get; set; }

        public override string ToString()
        {
            return $"{Name} ({(Alcoholic ? "Alcoholic" : "Non-alcoholic")}) - {Category?.Name}";
        }
    }
}
