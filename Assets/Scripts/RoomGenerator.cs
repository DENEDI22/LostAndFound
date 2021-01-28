using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ProBuilder2.Common;
using TMPro.EditorUtilities;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// Component that generates furniture and other things in the room
/// </summary>
public class RoomGenerator : MonoBehaviour
{
	public ObjectToGenerate[] wallNecessaryObjects;
	public ObjectToGenerate[] cornerNecessaryObjects;
	public ObjectToGenerate[] middleRoomNecessaryObjects;

	[SerializeField] private ObjectPoint[] wallPoints;
	[SerializeField] private ObjectPoint[] cornerPoints;
	[SerializeField] private ObjectPoint[] middlePoints;

	/// <summary>
	/// Generate objects in all points in the room
	/// </summary>
	public void GenerateObjects()
	{
		//SetNecessaryObjects(wallNecessaryObjects, wallPoints);
		SetNecessaryObjects(cornerNecessaryObjects, cornerPoints);
		//SetNecessaryObjects(middleRoomNecessaryObjects, middlePoints);
		ObjectPoint[] objectPoints = gameObject.GetComponentsInChildren<ObjectPoint>();
		foreach (var point in objectPoints)
		{
			point.GenerateObject();
		}
	}

	public void SetNecessaryObjects(ObjectToGenerate[] _necessaryObjects, ObjectPoint[] _objectPoints)
	{
		ObjectPoint[] objectPoints = gameObject.GetComponentsInChildren<ObjectPoint>();
		foreach (var obj in _necessaryObjects)
		{
			int index = Random.Range(0, _objectPoints.Length);
			_objectPoints[index].m_generatedObject = Instantiate(obj.gameObjectToPlace, _objectPoints[index].transform);
			_objectPoints.RemoveAt(index);
		}
	}

#if UNITY_EDITOR
	public void DeleteGeneration()
	{
		ObjectPoint[] objectPoints = gameObject.GetComponentsInChildren<ObjectPoint>();
		foreach (var point in objectPoints)
		{
			point.DestroyGenerated();
		}
	}
#endif
}