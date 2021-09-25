namespace WellDefinedValues
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using Core;

	public static partial class IntExtensions
	{
		public static string ToBinaryString(this int value, int minLength = Int.BitCount)
		{
			return Convert.ToString(value, (int)Numeric.Base.Binary).PadLeft(minLength, Char.Zero);
		}

		public static string ToHexString(this int value, int minLength = Int.HexLength)
		{
			return value.ToString("X" + minLength);
		}

		public static string ToInvariantString(this int value, string format = String.Null)
		{
			return value.ToString(format, Culture.Invariant);
		}
	}
}