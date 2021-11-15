using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverManager : MonoBehaviour {

	[SerializeField] private GameObject _gameOverMenuVisual;
	[SerializeField] private GameObject _restartButtonVisual;



	public void RestartButtonClick()
	{
		_gameOverMenuVisual.SetActive (false);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void OpenGameOverMenu()
	{
		_gameOverMenuVisual.SetActive(true);
	}

	public void CloseGameOverMenu()
	{
		_gameOverMenuVisual.SetActive(false);
	}
}
