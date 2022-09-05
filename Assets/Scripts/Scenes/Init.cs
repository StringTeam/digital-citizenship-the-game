using UnityEngine;

namespace ST.Scenes
{
    public class Init : MonoBehaviour
    {
        private Managers.LevelManager _levelManager;

        void Awake() {
            _levelManager = FindObjectOfType<Managers.LevelManager>();
        }

        void Start()
        {
            _levelManager.LoadMainMenu();
        }
    }
}
