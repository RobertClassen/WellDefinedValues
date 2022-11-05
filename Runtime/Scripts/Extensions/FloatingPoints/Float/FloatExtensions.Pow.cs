namespace NumericMath
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public static partial class FloatExtensions
	{
		public static float Pow(this float value, double exponent)
		{
			return (float)Math.Pow(value, exponent);
		}
	}
}