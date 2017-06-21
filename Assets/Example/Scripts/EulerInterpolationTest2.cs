using System.Collections;
using System.Collections.Generic;
using TheTideGames.utils.Interpolator.DefaultLinear;
using UnityEngine;

public class EulerInterpolationTest2 : MonoBehaviour
{
	private EulerInterpolator rotationInterpolation;
	private float randomTimer;
	[SerializeField] bool randomlyInterruptInterpolation;

	void Start()
	{
		rotationInterpolation = gameObject.AddComponent<EulerInterpolator>();
		rotationInterpolation.Setup(.5f, 135, -135);
		randomTimer = .5f;
		rotationInterpolation.InterpolationDoneEvent += RotationInterpolationInterpolationDone;
	}

	void Update()
	{
		transform.eulerAngles = new Vector3(0,0, rotationInterpolation.CurrentValue);

		if (!randomlyInterruptInterpolation) return;

		randomTimer -= Time.deltaTime;

		if (randomTimer > 0) return;

		randomTimer = Random.value * .25f + .25f;
		rotationInterpolation.Target = Random.value *360 - 180;
	}

	private void RotationInterpolationInterpolationDone()
	{
		Debug.Log("rotation done");

		if (randomlyInterruptInterpolation) return;

		rotationInterpolation.Target = Random.value * 360 - 180;
	}

}
