using TMPro.EditorUtilities;
using UnityEngine;

/// <summary>
/// Component that generates furniture and other things in the room
/// </summary>
public class RoomGenerator : MonoBehaviour
{
	/// <summary>
	/// Generate objects in all points in the room
	/// </summary>
	public void GenerateObjects()
	{
		ObjectPoint[] objectPoints = gameObject.GetComponentsInChildren<ObjectPoint>();
		foreach (var point in objectPoints)
		{
			point.GenerateObject();
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
