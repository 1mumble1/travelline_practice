using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighters.Models.Classes
{
    public class Knight : IClass
    {
        public int Damage => 40;
        public int Health => 50;
        public int Skill => 30;
    }
}
