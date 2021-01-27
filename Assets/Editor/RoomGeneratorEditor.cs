using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RoomGenerator))]
	public class RoomGeneratorEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			RoomGenerator roomGenerator = (RoomGenerator)target;
			base.OnInspectorGUI();
			if (GUILayout.Button("Generate Objects"))
			{

				roomGenerator.GenerateObjects();
			}

			if (GUILayout.Button("Destroy Objects"))
			{
				roomGenerator.DeleteGeneration();
			}
		}
	}