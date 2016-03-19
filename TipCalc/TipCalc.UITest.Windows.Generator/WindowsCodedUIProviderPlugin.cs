using System;
using BoDi;
using TechTalk.SpecFlow.Generator.Configuration;
using TechTalk.SpecFlow.Generator.Plugins;
using TechTalk.SpecFlow.Generator.UnitTestProvider;

namespace TipCalc.UITest.Windows.Generator
{
    public class WindowsCodedUIProviderPlugin : IGeneratorPlugin
    {
        public void RegisterDependencies(ObjectContainer container)
        {

        }

        public void RegisterCustomizations(ObjectContainer container, SpecFlowProjectConfiguration generatorConfiguration)
        {
            var testProviderName = generatorConfiguration.GeneratorConfiguration.GeneratorUnitTestProvider;
            if (testProviderName.Equals("mstest", StringComparison.InvariantCultureIgnoreCase) ||
                    testProviderName.Equals("mstest.2010", StringComparison.InvariantCultureIgnoreCase))
            {
                container.RegisterTypeAs<WindowsCodedUIGeneratorProvider, IUnitTestGeneratorProvider>();
            }
        }

        public void RegisterConfigurationDefaults(SpecFlowProjectConfiguration specFlowConfiguration)
        {

        }
    }
}
