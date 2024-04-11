using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighters.Models.Races
{
    public class Elf : IRace
    {
        public int Damage => 15;

        public int Health => 90;

        public int Armor => 20;

        public int Skill => 30;
    }
}
