namespace NumericMath
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using NUnit.Framework;

	public partial class FloatTest
	{
		[Test]
		public void Sequence_Is_Correct_Length()
		{
			const int count = 6;

			float[] sequence = 1f.Sequence(count, 0f).ToArray();

			Assert.AreEqual(count, sequence.Length);
		}

		[Test]
		public void Sequence_Throws_When_Negative_Length()
		{
			const int count = -6;

			Assert.Throws<ArgumentLessThanZeroException>(() => 1f.Sequence(count, 0f).ToArray());
		}
	}
}