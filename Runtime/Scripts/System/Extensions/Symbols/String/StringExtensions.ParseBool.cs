namespace WellDefinedValues
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Globalization;

	public static partial class StringExtensions
	{
		public static bool ParseBool(this string text)
		{
			return bool.Parse(text);
		}
	}
}