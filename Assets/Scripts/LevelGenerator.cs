using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ProBuilder2.Common;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Component that generates level data according to the difficulty level
/// </summary>
public class LevelGenerator : MonoBehaviour
{
	[SerializeField] private DifficultyConfig m_difficultyConfig;
	[SerializeField] private GameObject level;
	[SerializeField] private GameObject player;
	public ObjectToFind[] objectsToFind;
	[SerializeField] private ObjectToFind[] allObjectsThatCanBeHiden;
	public List<Container> containers = new List<Container>();

	private GameObject currentLayout;

	private void Awake()
	{
		GenerateLevel();
	}

	public void GenerateLevel()
	{
		//setting up the objects to find
		objectsToFind = new ObjectToFind[m_difficultyConfig.itemsNeeded];
		for (var i = 0; i < objectsToFind.Length; i++)
		{
			int index = Random.Range(0, allObjectsThatCanBeHiden.Length);
			objectsToFind[i] = allObjectsThatCanBeHiden[index];
			allObjectsThatCanBeHiden.RemoveAt(index);
		}
		
		//setting up level
		foreach (var VARIABLE in level.GetComponentsInChildren<RoomGenerator>())
		{
			VARIABLE.levelGenerator = this;
			VARIABLE.GenerateObjects();
		}
		containers.AddRange(GameObject.FindObjectsOfType<Container>());

		//spawning necessary items
		foreach (var VARIABLE in objectsToFind)
		{
			GameObject _obj;
			Container.FindContaierForObject(containers.ToArray(), VARIABLE.itemType).spawnObject(VARIABLE.gameView, out _obj);
			_obj.GetComponent<ObjectToFInd>().GenerateID();
		}
		
		//Locking objects and spawning keys
		var lockedObjects = GameObject.FindObjectsOfType<LockedObject>();
		foreach (var VARIABLE in lockedObjects)
		{
			VARIABLE.DefineLocked();
			if (VARIABLE.isLocked)
			{
				GameObject keyGO;
				Container.FindContaierForObject(containers.ToArray(), ItemType.Small).spawnObject(VARIABLE.keyReference.gameObject, out keyGO);
				keyGO.GetComponent<Key>().password = VARIABLE.password;
			}
		}
		
		//spawning decorations
		foreach (var VARIABLE in containers)
		{
			VARIABLE.SpawnDecor();
		}
		
		//Setting player position
		var playerSpawnPoints = GameObject.FindGameObjectsWithTag("PlayerSpawnPoint");

		player.transform.position = playerSpawnPoints[Random.Range(0, playerSpawnPoints.Length)].transform.position;
		
		//Setting timer
		FindObjectOfType<Timer>().secondsLeft = m_difficultyConfig.timeToFind;
	}
}
[Serializable]
public class ObjectToFind
{
	public GameObject gameView;
	public ItemType itemType;
}