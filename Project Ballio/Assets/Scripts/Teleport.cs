using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

	public GameObject Exit;

	private void OnTriggerEnter(Collider Other)
	{
		if(Other.gameObject.CompareTag("Teleporter"))
		{
			this.gameObject.transform.position = Exit.transform.position;
		}
	}
}
