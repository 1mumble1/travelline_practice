using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighters.Models.Classes
{
    public class Warrior : IClass
    {
        public int Damage => 20;
        public int Health => 60;
        public int Skill => 10;
    }
}
