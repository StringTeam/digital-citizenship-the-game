using UnityEngine;

public class SavePosition : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("playerPosX", transform.position.x);
        PlayerPrefs.SetFloat("playerPosY", transform.position.y);
        PlayerPrefs.SetFloat("playerPosZ", transform.position.z);
    }//joonatan
}
