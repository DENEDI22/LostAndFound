using System;
using System.Collections.Generic;
using ProBuilder2.Common;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Component that generates level data according to the difficulty level
/// </summary>
public class LevelGenerator : MonoBehaviour
{
	[SerializeField] private DifficultyConfig m_difficultyConfig;
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
		var level = Instantiate(m_difficultyConfig.flatLayouts[Random.Range(0, m_difficultyConfig.flatLayouts.Length)]);
		foreach (var VARIABLE in level.GetComponentsInChildren<RoomGenerator>())
		{
			VARIABLE.levelGenerator = this;
			VARIABLE.GenerateObjects();
		}
		containers.AddRange(GameObject.FindObjectsOfType<Container>());
		
		//defining keys 
		//TODO Make keys defining and some locked things


		//spawning all the necessary items
		foreach (var VARIABLE in objectsToFind)
		{ 
			Container.FindContaierForObject(containers.ToArray(), VARIABLE.itemType).spawnObject(VARIABLE.gameView);
		}
	}
}
[Serializable]
public class ObjectToFind
{
	public GameObject gameView;
	public ItemType itemType;
}