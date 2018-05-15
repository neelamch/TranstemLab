using Flux.Core;
using Flux.TranstemLab.StepHelper.Pages;
using TechTalk.SpecFlow;

namespace Flux.TranstemLab.StepHelper.Base
{
    public class TranstemLabTestBase : BddTestBase
    {
        [BeforeFeature]
        public static void MyCareTendOneTimeSetup()
        {
            switch (TestEnvironment.AppSettings["BrowserType"].ToLower())
            {
                case "chrome":
                    bddHooks.TestConfig.InitializeDriver("chrome");
                    break;
                case "ie":
                    bddHooks.TestConfig.InitializeDriver("ie");
                    break;
                case "firefox":
                    bddHooks.TestConfig.InitializeDriver("firefox");
                    break;
                case "safari":
                    bddHooks.TestConfig.InitializeDriver("safari");
                    break;
                case "ios":
                    bddHooks.TestConfig.InitializeDriver("android");
                    break;
                case "android":
                    bddHooks.TestConfig.InitializeDriver("ios");
                    break;
            }
        }



        public class TrasLabContext
        {
            

            public TranstemLabHomePage TranstemLabHomePage { get; set; }
        }
    }
}
