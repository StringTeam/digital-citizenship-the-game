using UnityEngine;

namespace ST.Scenes
{
    public class Menu : MonoBehaviour
    {
        void Start()
        {
            GameObject.Instantiate(Resources.Load("Prefabs/mainmenu"));
        }
    }
}
