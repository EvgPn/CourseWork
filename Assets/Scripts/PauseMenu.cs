using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	private bool _gameIsPaused = false;
	[SerializeField] private GameObject _pauseMenuUI = null;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (_gameIsPaused)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
	}

	public void Resume()
	{
		_pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		_gameIsPaused = false;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

	}

	public void NewGame()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainScene");
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	private void Pause()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		_pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		_gameIsPaused = true;
	}
}
