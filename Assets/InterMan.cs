using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InterMan : MonoBehaviour
{
    [Header("Detection parameters")]
    public Transform detectionPoint;

    private const float detectionRadius = 0.2f;

    public LayerMask detectionLayer;

    public GameObject detectedObject;
    [Header("Examine Fields")]
    public GameObject examineWindow;
    public Image examineImage;
    public Text examineText;
        
    //Examine window object
    [Header("Others")]
    //List of picked items
    public List<GameObject> PickedItems = new List<GameObject>();

    void Update()
    {
        if (DetectObject())
        {
            if (InteractInput())
            {
                detectedObject.GetComponent<item>().Interact();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {


        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
        if (obj == null)
        {
            detectedObject = null;
            return false;//Joonatan

        }
        else
        {
            detectedObject = obj.gameObject;
            return true;//Joonatan 
        }
    }

    public void PickUpItem(GameObject item)
    {
        PickedItems.Add(item);
    }

    public void ExamineItem(item item)
    {
        examineWindow.SetActive(true);
        examineImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
        examineText.text = item.descriptionText;
    }

}



//Steven