namespace TheTideGames.utils.Interpolator.DefaultLinear
{
    public sealed class FloatInterpolator : Interpolator<float>
	{
		// Update is called once per frame
		protected override float InterpolationStep()
		{
			return Entry + (Target - Entry) * (passedTime / Time);
		}
	}
}