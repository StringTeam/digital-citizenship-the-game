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

        void Update()
        {
            float horizontalDirection = Input.GetAxisRaw("Horizontal");
            float verticalDirection = Input.GetAxisRaw("Vertical");

            if (horizontalDirection != 0f || verticalDirection != 0f)
            {
                Vector2 direction = new Vector2(horizontalDirection, verticalDirection);
                direction.Normalize();

                player.velocity = direction * speed;

                if (horizontalDirection > 0f)
                {
                    transform.localScale = new Vector2(0.2250461f, 0.2018555f);
                }
                else if (horizontalDirection < 0f)
                {
                    transform.localScale = new Vector2(-0.2250461f, 0.2018555f);
                }
            }
            else
            {
                player.velocity = Vector2.zero;
            }
        }
    }
}

// Steven Suomalainen liikkumisen
//Joonatan Lipiäinen direction change scriptit
