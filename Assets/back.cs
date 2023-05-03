using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class back : MonoBehaviour
{
    public string sceneName;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(ChangeScene);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
//joonatan