//-----------------------------------------------------------------------
// <copyright file="ConfigurationServiceTests.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace ServiceLayerTests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LibraryProject.DataLayer.DataMapper;
    using ServiceLayer.ServiceImplementation;
    using Rhino.Mocks;
    using LibraryProject.DomainModel;

    /// <summary>
    /// Configuration Service Tests class.
    /// </summary>
    [TestClass]
    public class ConfigurationServiceTests
    {
        /// <summary>The configuration data services</summary>
        private IConfigurationDataService configurationDataServices;

        /// <summary>The configuration services</summary>
        private ConfigurationServiceImplementation configurationServices;

        [TestInitialize]
        public void SetUp()
        {
            configurationDataServices = MockRepository.GenerateMock<IConfigurationDataService>();
            configurationServices = new ConfigurationServiceImplementation(configurationDataServices);
        }

        /// <summary>Tests the configuration has data service with argument.</summary>
        [TestMethod]
        public void TestConfigHasDataServiceWithArgument()
        {
            configurationServices = new ConfigurationServiceImplementation(configurationDataServices);
            Assert.IsTrue(configurationServices != null);
        }

        /// <summary>Tests the configuration has data service with no argument.</summary>
        [TestMethod]
        public void TestConfigHasDataServiceWithNoArgument()
        {
            configurationServices = new ConfigurationServiceImplementation();
        }

        /// <summary>Tests the configuration get by identifier.</summary>
        [TestMethod]
        public void TestConfigurationGet()
        {
            string name = "NewConf";
            Configuration config = new Configuration { Name = "NewConf" };

            configurationDataServices.Stub(dao => dao.GetConfiguration(name)).Return(config);

            Configuration result = configurationServices.GetConfiguration(name);

            Assert.AreEqual(name, result.Name);
        }
    }
}
