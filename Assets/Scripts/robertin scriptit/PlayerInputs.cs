using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ST
{
    public class PlayerInputs : MonoBehaviour
    {
        public float moveSpeed = 20f;

        private Vector2 moveInput;
        private Vector2 lastClickedPos;
        private Rigidbody2D rb;
        bool moving;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }


        void FixedUpdate()
        {
            if (Input.GetMouseButton(0))
            {
                lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                moving = true;
            }

            if (moving && (Vector2)transform.position != lastClickedPos)
            {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
            }
            else 
            {
                moving = false;
            }

            rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
        }

        void OnMove(InputValue value)
        {
            moveInput = value.Get<Vector2>();
        }

    }
}
