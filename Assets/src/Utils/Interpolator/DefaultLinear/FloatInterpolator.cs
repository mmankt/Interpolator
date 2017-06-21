namespace TheTideGames.utils.Interpolator.DefaultLinear
{
    public class FloatInterpolator : Interpolator<float>
    {
        // Update is called once per frame
        protected override void Update()
        {
            base.Update();

            CurrentValue = Entry + (Target - Entry) * (passedTime / Time);
        }
    }
}