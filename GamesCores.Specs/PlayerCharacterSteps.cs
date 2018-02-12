using System;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;

namespace GamesCores.Specs
{
    [Binding]
    public class PlayerCharacterSteps
    {
        private PlayerCharacter _player;

        [Given(@"I have a character")]
        public void GivenIHaveACharacter()
        {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
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
            var race = table.Rows.First(row => row["attribute"] == "Race")["value"];
            var resistance = table.Rows.First(row => row["attribute"] == "Resistance")["value"];


            _player.Race = race;
            _player.DamageResistance = int.Parse(resistance);
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

        [When(@"he casts healing spell")]
        public void WhenHeCastsHealingSpell()
        {
            _player.CastHealingSpell();
        }




    }
}
