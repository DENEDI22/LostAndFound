using UnityEngine;

/// <summary>
/// Point where object will be generated
/// </summary>
public class ObjectPoint : MonoBehaviour
{
	[Tooltip("Probability that something will be generated here")] [Range(1, 100)]
	public int generatingProbability = 100;

	public GeneratingObjectsConfig config;
	public GameObject m_generatedObject;

	/// <summary>
	/// Generate object in the point
	/// </summary>
	public void GenerateObject()
	{
		int generatedIndex = Random.Range(0, config.objectsToGenerate.Length);
		if (Random.Range(0, 100) < generatingProbability && m_generatedObject == null)
		{
			m_generatedObject =
				GameObject.Instantiate(config.objectsToGenerate[generatedIndex].gameObjectToPlace,
					transform);
		}
	}

#if UNITY_EDITOR
	public void DestroyGenerated()
	{
		DestroyImmediate(m_generatedObject);
		m_generatedObject = null;
	}
#endif
}