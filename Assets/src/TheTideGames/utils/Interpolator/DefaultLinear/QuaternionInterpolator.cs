using UnityEngine;

namespace TheTideGames.utils.Interpolator.DefaultLinear
{
	public sealed class QuaternionInterpolator : Interpolator<Quaternion>
	{
		// Update is called once per frame
		protected override Quaternion InterpolationStep()
		{
			return Quaternion.Slerp(CurrentValue,Target,passedTime/Time);
		}
	}
}