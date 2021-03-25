using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Domain
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Hero Hero { get; set; }
        public int HeroId { get; set; }
    }
}
