using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace InternationalizationDetails.Spec
{
	[Binding]
	public class PunycodeSteps
	{
		private string _inputAddress, _result;

		[Given(@"the e-mail address (.*?)")]
		public void GivenTheE_MailAddress(string address)
		{
			_inputAddress = address;
		}

		[When(@"it is converted to PunyCode")]
		public void WhenItIsConvertedToPunyCode()
		{
			var sut = new PunycodeConverter();
			_result = sut.ConvertEmailAddressToIdn(_inputAddress);
		}

		[Then(@"the result should be (.*?)")]
		public void ThenTheResultShouldBe(string actual)
		{
			actual.Should().Be(_result);
		}

		[Given(@"the following IDN e-mail addresses and their Punycode counterparts:")]
		public void GivenTheFollowingIDNE_MailAddressesAndTheirPunycodeCounterparts(Table table)
		{
			ScenarioContext.Current.Pending();
		}
	}
}
