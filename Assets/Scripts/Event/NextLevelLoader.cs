using UnityEngine;
using UnityEngine.SceneManagement;


public class NextLevelLoader : MonoBehaviour
{
	[SerializeField] private string loadLevelName = default;


	public void LoadLevelByName()
	{
		SceneManager.LoadScene(loadLevelName, LoadSceneMode.Single);
	}
}
