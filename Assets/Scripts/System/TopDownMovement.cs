using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ST
{
    public class TopDownMovement : MonoBehaviour
    {
        public float speed = 5f;
        private float direction = 0f;
        private Rigidbody2D player;
        // Start is called before the first frame update
        void Start()
        {
            player = GetComponent<Rigidbody2D>();
            
        }

        // Update is called once per frame
        void Update()
        {

            direction = Input.GetAxisRaw("Vertical");
            direction = Input.GetAxisRaw("Horizontal");

            if (direction > 0f)
            {
                player.velocity = new Vector2(direction * speed, player.velocity.y);
                transform.localScale = new Vector2(0.2250461f, 0.2469058f);
            }
            else if (direction < 0f)
            {
                player.velocity = new Vector2(direction * speed, player.velocity.y);
                transform.localScale = new Vector2(-0.2250461f, 0.2469058f);
            }
            else
            {
                player.velocity = new Vector2(0, player.velocity.y);
            }           
        }     
    }
}

// Steven Suomalainen liikkumisen
//Joonatan Lipiäinen direction change scriptit
