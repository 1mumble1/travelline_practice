using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighters.Models.Races
{
    public class Witcher : IRace
    {
        public int Damage => 20;

        public int Health => 100;

        public int Armor => 0;

        public int Skill => 50;
    }
}
