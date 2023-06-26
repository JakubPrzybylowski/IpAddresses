using Ip.Addresses.UI.ViewModels.ValidatorsRule;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpAddresses.Tests.Ip.Addresses.UI.ValidatorsRule
{
    public class IpValidationRuleTests
    {
        private IpValidationRule _rule;
        [SetUp]
        public void SetUp()
        {
            _rule= new IpValidationRule();
        }

        [Test]
        public void CorrectIpShouldReturn_True_For_ValidationResult()
        {
            var correctIpAddress = "123.123.123.123";

            var sut = _rule.Validate(correctIpAddress, new System.Globalization.CultureInfo(1));

            Assert.That(sut.IsValid, Is.True);
        }

        [Test]
        public void WrongIpShouldReturn_False_For_ValidationResult()
        {
            var correctIpAddress = "123.123.12";

            var sut = _rule.Validate(correctIpAddress, new System.Globalization.CultureInfo(1));

            Assert.That(sut.IsValid, Is.False);
        }
    }
}
