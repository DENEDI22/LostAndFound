using UnityEngine;
using System;


[CreateAssetMenu(fileName = "GeneratingObjectsConfig", menuName = "ScriptableObjects/Generating objects config",
	order = 0)]
public class GeneratingObjectsConfig : ScriptableObject
{
	public ObjectToGenerate[] objectsToGenerate;
}

[Serializable]
public class ObjectToGenerate
{
	public GameObject gameObjectToPlace;
	public bool letRotate = false;
	public int howMuchAvailable;
}