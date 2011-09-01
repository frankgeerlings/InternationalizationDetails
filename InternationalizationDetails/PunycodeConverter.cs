namespace InternationalizationDetails
{
	public class PunycodeConverter
	{
		public string ConvertEmailAddressToIdn(string inputAddress)
		{
			// We need to split the e-mail address in the user and domain parts first.
			var x = inputAddress.Split('@');

			var user = x[0];
			var domain = x[1];

			var mapping = new System.Globalization.IdnMapping();
			return user + "@" + mapping.GetAscii(domain);
		}
	}
}
