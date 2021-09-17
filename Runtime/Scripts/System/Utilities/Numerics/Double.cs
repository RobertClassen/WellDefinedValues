﻿namespace System.Utilities
{
	using Collections;
	using Collections.Generic;
	using Extensions;

	public static class Double
	{
		#region Constants
		public const byte BitCount = sizeof(double) * Byte.BitCount;

		public const double Zero = Byte.Zero;
		public const double One = Byte.One;
		public const double Two = Byte.Two;
		public const double Three = Byte.Three;
		public const double Four = Byte.Four;
		public const double Five = Byte.Five;
		public const double Six = Byte.Six;
		public const double Seven = Byte.Seven;
		public const double Eight = Byte.Eight;
		public const double Nine = Byte.Nine;
		public const double Ten = Byte.Ten;
		public const double Hundred = Byte.Hundred;

		public const double OneHalf = One / Two;
		public const double OneThird = One / Three;
		public const double TwoThird = Two / Three;
		public const double OneQuarter = One / Four;
		public const double ThreeQuarter = Three / Four;
		#endregion

		#region Fields

		#endregion

		#region Properties

		#endregion

		#region Constructors

		#endregion

		#region Methods
		public static double InverseLerp(double a, double b, double value, bool isClamped = Numeric.IsLerpClampedDefault)
		{
			return Math.Abs(a - b) > double.Epsilon ? 
				((value - a) / (b - a)).Clamp01(isClamped) : Zero;
		}

		public static double Lerp(double a, double b, double t = OneHalf, bool isClamped = Numeric.IsLerpClampedDefault)
		{
			return a + (b - a) * t.Clamp01(isClamped);
		}

		public static double Random(int min, int max)
		{
			return Float.Random(min, max);
		}

		public static double Random(int min, int max, int decimals)
		{
			double magnitude = Math.Pow(Int.Ten, decimals);
			return Random(min * (int)magnitude, max * (int)magnitude) / magnitude;
		}

		public static double Remap(double fromA, double fromB, double toA, double toB, double value, 
			bool isClamped = Numeric.IsLerpClampedDefault)
		{
			return Lerp(toA, toB, InverseLerp(fromA, fromB, value, isClamped), isClamped);
		}

		public static IEnumerable<double> Sequence(double start, double increment, int count)
		{
			if(count < Int.Zero)
			{
				throw new ArgumentLessThanZeroException();
			}
			for(int i = Int.Zero; i < count; i++)
			{
				yield return start;
				start += increment;
			}
		}
		#endregion
	}
}