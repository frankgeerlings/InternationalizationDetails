using FluentAssertions;
using NUnit.Framework;

namespace InternationalizationDetails.Spec.UnitTest
{
	using EmailAddress;

	[TestFixture]
	public class EmailAddressTests
	{
		[Test]
		public void InternationalEmailAddress_can_be_cast_from_a_regular_framework_email_address()
		{
			//// Arrange

			var sut = new System.Net.Mail.MailAddress("test@example.org", "Firstname Lastname");

			//// Act

			var actual = (InternationalEmailAddress) sut;

			//// Assert

			actual.HostnamePartAsIdn.Should().Be("example.org");
			actual.User.Should().Be("test");
		}

		[Test]
		public void InternationalEmailAddress_can_be_converted_to_a_regular_framework_email_address()
		{
			var sut = new InternationalEmailAddress("test@example.org", "Joe Public");
			var actual = sut.AsMailAddress();
			actual.DisplayName.Should().Be("Joe Public");
			actual.Address.Should().Be("test@example.org");
		}
	}
}
