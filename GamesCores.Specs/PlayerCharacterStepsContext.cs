using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GamesCores.Specs
{
    [Binding]
    public class PlayerCharacterStepsContext
    {
        public PlayerCharacter Player { get; set; }

        public int StartingMagicalPower { get; set; }
        
    }
}
