using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Domain
{
    public class Battle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DtInit { get; set; }
        public DateTime DtEnd { get; set; }
        public List<HeroBattle> HeroesBattles { get; set; }
    }
}
