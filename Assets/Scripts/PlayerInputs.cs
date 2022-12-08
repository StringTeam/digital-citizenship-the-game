using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//For moving player character around the office scene

namespace ST
{
    public class PlayerInputs : MonoBehaviour
    {
        //Variables for the class
        public float moveSpeed = 20f;

        private Vector2 moveInput;
        private Vector2 lastClickedPos;
        private Rigidbody2D rb;
        bool moving;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        //To move the character either by mouse input or keyboard keys with aswd, or arrow keys
        void FixedUpdate()
        {
            if (Input.GetMouseButton(0)) //To check if left mouse button was clicked
            {
                lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // To save the mouse cursor location to a variable
                moving = true; //To check if moving already
            }

            if (moving && (Vector2)transform.position != lastClickedPos) //To check if moving already and the last clicked position isn't the same as transformation position of the player
            {
                float step = moveSpeed * Time.deltaTime; //to save moveSpeed variable multiplied by time into a float variable
                transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step); // Tries to the player to where they last clicked by the speed variable saved in the step variable
            }
            else 
            {
                moving = false;
            }

            rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime); //Moves the player with keyboard inputs by taking the input vector2 from the moveInput variable, multiplied by
                                                                                        //moveSpeed variable and time
        }

        void OnMove(InputValue value)
        {
            moveInput = value.Get<Vector2>();
        }

    }
}
