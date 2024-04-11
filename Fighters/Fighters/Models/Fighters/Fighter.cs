﻿using Fighters.Models.Armors;
using Fighters.Models.Races;
using Fighters.Models.Classes;
using Fighters.Models.Weapons;

namespace Fighters.Models.Fighters
{
    public class Fighter : IFighter
    {
        public int MaxHealth => Race.Health + Class.Health;
        public int CurrentHealth { get; set; }

        public string Name { get; }

        public IRace Race { get; }
        public IWeapon Weapon { get; set; }
        public IArmor Armor { get; set; }
        public IClass Class { get; set; }

        public int Skill => Race.Skill + Class.Skill;
        public int CurrentArmor { get; set; }
        

        public Fighter(string name, IRace race, IClass fighterClass, IWeapon weapon, IArmor armor)
        {
            Name = name;
            Race = race;
            Weapon = weapon;
            Armor = armor;
            Class = fighterClass;
            CurrentHealth = MaxHealth;
            CurrentArmor = Race.Armor + Armor.Armor;
        }

        public int CalculateDamage()
        {
            double damageMultiplicator = Random.Shared.Next(80, 111) / 100d;
            double totalDamage = (Race.Damage + Weapon.Damage + Class.Damage) * damageMultiplicator;

            // critical damage with 5% probability
            if (Random.Shared.Next(0, 101) <= 5)
            {
                Console.WriteLine("Критический урон!");
                return (int)totalDamage * 2;
            }

            return (int)totalDamage;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= Math.Max((damage - CurrentArmor), 0);
            CurrentArmor -= damage / 5;
            if (CurrentArmor < 0)
            {
                CurrentArmor = 0;
            }
            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
        }

        public override string ToString()
        {
            return $"У бойца {Name}: здоровье - {CurrentHealth}, броня - {CurrentArmor}";
        }
    }
}
