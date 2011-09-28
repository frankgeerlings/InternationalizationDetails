using System.Globalization;
using System.Net.Mail;

namespace InternationalizationDetails.EmailAddress
{
	public class InternationalEmailAddress
	{
		private readonly IdnMapping _mapping = new IdnMapping();

		public string User { get; set; }
		public string HostnamePartAsIdn { get; set; }

		public InternationalEmailAddress(string emailAddress)
		{
			// We need to split the e-mail address in the user and domain parts first.
			var x = emailAddress.Split('@');

			User = x[0];
			var domain = x[1];

			// Poor man's autodetection, what if you mix xn-- with unicode? Edge cases.
			if (domain.StartsWith("xn--") || domain.Contains(".xn--"))
			{
				HostnamePartAsIdn = domain;
			}
			else
			{
				HostnamePartAsUnicode = domain;
			}
		}

		public string HostnamePartAsUnicode {
			get { return _mapping.GetUnicode(HostnamePartAsIdn); }
			set { HostnamePartAsIdn = _mapping.GetAscii(value); }
		}

		public MailAddress AsMailAddress()
		{
			return AsMailAddress(null);
		}

		public MailAddress AsMailAddress(string displayName)
		{
			return string.IsNullOrWhiteSpace(displayName)
				? new MailAddress(User + "@" + HostnamePartAsIdn)
				: new MailAddress(User + "@" + HostnamePartAsIdn, displayName);
		}
	}
}
