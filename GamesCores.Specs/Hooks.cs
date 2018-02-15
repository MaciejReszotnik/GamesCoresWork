using TechTalk.SpecFlow;

namespace GamesCores.Specs
{
    [Binding]
    public class Hooks :Steps
    {
        [BeforeScenario("elf")]
        public void BeforeScenario()
        {

        }

        [AfterScenario]
        public void AfterScenario()
        {

        }
    }
}
