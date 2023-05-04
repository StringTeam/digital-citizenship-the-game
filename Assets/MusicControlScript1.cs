using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControlScript1 : MonoBehaviour
{
    public static MusicControlScript1 Instance;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
//steven
