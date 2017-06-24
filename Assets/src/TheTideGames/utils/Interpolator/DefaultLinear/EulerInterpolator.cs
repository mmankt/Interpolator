using System;

namespace TheTideGames.utils.Interpolator.DefaultLinear
{
	public sealed class EulerInterpolator : Interpolator<float>
	{
		// Update is called once per frame
		protected override float InterpolationStep()
		{
			var diffa = Target - Entry;

			if (diffa > 180) diffa -= 360;
			else if (diffa < -180) diffa += 360;

			return Entry + diffa * (passedTime / Time);
		}
	}
}