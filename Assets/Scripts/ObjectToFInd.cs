using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectToFInd : MonoBehaviour
{
	public int objectID;
	public Sprite objectSprite;
	public void ClickedOnObject()
	{
		GameObject.FindObjectOfType<PlayerObjectsToFind>().AddObject(objectID);
		Destroy(gameObject);
	}

	public void GenerateID()
	{
		objectID = Random.Range(100, 1000);
		FindObjectOfType<PlayerObjectsToFind>().NeedToFind(objectID, objectSprite);
	}
}
