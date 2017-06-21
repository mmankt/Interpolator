# Interpolator
A generic interpolator great for MP games etc. 

Let's you interpolate your desired values to a target in a determined time. Best solution for multiplayer games, etc.

Instead of interpolating by a determined fraction of the current position to target, effecively getting ease out,
you get a consistent linear/any-other-equation-you-implement movement in a consistent time period.

Let's say you update your player position at 30hz.
You set your interpolation time to (1/30) *2 = ~66.6ms. This way even when the next packet is missed, your positions are interpolated smoothly.

Also, since you know the interpolation time for each entity for the players, the server can take it into account when checking player hits for hitscans when it checks against target's positions in the past.   

-fires events when interpolation is done/interrupted
-option for extrapolation (don't recommend extrapolation in action games)
-snap interpolations if you want a result immediately. (yourInterpolator.Interpolation=false;)
-Interpolator is a Monobehavior so it updates itself, you don't have to worry about a thing, only Setup(); and read the CurrentValue. 
-easy to rewrite as a pure Class (Setup would the constructor, store all interpolators in a list, update from one monobehaviour etc)
-base abstract class is generic so adding new interpolations is very easy. (You just overide the Update function)  

Includes built-in linear interpolations for:

-float
-Vector2, Vector3
-Euler interpolation, slerp quaternion interpolation 

License: Do anything you want with it, you can let me know if you're using it. Or not, it's cool!

includes a demo scene + usage in /Example

source is in Assets/scripts/src/TheTideGames/utils/Interpolator
