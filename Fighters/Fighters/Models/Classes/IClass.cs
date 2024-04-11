using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighters.Models.Classes
{
    public interface IClass
    {
        int Damage { get; }
        int Health { get; }
        int Skill { get; }
    }
}
