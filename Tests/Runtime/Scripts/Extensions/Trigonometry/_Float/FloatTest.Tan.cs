namespace NumericMath
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using NUnit.Framework;

	public partial class FloatTest
	{
		[Test]
		public void Tan()
		{
			Assert.AreEqual(5f.Sin() / 5f.Cos(), 5f.Tan(), Delta);
		}
	}
}