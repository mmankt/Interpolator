using UnityEngine;

namespace TheTideGames.utils.Interpolator.DefaultLinear
{
	public sealed class Vec2Interpolator : Interpolator<Vector2>
	{
		// Update is called once per frame
		protected override Vector2 InterpolationStep()
		{
			return Entry + (Target - Entry) * (passedTime / Time);
		}
	}
}