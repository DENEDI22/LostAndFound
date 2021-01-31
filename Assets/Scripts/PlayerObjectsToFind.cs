using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerObjectsToFind : MonoBehaviour
{
	public Dictionary<int, ObjectToFindData> isObjectFound = new Dictionary<int, ObjectToFindData>();
	public Image[] images;

	public void AddObject(int objectID)
	{
		isObjectFound[objectID].isFound = true;
		images[isObjectFound[objectID].imageObjIndex].transform.parent.GetComponent<Image>().color = Color.green;
	}

	public void NeedToFind(int _objectID, Sprite _icon)
	{
		isObjectFound.Add(_objectID, new ObjectToFindData());
		for (var i = 0; i < images.Length; i++)
		{
			var VARIABLE = images[i];
			if (VARIABLE.sprite == null)
			{
				VARIABLE.sprite = _icon;
				isObjectFound[_objectID].imageObjIndex = i;
			}
		}
	}
	
	public bool isGameFinished()
	{
		foreach (var VARIABLE in isObjectFound.Values)
		{
			if (!VARIABLE.isFound)
			{
				return false;
			}
		}
		return true;
	}
}

public class ObjectToFindData
{
	public bool isFound = false;
	public int imageObjIndex;
}
