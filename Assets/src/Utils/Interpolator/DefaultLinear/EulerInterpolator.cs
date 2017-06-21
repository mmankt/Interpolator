namespace TheTideGames.utils.Interpolator.DefaultLinear
{
	public class EulerInterpolator : Interpolator<float>
	{
		// Update is called once per frame
		protected override void Update()
		{
			base.Update();

			var diffa = Target - Entry;

			if (diffa > 180) diffa -= 360;
			else if (diffa < -180) diffa += 360;


			CurrentValue = Entry + diffa * (passedTime / Time);
		}
	}
}