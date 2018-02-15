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
        private PlayerCharacter _player = new PlayerCharacter();

        [Given(@"I have a character")]
        public void GivenIHaveACharacter()
        {   if (_player == null)                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
            _player = new PlayerCharacter();
        }

        [Given(@"the character has damage resistance of (.*)")]
        public void GivenTheCharacterHasDamageResistanceOf(int p0)
        {
            _player.DamageResistance = p0;
        }

        [Given(@"the character is an Elf")]
        public void GivenTheCharacterIsAnElf()
        {
            _player.Race = "Elf";
        }

        [Given(@"the character has the following attributes")]
        public void GivenTheCharacterHasTheFollowingAttributes(Table table)
        {
            //var attributes = table.CreateInstance<PlayerAttributes>();
            dynamic attributes = table.CreateDynamicInstance();

            _player.Race = attributes.Race;
            _player.DamageResistance = attributes.Resistance;

            //var race = table.Rows.First(row => row["attribute"] == "Race")["value"];
            //var resistance = table.Rows.First(row => row["attribute"] == "Resistance")["value"];


            //_player.Race = race;
            //_player.DamageResistance = int.Parse(resistance);
        }



        [Given(@"he receives (.*) damage")]
        public void GivenHeReceivesDamage(int p0)
        {
            _player.Hit(p0);
        }
        
        [Then(@"he should have (.*) Health")]
        public void ThenHeShouldBeHealthy(int p0)
        {
            Assert.Equal(p0, _player.Health);
        }

        [When(@"he receives (.*) damage")]
        public void WhenHeReceivesDamage(int p0)
        {
            _player.Hit(p0);
        }

        [Then(@"he should have (.*) health")]
        public void ThenHeShouldBeDamaged(int p0)
        {
            Assert.Equal(p0, _player.Health);
        }

        [Then(@"he should be dead")]
        public void ThenHeShouldBeDead()
        {
            Assert.True(_player.IsDead);
        }

        [When(@"I take (.*) damage")]
        public void WhenITakeDamage(int p0)
        {
            _player.Hit(p0);
        }

        [Then(@"my health should be (.*)")]
        public void ThenMyHealthShouldBe(int p0)
        {
            Assert.Equal(_player.Health, p0);
        }

        [Given(@"the character class is (.*)")]
        public void GivenTheCharacterClassIsHealer(CharacterClass character)
        {
            _player.CharacterClass = character;
        }

        [Given(@"I have the following magic items")]
        public void GivenIHaveTheFollowingMagicItems(Table table)
        {
            

            IEnumerable<MagicalItem> items = table.CreateSet<MagicalItem>();
            _player.MagicalItems.AddRange(items);
        }

        [Then(@"the total magic power should be (.*)")]
        public void ThenTheTotalMagicPowerShouldBe(int expectedPower)
        {
            Assert.Equal(expectedPower, _player.MagicalPower);
        }


        [When(@"he casts healing spell")]
        public void WhenHeCastsHealingSpell()
        {
            _player.CastHealingSpell();
        }

        [Given(@"character last slept (.* days ago)")]
        public void GivenCharacterLastSleptDaysAgo(DateTime lastSlept)
        {
            _player.LastSleepTime = lastSlept;
        }

        [When(@"the character reads a restore health scroll")]
        public void WhenTheCharacterReadsARestoreHealthScroll()
        {
            _player.ReadHealthScroll();
        }

        [Given(@"I have the following weapons")]
        public void GivenIHaveTheFollowingWeapons(IEnumerable<Weapon> weapons)
        {
            _player.Weapons.AddRange(weapons);
        }

        [Then(@"my weapons should be worth (.*)")]
        public void ThenMyWeaponsShouldBeWorth(int p0)
        {
            
            Assert.Equal(p0, _player.WeaponsValue);
        }

        [Given(@"I am an Elf")]
        public void GivenIAmAnElf()
        {
            _player.Race = "Elf";
        }

        [Given(@"I have an Amulet with power of (.*)")]
        public void GivenIHaveAnAmuletWithPowerOf(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I use magical Amulet")]
        public void WhenIUseMagicalAmulet()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the Amulet power should not be reduced")]
        public void ThenTheAmuletPowerShouldNotBeReduced()
        {
            ScenarioContext.Current.Pending();
        }







    }
}
