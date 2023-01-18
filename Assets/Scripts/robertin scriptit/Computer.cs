using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

namespace ST
{
    [RequireComponent(typeof(BoxCollider2D))]

    public class Computer : MonoBehaviour
    {
        string Message = "Haluatko pelata minipelej�? N�pp�in K = Kyll�, E = Ei";
        string Message2 = "";
        public TextMeshProUGUI Messages;
        bool HasBeenTriggered = false;
        
        private void Reset()
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }

        void Update()
        {
            if(HasBeenTriggered == true)
                if (Input.GetKeyDown("k"))
                {
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Desktop");
                }
                else if (Input.GetKeyDown("e"))
                {
                    Time.timeScale = 1;
                    Messages.text = Message2;
                    Reset();
                    HasBeenTriggered = false;
                }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.CompareTag("Player") && HasBeenTriggered == false)
            {
                Time.timeScale = 0;
                HasBeenTriggered = true;
                Messages.text = Message;
            }
        }                 
    }
}
    
 

