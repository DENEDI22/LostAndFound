using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LockedObject : MonoBehaviour
{
	[SerializeField] private int probabilityToBeLocked;
	[SerializeField] private AudioClip TryOnLockedSound;
	[SerializeField] private AudioClip UnlockSound;
	[SerializeField] private AudioClip OpenSound;
	[SerializeField] private AudioClip CloseSound;
	private AudioSource m_audioSource;
	private PlayerKeys m_playerKeys;
	private Animator m_animator;
	[HideInInspector] public int password;
	[HideInInspector] public bool isLocked;
	public Key keyReference;

	private void Awake()
	{
		m_playerKeys = GameObject.FindObjectOfType<PlayerKeys>();
		m_audioSource = m_playerKeys.GetComponent<AudioSource>();
		m_animator = GetComponent<Animator>();
	}

	public void ClickedOnObject()
	{
		if (isLocked)
		{
			if (m_playerKeys.playerKeys.Contains(password))
			{
				m_audioSource.clip = UnlockSound;
				isLocked = false;
				m_audioSource.Play();
			}
			else
			{
				m_audioSource.clip = TryOnLockedSound;
				m_audioSource.Play();
			}
		}
		else
		{
			m_audioSource.clip = !m_animator.GetBool("isOpen") ? OpenSound : CloseSound;
			m_animator.SetBool("isOpen", !m_animator.GetBool("isOpen"));
		}
	}
	
	public void DefineLocked()
	{
		isLocked = Random.Range(0, 100) < probabilityToBeLocked;
		password = Random.Range(10000, 100000);
	}
}