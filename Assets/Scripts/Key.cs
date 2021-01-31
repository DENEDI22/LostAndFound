using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
	public int password;

	public void ClickedOnObject()
	{
		GameObject.FindObjectOfType<PlayerKeys>().playerKeys.Add(password);
		Destroy(gameObject);
	}
}
