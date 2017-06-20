# Interpolator
A generic interpolator great for MP games etc. 

Let's you interpolate your desired values to a target in a determined time. The best solution for multiplayer games.
Instead of interpolating by a determined fraction of the current position to target, effecively getting ease out,
you get a consistent linear/any-other-equation-you-implement movement. Let's say you update your player position at 30hz.
You set your interpolation time to (1/30) *2 = ~66.6ms. This way even when the next packet is missed, your positions are interpolated smoothly.
Also, since you know the interpolation time for each entity for the players, the server can take it into account when checking player hits for hitscans when it checks against target's positions in the past.   

-fires events when inteprolation is done
-option for extraplation
-snap interpolations if you want a result immediately. 
-Interpolator is a Monobehavior so it updates itself, you dont have to worry about a thing. 
-base abstract class is generic so adding new interpolations is very easy. (You just overide the Update function)  

Includes linear interpolations for:
-float
-Vector2, Vector3
-2d Euler interpolation 

License: Do anything you want with it, you can let me know if you're using it. Or not, it's cool.   
