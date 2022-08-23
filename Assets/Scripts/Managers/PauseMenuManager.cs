using UnityEngine;

namespace ST
{
	public class PauseMenuManager : MonoBehaviour
	{
		[SerializeField] private GameObject _pauseMenuPanel;

		private InputManager _inputManager;
		private LevelManager _levelManager;

		private void Start()
		{
			_inputManager = FindObjectOfType<InputManager>();
			_levelManager = FindObjectOfType<LevelManager>();
		}

		private void Update()
		{
			if (_inputManager.EscapeInput /*&& UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex != 0*/)
			{
				_inputManager.ResetEscapeInput();

				//TODO: A better solution to checking wheter or not we should be able to open the pause menu

				TogglePauseMenu();
			}
		}

		/// <summary>
		/// Toggle the pause menu
		/// </summary>
		public void TogglePauseMenu()
		{
			_pauseMenuPanel.SetActive(!_pauseMenuPanel.activeInHierarchy);
		}

		public void BackToMenu()
		{
			TogglePauseMenu(); //TODO: Fix the flashing of the screen here.
			_levelManager.LoadMainMenu();
		}
	}
} // namespace ST
