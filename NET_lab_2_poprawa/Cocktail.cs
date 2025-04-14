using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly:InternalsVisibleTo("baza_danych")]

namespace NET_lab_2_poprawa
{
    public class Cocktail
    {
        public int id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public bool alcoholic { get; set; }

        public override string ToString()
        {
            return $"id: {id}\nName: {name}\nCategory: {category}\nAlcohol: {alcoholic}";
        }
    }
}
