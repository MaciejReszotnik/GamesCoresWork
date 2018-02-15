using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GamesCores.Specs
{   
    [Binding]
    class CommonPlayerCharacterSteps
    {
        private readonly PlayerCharacterStepsContext _context;

        public CommonPlayerCharacterSteps(PlayerCharacterStepsContext context)
        {
            _context = context;
        }

        [Given(@"I have a character")]
        public void GivenIHaveACharacter()
        {

            _context.Player = new PlayerCharacter();
        }
    }
}
