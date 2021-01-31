using UnityEngine;

	[CreateAssetMenu(fileName = "NewDifficultyLevel", menuName = "ScriptableObjects/Difficulty level", order = 0)]
	public class DifficultyConfig : ScriptableObject
	{
		public string name;
		public int itemsNeeded;
		public GameObject[] flatLayouts;
		public int timeToFind;
	}