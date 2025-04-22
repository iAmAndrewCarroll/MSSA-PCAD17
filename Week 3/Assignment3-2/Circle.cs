namespace Assignment3_2
{
	public class Circle
	{
		public double Radius { get; }

		public double Area => Math.PI * Math.Pow(Radius, 2);

		public Circle(double radius)
		{
			Radius = radius;
		}

		public static double operator +(Circle c1, Circle c2)
		{
			return c1.Area + c2.Area;
		}

		public static double operator -(Circle c1, Circle c2)
		{
			return c1.Area - c2.Area;
		}
	}
}
