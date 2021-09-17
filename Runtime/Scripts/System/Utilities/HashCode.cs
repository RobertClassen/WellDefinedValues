namespace System.Utilities
{
	using Collections;
	using Collections.Generic;
	using Linq;

	public static class HashCode
	{
		#region Constants
		private const int seed = 1009;
		private const int factor = 9176;
		#endregion

		#region Fields

		#endregion

		#region Properties
		
		#endregion

		#region Constructors

		#endregion

		#region Methods
		public static int Combine(int value0, int value1)
		{
			int hash = seed;
			hash = (hash * factor) + value0;
			hash = (hash * factor) + value1;
			return hash;
		}

		public static int Combine(int value0, int value1, int value2)
		{
			int hash = seed;
			hash = (hash * factor) + value0;
			hash = (hash * factor) + value1;
			hash = (hash * factor) + value2;
			return hash;
		}

		public static int Combine(int value0, int value1, int value2, int value3)
		{
			int hash = seed;
			hash = (hash * factor) + value0;
			hash = (hash * factor) + value1;
			hash = (hash * factor) + value2;
			hash = (hash * factor) + value3;
			return hash;
		}

		public static int Combine(int value0, int value1, int value2, int value3, int value4)
		{
			int hash = seed;
			hash = (hash * factor) + value0;
			hash = (hash * factor) + value1;
			hash = (hash * factor) + value2;
			hash = (hash * factor) + value3;
			hash = (hash * factor) + value4;
			return hash;
		}

		public static int Combine(int value0, int value1, int value2, int value3, int value4, int value5)
		{
			int hash = seed;
			hash = (hash * factor) + value0;
			hash = (hash * factor) + value1;
			hash = (hash * factor) + value2;
			hash = (hash * factor) + value3;
			hash = (hash * factor) + value4;
			hash = (hash * factor) + value5;
			return hash;
		}

		public static int Combine(int value0, int value1, int value2, int value3, int value4, int value5, int value6)
		{
			int hash = seed;
			hash = (hash * factor) + value0;
			hash = (hash * factor) + value1;
			hash = (hash * factor) + value2;
			hash = (hash * factor) + value3;
			hash = (hash * factor) + value4;
			hash = (hash * factor) + value5;
			hash = (hash * factor) + value6;
			return hash;
		}

		public static int Combine(int value0, int value1, int value2, int value3, int value4, int value5, int value6, int value7)
		{
			int hash = seed;
			hash = (hash * factor) + value0;
			hash = (hash * factor) + value1;
			hash = (hash * factor) + value2;
			hash = (hash * factor) + value3;
			hash = (hash * factor) + value4;
			hash = (hash * factor) + value5;
			hash = (hash * factor) + value6;
			hash = (hash * factor) + value7;
			return hash;
		}

		public static int Combine(params int[] values)
		{
			int hash = seed;
			foreach(int i in values)
			{
				hash = (hash * factor) + i;
			}
			return hash;
		}
		#endregion
	}
}