using System.Runtime.CompilerServices;
using UnityEngine;

namespace TheTideGames.utils.Interpolator.DefaultLinear
{
	public sealed class Vec3Interpolator : Interpolator<Vector3>
	{
		// Update is called once per frame
		protected override Vector3 InterpolationStep()
		{
			return Entry + (Target - Entry) * (passedTime / Time);
		}
	}
}
