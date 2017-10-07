using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
	public GameObject Door;
	public GameObject Post;

	void OnTriggerEnter(Collider Other)
	{
		if (Other.gameObject.CompareTag("Player"))
		{
			this.gameObject.SetActive(false);
			Post.SetActive(true);
			Door.SetActive(false);
		}
	}
}
