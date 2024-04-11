﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighters.Models.Classes
{
    public class Assassin : IClass
    {
        public int Damage => 60;
        public int Health => 40;
        public int Skill => 50;
    }
}
