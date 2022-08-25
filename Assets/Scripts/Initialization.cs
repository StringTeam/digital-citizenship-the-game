using UnityEngine;

namespace ST
{
	public class Initialization : MonoBehaviour
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void LoadManagers()
		{
			GameObject managers = GameObject.Instantiate(Resources.Load("Prefabs/Managers")) as GameObject;
			managers.AddComponent<Util.Persistent>();
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void LoadInputManager()
		{
			GameObject managers = GameObject.Instantiate(Resources.Load("Prefabs/Input Manager")) as GameObject;
			managers.AddComponent<Util.Persistent>();
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void LoadPauseMenu()
		{
			GameObject pauseMenu = GameObject.Instantiate(Resources.Load("Prefabs/Pause Menu")) as GameObject;
			pauseMenu.AddComponent<Util.Persistent>();
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void LoadEventSystem()
		{
			GameObject eventSystem = GameObject.Instantiate(Resources.Load("Prefabs/EventSystem")) as GameObject;
			eventSystem.AddComponent<Util.Persistent>();
		}
	}
} // namespace ST
