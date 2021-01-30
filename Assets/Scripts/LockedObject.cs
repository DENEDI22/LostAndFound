using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LockedObject : MonoBehaviour
{
	[SerializeField] private int probabilityToBeLocked;
	[HideInInspector] public int password;
	[HideInInspector] public bool isLocked;
	public Key keyReference;

	public void DefineLocked()
	{
		isLocked = Random.Range(0, 100) < probabilityToBeLocked;
		password = Random.Range(10000, 100000);
	}
}