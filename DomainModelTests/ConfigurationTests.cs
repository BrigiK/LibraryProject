//-----------------------------------------------------------------------
// <copyright file="ConfigurationTests.cs" company="Transilvania University of Brasov">
//     Author Kocs Brigitta.
// </copyright>
//-----------------------------------------------------------------------
namespace DomainModelTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using LibraryProject.DomainModel;
    using Microsoft.Practices.EnterpriseLibrary.Validation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Configuration Tests class.
    /// </summary>
    [TestClass]
    public class ConfigurationTests
    {
        /// <summary>The configuration</summary>
        private Configuration configuration = null;

        /// <summary>Sets up.</summary>
        [TestInitialize]
        public void SetUp()
        {
            // a valid configuration
            configuration = new Configuration()
            {
               Name = "config",
               Value = 15
            };
        }

        /// <summary>Tests the configuration is valid.</summary>
        [TestMethod]
        public void TestConfigurationIsValid()
        {
            ValidationResults validationResults = Validation.Validate<Configuration>(configuration);
            Assert.AreEqual(0, validationResults.Count);
        }

        //// NAME

        /// <summary>Tests the configuration identifier set get.</summary>
        [TestMethod]
        public void TestConfigIdSetGet()
        {
            configuration.Name = "hello";
            ValidationResults validationResults = Validation.Validate<Configuration>(configuration);
            Assert.AreEqual(0, validationResults.Count);
            Assert.AreEqual("hello", configuration.Name);
        }

        /// <summary>Tests the configuration name is null.</summary>
        [TestMethod]
        public void TestConfigNameIsNull()
        {
            configuration.Name = null;
            ValidationResults validationResults = Validation.Validate<Configuration>(configuration);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the configuration name is not null.</summary>
        [TestMethod]
        public void TestConfigNameIsNotNull()
        {
            configuration.Name = "Hello";
            ValidationResults validationResults = Validation.Validate<Configuration>(configuration);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the configuration name is empty.</summary>
        [TestMethod]
        public void TestConfigNameIsEmpty()
        {
            configuration.Name = string.Empty;
            ValidationResults validationResults = Validation.Validate<Configuration>(configuration);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the configuration name is not empty.</summary>
        [TestMethod]
        public void TestConfigNameIsNotEmpty()
        {
            configuration.Name = "Title";
            ValidationResults validationResults = Validation.Validate<Configuration>(configuration);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the configuration name too short.</summary>
        [TestMethod]
        public void TestConfigNameTooShort()
        {
            configuration.Name = string.Empty;
            ValidationResults validationResults = Validation.Validate<Configuration>(configuration);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the configuration name lower boundary.</summary>
        [TestMethod]
        public void TestConfigNameLowerBoundary()
        {
            configuration.Name = "D";
            ValidationResults validationResults = Validation.Validate<Configuration>(configuration);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the configuration name upper boundary.</summary>
        [TestMethod]
        public void TestConfigNameUpperBoundary()
        {
            configuration.Name = new string('a', 30);
            ValidationResults validationResults = Validation.Validate<Configuration>(configuration);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>Tests the configuration name too long.</summary>
        [TestMethod]
        public void TestConfigNameTooLong()
        {
            configuration.Name = new string('a', 31);
            ValidationResults validationResults = Validation.Validate<Configuration>(configuration);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        //// VALUE

        /// <summary>Tests the configuration value negative.</summary>
        [TestMethod]
        public void TestConfigValueNegative()
        {
            configuration.Value = -1;
            ValidationResults validationResults = Validation.Validate<Configuration>(configuration);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the configuration value smaller.</summary>
        [TestMethod]
        public void TestConfigValueSmaller()
        {
            configuration.Value = 0;
            ValidationResults validationResults = Validation.Validate<Configuration>(configuration);
            Assert.AreNotEqual(0, validationResults.Count);
        }

        /// <summary>Tests the configuration value is zero.</summary>
        [TestMethod]
        public void TestConfigurationValueIsZero()
        {
            configuration.Value = 0;
            ValidationResults validationResults = Validation.Validate<Configuration>(configuration);
            Assert.AreNotEqual(0, validationResults.Count);
        }
    }
}
