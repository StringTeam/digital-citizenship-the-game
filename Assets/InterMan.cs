using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterMan : MonoBehaviour
{
    public Transform detectionPoint;

    private const float detectionRadius = 0.2f;

    public LayerMask detectionLayer;

    public GameObject detectedObject;

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

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {
        
    
           Collider2D obj =  Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
        if(obj== null)
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }
}
//Steven