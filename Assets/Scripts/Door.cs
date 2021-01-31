using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	[SerializeField] private GameObject text;
	[SerializeField] private GameObject WinPanel;
	[SerializeField] private PlayerObjectsToFind player;
	[SerializeField] private Timer timer;
	private void OnTriggerEnter(Collider other)
	{
		if (player.isGameFinished())
		{
			timer.StopCoroutine("TimerTick");
		}
		else
		{
			text.SetActive(true);
		}
	}
}
