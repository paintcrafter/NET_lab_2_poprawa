using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
[assembly: InternalsVisibleTo("baza_danych")]

namespace NET_lab_2_poprawa
{
    public class CocktailResponse
    {
        public List<Cocktail> Data { get; set; }
    }
}
