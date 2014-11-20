using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordReference
{
	public enum Language
	{
		[CountryCode("ar")]
		Arabic,
		[CountryCode("zh")]
		Chinese,
		[CountryCode("cz")]
		Czech,
		[CountryCode("en")]
		English,
		[CountryCode("fr")]
		French,
		[CountryCode("de")]
		German,
		[CountryCode("gr")]
		Greek,
		[CountryCode("ja")]
		Japanese,
		[CountryCode("it")]
		Italian,
		[CountryCode("ko")]
		Korean,
		[CountryCode("pl")]
		Polish,
		[CountryCode("pt")]
		Portuguese,
		[CountryCode("ro")]
		Romanian,
		[CountryCode("es")]
		Spanish,
		[CountryCode("tr")]
		Turkish
 	}

	internal class CountryCodeAttribute : Attribute
	{
		public string Code { get; private set; }

		public CountryCodeAttribute(string code)
		{
			Code = code;
		}

		internal static string Get(Language lang)
		{
			var type = typeof(Language);
			var member = type.GetField(lang.ToString());
			var attr = member.GetCustomAttributes(typeof(CountryCodeAttribute), false)[0] as CountryCodeAttribute;
			return attr.Code;
		}
	}
}
