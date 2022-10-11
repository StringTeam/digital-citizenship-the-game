using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ST
{
    public class PlayerDragScript : MonoBehaviour
    {     
        private Vector3 _dragOffset;
        [SerializeField] private float _speed = 1.9f;
        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void OnMouseDown()
        {
            _dragOffset = transform.position - GetMousePos();
        }

        void OnMouseDrag()
        {
            rb.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed + Time.deltaTime);
        }

        Vector3 GetMousePos()
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            return mousePos;
        }

        void OnMouseUp()
        {
            Vector2 dir = GetMousePos() - transform.position;

            rb.velocity = dir * 10f;
        }
    }

    /*    [SerializeField] private Canvas canvas;

        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("OnBeginDrag");
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("OnDrag");
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("OnEndDrag");
            canvasGroup.alpha = 1f;
            canvasGroup.blocksRaycasts = true;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("OnPointerDown");
        }

     /*   private bool isDragging;

        public void OnMouseDown()
        {
            isDragging = true;
        }

        public void OnMouseUp()
        {
            isDragging = false;
        }

        void Update()
        {
            if(isDragging)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.Translate(mousePosition);
            }
        } */
    
    }
