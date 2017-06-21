using UnityEngine;

namespace TheTideGames.utils.Interpolator.DefaultLinear
{
	public class Vec3Interpolator : Interpolator<Vector3>
	{
		// Update is called once per frame
		protected override void Update()
		{
			base.Update();

			CurrentValue = Entry + (Target - Entry) * (passedTime / Time);
		}
	}
}
