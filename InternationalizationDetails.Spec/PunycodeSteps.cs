using FluentAssertions;
using InternationalizationDetails.EmailAddress;
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
			var sut = new InternationalEmailAddress(_inputAddress);
			_result = sut.AsMailAddress().Address;
		}

		[Then(@"the result should be (.*?)")]
		public void ThenTheResultShouldBe(string actual)
		{
			actual.Should().Be(_result);
		}
	}
}
