using System;

namespace CoroutineTween.Data
{
	public class Curve
	{
		private Func<float, float> Func;

		public Curve(Func<float, float> func)
		{
			this.Func = func;
		}

		public float Caclculate(float t)
		{
			return this.Func(t);
		}
	}
}
