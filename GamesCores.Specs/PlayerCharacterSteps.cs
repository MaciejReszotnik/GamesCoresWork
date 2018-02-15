using System;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;
using TechTalk.SpecFlow.Assist;
using System.Collections.Generic;

namespace GamesCores.Specs
{
    [Binding]
    public class PlayerCharacterSteps
    {
        
        private readonly PlayerCharacterStepsContext _context;

        public PlayerCharacterSteps(PlayerCharacterStepsContext context)
        {
            _context = context;
        }


        [Given(@"the character has damage resistance of (.*)")]
        public void GivenTheCharacterHasDamageResistanceOf(int p0)
        {
            _context.Player.DamageResistance = p0;
        }

        [Given(@"the character is an Elf")]
        public void GivenTheCharacterIsAnElf()
        {
            _context.Player.Race = "Elf";
        }

        [Given(@"the character has the following attributes")]
        public void GivenTheCharacterHasTheFollowingAttributes(Table table)
        {
            //var attributes = table.CreateInstance<PlayerAttributes>();
            dynamic attributes = table.CreateDynamicInstance();

            _context.Player.Race = attributes.Race;
            _context.Player.DamageResistance = attributes.Resistance;

            //var race = table.Rows.First(row => row["attribute"] == "Race")["value"];
            //var resistance = table.Rows.First(row => row["attribute"] == "Resistance")["value"];


            //_context.Player.Race = race;
            //_context.Player.DamageResistance = int.Parse(resistance);
        }



        [Given(@"he receives (.*) damage")]
        public void GivenHeReceivesDamage(int p0)
        {
            _context.Player.Hit(p0);
        }
        
        [Then(@"he should have (.*) Health")]
        public void ThenHeShouldBeHealthy(int p0)
        {
            Assert.Equal(p0, _context.Player.Health);
        }

        [When(@"he receives (.*) damage")]
        public void WhenHeReceivesDamage(int p0)
        {
            _context.Player.Hit(p0);
        }

        [Then(@"he should have (.*) health")]
        public void ThenHeShouldBeDamaged(int p0)
        {
            Assert.Equal(p0, _context.Player.Health);
        }

        [Then(@"he should be dead")]
        public void ThenHeShouldBeDead()
        {
            Assert.True(_context.Player.IsDead);
        }

        [When(@"I take (.*) damage")]
        public void WhenITakeDamage(int p0)
        {
            _context.Player.Hit(p0);
        }

        [When(@"I take (.*) damage")]
        [Scope(Tag = "elf")]
        public void WhenITakeDamageAsAnElf(int p0)
        {
            _context.Player.Hit(p0);
        }

        [Then(@"my health should be (.*)")]
        public void ThenMyHealthShouldBe(int p0)
        {
            Assert.Equal(_context.Player.Health, p0);
        }

        [Given(@"the character class is (.*)")]
        public void GivenTheCharacterClassIsHealer(CharacterClass character)
        {
            _context.Player.CharacterClass = character;
        }

        [Given(@"I have the following magic items")]
        public void GivenIHaveTheFollowingMagicItems(Table table)
        {
            

            IEnumerable<MagicalItem> items = table.CreateSet<MagicalItem>();
            _context.Player.MagicalItems.AddRange(items);
        }

        [Then(@"the total magic power should be (.*)")]
        public void ThenTheTotalMagicPowerShouldBe(int expectedPower)
        {
            Assert.Equal(expectedPower, _context.Player.MagicalPower);
        }


        [When(@"he casts healing spell")]
        public void WhenHeCastsHealingSpell()
        {
            _context.Player.CastHealingSpell();
        }

        [Given(@"character last slept (.* days ago)")]
        public void GivenCharacterLastSleptDaysAgo(DateTime lastSlept)
        {
            _context.Player.LastSleepTime = lastSlept;
        }

        [When(@"the character reads a restore health scroll")]
        public void WhenTheCharacterReadsARestoreHealthScroll()
        {
            _context.Player.ReadHealthScroll();
        }

        [Given(@"I have the following weapons")]
        public void GivenIHaveTheFollowingWeapons(IEnumerable<Weapon> weapons)
        {
            _context.Player.Weapons.AddRange(weapons);
        }

        [Then(@"my weapons should be worth (.*)")]
        public void ThenMyWeaponsShouldBeWorth(int p0)
        {
            
            Assert.Equal(p0, _context.Player.WeaponsValue);
        }

        [Given(@"I am an Elf")]
        public void GivenIAmAnElf()
        {
            _context.Player.Race = "Elf";
        }

        [Given(@"I have an Amulet with power of (.*)")]
        public void GivenIHaveAnAmuletWithPowerOf(int p0)
        {
            _context.Player.MagicalItems.Add(
                new MagicalItem
                {
                    Name = "Amulet",
                    Power = p0,
                    
                });
            _context.StartingMagicalPower = p0;
        }

        [When(@"I use magical Amulet")]
        public void WhenIUseMagicalAmulet()
        {
            _context.Player.UseMagicalItem("Amulet");
        }

        [Then(@"the Amulet power should not be reduced")]
        public void ThenTheAmuletPowerShouldNotBeReduced()
        {
            int _expectedPower = _context.StartingMagicalPower;
            Assert.Equal(_expectedPower, _context.Player.MagicalItems.First(item => item.Name == "Amulet").Power);


        }







    }
}
