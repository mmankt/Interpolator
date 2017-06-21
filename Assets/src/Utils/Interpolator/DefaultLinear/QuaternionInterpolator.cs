using UnityEngine;

namespace TheTideGames.utils.Interpolator.DefaultLinear
{
	public class QuaternionInterpolator : Interpolator<Quaternion>
	{
		// Update is called once per frame
		protected override void Update()
		{
			base.Update();

			CurrentValue = Quaternion.Slerp(CurrentValue,Target,passedTime/Time);
		}
	}
}