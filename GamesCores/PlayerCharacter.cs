﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesCores
{
    public class PlayerCharacter
    {
        public int Health { get; private set; } = 100;

        public bool IsDead { get; private set; } = false;

        public int MagicalPower { get { return this.MagicalItems.Sum(x => x.Power); } }


        public int MyProperty
        {
            get { return this.Weapons.Sum(x => x.Value); }
            
        }


        public List<MagicalItem> MagicalItems { get; set; } = new List<MagicalItem>();
        public List<Weapon> Weapons { get; set; } = new List<Weapon>();

        public CharacterClass CharacterClass { get; set; }

        public DateTime LastSleepTime { get; set; }

        public string Race { get; set; }
        public int DamageResistance { get; set; }

        public void Hit(int damage)
        {
            

            int raceSpecificDamageResistance = 0;

            if (this.Race == "Elf")
                raceSpecificDamageResistance = 20;

            int totalDmgTaken = Math.Max(damage - raceSpecificDamageResistance - DamageResistance, 0);

            this.Health -= totalDmgTaken;

            if (Health <= 0)
            {
                this.IsDead = true;
            }
        }

        public void CastHealingSpell()
        {
            if (CharacterClass == CharacterClass.Healer)
            {
                Health = 100;
            }
            else
            {
                Health += 10;
            }
        }

        public void ReadHealthScroll()
        {
            var daysSinceLastSleep = DateTime.Now.Subtract(LastSleepTime).Days;

            if (daysSinceLastSleep <= 2)
            {
                Health = 100;
            }
        }

        public void UseMagicalItem(string itemName)
        {
            int powerReduction = 10;

            if (Race == "Elf")
            {
                powerReduction = 0;
            }

            var itemToReduce = MagicalItems.First(item => item.Name == itemName);
            itemToReduce.Power -= powerReduction;
        }

        public int WeaponsValue {
            get { return Weapons.Sum(x => x.Value); }
        }


    }
}
