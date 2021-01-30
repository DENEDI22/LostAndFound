using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public enum ItemType
{
	Small,
	Big,
	Flat,
}

public class Container : MonoBehaviour
{
	[Range(1, 100)] public int decorGeneratingProbability;
	public GeneratingObjectsConfig decorConfig;
	public ItemType[] itemTypesSupported;
	public bool isBusy;

	public static Container FindContaierForObject(Container[] _containers, ItemType _itemType)
	{
		var returnContainer = new Container();
		var availableContainers = new List<Container>();
		foreach (var VARIABLE in _containers)
		{
			if (!VARIABLE.isBusy && VARIABLE.itemTypesSupported.Contains(_itemType))
			{
				availableContainers.Add(VARIABLE);
			}
		}

		returnContainer = availableContainers[Random.Range(0, availableContainers.Count)];
		return returnContainer;
	}

	public void spawnObject(GameObject _objectToSpawn)
	{
		GameObject.Instantiate(_objectToSpawn, transform);
		isBusy = true;
	}

	public void spawnObject(GameObject _objectToSpawn, out GameObject _spawnedObject)
	{
		_spawnedObject = GameObject.Instantiate(_objectToSpawn, transform);
		isBusy = true;
	}

	public void SpawnDecor()
	{
		int generatedIndex = Random.Range(0, decorConfig.objectsToGenerate.Length);
		if (Random.Range(0, 100) < decorGeneratingProbability && !isBusy)
		{
			var generatedObject = GameObject.Instantiate(decorConfig.objectsToGenerate[generatedIndex].gameObjectToPlace,
					transform);
			if (decorConfig.objectsToGenerate[generatedIndex].letRotate)
			{
				generatedObject.transform.Rotate(new Vector3(0, Random.Range(0, 360)));
			}
		}
	}
}