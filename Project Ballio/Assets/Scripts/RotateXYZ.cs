using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateXYZ : MonoBehaviour {
	public float X;
	public float Y;
	public float Z;

	void Update ()
	{
		transform.Rotate(new Vector3(X, Y, Z) * Time.deltaTime);
	}
}