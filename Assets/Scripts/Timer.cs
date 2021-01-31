using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI timerText;
	public int secondsLeft;

	public void StartTimer(int _timerSeconds)
	{
		StartCoroutine("TimerTick");
	}

	public void Start()
	{
		StartTimer(15);
	}

	IEnumerator TimerTick()
	{
		while (secondsLeft > 0)
		{
			secondsLeft--;
			timerText.text = secondsLeft / 60 + ":" + secondsLeft % 60;
			yield return new WaitForSeconds(1f);
		}

		GameOver();
	}

	public void GameOver()
	{
		Debug.Log("GAME OVER");
	}
}