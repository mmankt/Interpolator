using UnityEngine;

namespace TheTideGames.utils.Interpolator.DefaultLinear
{
	public class Vec2Interpolator : Interpolator<Vector2>
	{
		// Update is called once per frame
		protected override void Update()
		{
			base.Update();

			CurrentValue = Entry + (Target - Entry) * (passedTime / Time);
		}
	}
}