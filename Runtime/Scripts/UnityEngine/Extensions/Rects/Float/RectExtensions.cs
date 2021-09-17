﻿namespace WellDefined
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public static partial class RectExtensions
	{
		#region Constants
		private const bool IsEnabledDefault = true;
		private const float IndentationWidth = 15f;
		private const float RectSpace = Float.Two;
		private const int XMin = Int.Zero;
		private const int YMin = Int.Zero;
		#endregion

		#region Fields

		#endregion

		#region Properties

		#endregion

		#region Constructors

		#endregion

		#region Methods
		public static void DrawDebugLines(this Rect rect, Color color, float depth = Float.Zero)
		{
			#if UNITY_EDITOR
			Vector3 topLeft = new Vector3(rect.xMin, rect.yMax, depth);
			Vector3 topRight = new Vector3(rect.xMax, rect.yMax, depth);
			Vector3 bottomLeft = new Vector3(rect.xMin, rect.yMin, depth);
			Vector3 bottomRight = new Vector3(rect.xMax, rect.yMin, depth);
			Debug.DrawLine(topLeft, topRight, color);
			Debug.DrawLine(bottomLeft, bottomRight, color);
			Debug.DrawLine(topLeft, bottomLeft, color);
			Debug.DrawLine(topRight, bottomRight, color);
			#endif
		}

		public static void DrawGizmoLines(this Rect rect, Color color, float depth = Float.Zero)
		{
			#if UNITY_EDITOR
			Vector3 topLeft = new Vector3(rect.xMin, rect.yMax, depth);
			Vector3 topRight = new Vector3(rect.xMax, rect.yMax, depth);
			Vector3 bottomLeft = new Vector3(rect.xMin, rect.yMin, depth);
			Vector3 bottomRight = new Vector3(rect.xMax, rect.yMin, depth);
			Gizmos.color = color;
			Gizmos.DrawLine(topLeft, topRight);
			Gizmos.DrawLine(bottomLeft, bottomRight);
			Gizmos.DrawLine(topLeft, bottomLeft);
			Gizmos.DrawLine(topRight, bottomRight);
			#endif
		}

		public static Rect Expand(this Rect rect, float margin, bool isEnabled = IsEnabledDefault)
		{
			return isEnabled ? rect.Expand(margin, margin, margin, margin) : rect;
		}

		public static Rect Expand(this Rect rect, float x, float y, bool isEnabled = IsEnabledDefault)
		{
			return isEnabled ? rect.Expand(x, x, y, y) : rect;
		}

		public static Rect Expand(this Rect rect, float left, float right, float down, float up, 
			bool isEnabled = IsEnabledDefault)
		{
			return isEnabled ? new Rect(rect.x - left, rect.y - down, 
				rect.width + right * Float.Two, rect.height + up * Float.Two) : rect;
		}

		/// <summary>
		/// Divides the <c>rect</c> into <c>xCount</c> columns and <c>yCount</c> rows 
		/// and returns the <c>Rect</c> for the cell at column <c>x</c>, row <c>y</c>.
		/// </summary>
		/// <param name="rect">The original <c>Rect</c>.</param>
		/// <param name="x">The column index.</param>
		/// <param name="y">The row index.</param>
		/// <param name="xCount">The number of columns.</param>
		/// <param name="yCount">The number of rows.</param>
		/// <param name="isEnabled">Returns the original <c>rect</c> if set to <c>false</c>.</param>
		public static Rect GetCell(this Rect rect, int x, int y, int xCount, int yCount, 
			bool isEnabled = IsEnabledDefault)
		{
			return isEnabled ? rect.GetCell(x, xCount, y, yCount, RectSpace, RectSpace) : rect;
		}

		/// <summary>
		/// Divides the <c>rect</c> into <c>xCount</c> columns and <c>yCount</c> rows 
		/// and returns the <c>Rect</c> for the cell at column <c>x</c>, row <c>y</c>.
		/// </summary>
		/// <param name="rect">The original <c>Rect</c>.</param>
		/// <param name="x">The column index.</param>
		/// <param name="y">The row index.</param>
		/// <param name="xCount">The number of columns.</param>
		/// <param name="yCount">The number of rows.</param>
		/// <param name="space">The space between columns and rows.</param>
		/// <param name="isEnabled">Returns the original <c>rect</c> if set to <c>false</c>.</param>
		public static Rect GetCell(this Rect rect, int x, int y, int xCount, int yCount, float space, 
			bool isEnabled = IsEnabledDefault)
		{
			return isEnabled ? rect.GetCell(x, xCount, y, yCount, space, space) : rect;
		}

		/// <summary>
		/// Divides the <c>rect</c> into <c>xCount</c> columns and <c>yCount</c> rows 
		/// and returns the <c>Rect</c> for the cell at column <c>x</c>, row <c>y</c>.
		/// </summary>
		/// <param name="rect">The original <c>Rect</c>.</param>
		/// <param name="x">The column index.</param>
		/// <param name="y">The row index.</param>
		/// <param name="xCount">The number of columns.</param>
		/// <param name="yCount">The number of rows.</param>
		/// <param name="xSpace">The space between columns.</param>
		/// <param name="ySpace">The space between rows.</param>
		/// <param name="isEnabled">Returns the original <c>rect</c> if set to <c>false</c>.</param>
		public static Rect GetCell(this Rect rect, int x, int y, int xCount, int yCount, float xSpace, float ySpace, 
			bool isEnabled = IsEnabledDefault)
		{
			if(!isEnabled)
			{
				return rect;
			}
			int xMax;
			int yMax;
			ValidateX(x, xCount, out xMax);
			ValidateY(y, yCount, out yMax);
			float width = (rect.width - xMax * xSpace) / (float)xCount;
			float height = (rect.height - yMax * ySpace) / (float)yCount;
			return new Rect(rect.x + (width + xSpace) * x, rect.y + (height + ySpace) * y, width, height); 
		}

		/// <summary>
		/// Divides the <c>rect</c> into <c>xCount</c> columns and returns the <c>Rect</c> for column <c>x</c>.
		/// </summary>
		/// <param name="rect">The original <c>Rect</c>.</param>
		/// <param name="x">The column index.</param>
		/// <param name="xCount">The number of columns.</param>
		/// <param name="xSpace">The space between columns.</param>
		/// <param name="isEnabled">Returns the original <c>rect</c> if set to <c>false</c>.</param>
		public static Rect GetColumn(this Rect rect, int x, int xCount, float xSpace = RectSpace, 
			bool isEnabled = IsEnabledDefault)
		{
			if(!isEnabled)
			{
				return rect;
			}
			int xMax;
			ValidateX(x, xCount, out xMax);
			float width = (rect.width - xMax * xSpace) / (float)xCount;
			return new Rect(rect.x + (width + xSpace) * x, rect.y, width, rect.height); 
		}

		/// <summary>
		/// Divides the <c>rect</c> into <c>yCount</c> rows and returns the <c>Rect</c> for row <c>y</c>.
		/// </summary>
		/// <param name="rect">The original <c>Rect</c>.</param>
		/// <param name="y">The row index.</param>
		/// <param name="yCount">The number of rows.</param>
		/// <param name="ySpace">The space between rows.</param>
		/// <param name="isEnabled">Returns the original <c>rect</c> if set to <c>false</c>.</param>
		public static Rect GetRow(this Rect rect, int y, int yCount, float ySpace = RectSpace, 
			bool isEnabled = IsEnabledDefault)
		{
			if(!isEnabled)
			{
				return rect;
			}
			int yMax;
			ValidateY(y, yCount, out yMax);
			float height = (rect.height - yMax * ySpace) / (float)yCount;
			return new Rect(rect.x, rect.y + (height + ySpace) * y, rect.width, height); 
		}

		public static Rect Indent(this Rect rect, float width, bool isEnabled = IsEnabledDefault)
		{
			return isEnabled ? new Rect(rect.x + width, rect.y, rect.width - width, rect.height) : rect;
		}

		public static Rect Indent(this Rect rect, int deltaLevel = Int.One, bool isEnabled = IsEnabledDefault)
		{
			return isEnabled ? rect.Indent(deltaLevel * IndentationWidth) : rect;
		}

		public static Rect RoundToMid(this Rect rect, bool isEnabled = IsEnabledDefault)
		{
			if(!isEnabled)
			{
				return rect;
			}
			rect.xMin = rect.xMin.RoundToMid();
			rect.yMin = rect.yMin.RoundToMid();
			rect.xMax = rect.xMax.RoundToMid();
			rect.yMax = rect.yMax.RoundToMid();
			return rect;
		}

		private static void ValidateX(int x, int xCount, out int xMax)
		{
			if(xCount <= XMin)
			{
				throw new ArgumentLessEqualsZeroException(nameof(xCount), xCount);
			}
			xMax = xCount - Int.One;
			if(!x.IsClamped(XMin, xMax))
			{
				throw new ArgumentOutOfRangeException(nameof(x), x, 
					string.Format("'{0}' must be non-negative and less than '{1}' ({2})", 
						nameof(x), nameof(xCount), xCount));
			}
		}

		private static void ValidateY(int y, int yCount, out int yMax)
		{
			if(yCount <= XMin)
			{
				throw new ArgumentLessEqualsZeroException(nameof(yCount), yCount);
			}
			yMax = yCount - Int.One;
			if(!y.IsClamped(XMin, yMax))
			{
				throw new ArgumentOutOfRangeException(nameof(y), y, 
					string.Format("'{0}' must be non-negative and less than '{1}' ({2})", 
						nameof(y), nameof(yCount), yCount));
			}
		}
		#endregion
	}
}