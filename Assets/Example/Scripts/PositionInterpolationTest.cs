using System.Collections;
using System.Collections.Generic;
using TheTideGames.utils.Interpolator.DefaultLinear;
using UnityEngine;

public class PositionInterpolationTest : MonoBehaviour
{
	private Vec3Interpolator positionInterpolation;
	private float randomTimer;
	[SerializeField] bool randomlyInterruptInterpolation;
	[SerializeField] bool interpolation;

	void Start ()
	{
		positionInterpolation = gameObject.AddComponent<Vec3Interpolator>();
		positionInterpolation.Setup(.5f,transform.position,transform.position+Vector3.left);
		randomTimer = .5f;
		positionInterpolation.InterpolationDoneEvent += PositionInterpolation_interpolationDone;
		positionInterpolation.InterpolationInterruptedEvent+= PositionInterpolation_interpolationInterrupted;

		positionInterpolation.Interpolation = false;
	}

	void Update ()
	{
		positionInterpolation.Interpolation = interpolation;

		transform.position = positionInterpolation.CurrentValue;

		if (!randomlyInterruptInterpolation) return;

		randomTimer -= Time.deltaTime;

		if (randomTimer > 0) return;

		randomTimer = Random.value * .25f+.25f;
		positionInterpolation.Target= new Vector3(Random.value*4-2, Random.value * 4 - 2);
	}

	private void PositionInterpolation_interpolationDone()
	{
		Debug.Log("repositioning done");

		if (randomlyInterruptInterpolation) return;

		positionInterpolation.Target = new Vector3(Random.value * 4 - 2, Random.value * 4 - 2);
	}

	private void PositionInterpolation_interpolationInterrupted()
	{
		Debug.Log("repositioning interrupted");
	}


}
