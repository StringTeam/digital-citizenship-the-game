using UnityEngine;
using UnityEngine.SceneManagement;

namespace ST
{
	/// <summary>
	/// The level manager is used to change levels/scenes.
	/// </summary>
	public class LevelManager : MonoBehaviour
	{
		[System.Serializable]
		public struct Level
		{
			public string name;
			public SceneReference scene;
		}

		[SerializeField] private Level _mainMenu;
		[SerializeField] private Level[] _levels;

		/// <summary>
		/// Load the main menu
		/// </summary>
		public void LoadMainMenu()
		{
			SceneManager.LoadScene(_mainMenu.scene.ScenePath);
		}

		/// <summary>
		/// Load level with the given name
		/// </summary>
		/// <param name="name">Name of the level</param>
		public void LoadLevel(string name)
		{
			for (int i = 0; i < _levels.Length; i++)
			{
				if (name == _levels[i].name)
				{
					SceneManager.LoadScene(_levels[i].scene.ScenePath);
					return;
				}
			}

			Debug.LogErrorFormat("LoadLevel: Level with name '{0}' not found.", name);
		}
	}
} // namespace ST
