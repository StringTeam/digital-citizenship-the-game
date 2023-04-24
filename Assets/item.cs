using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
  public class item : MonoBehaviour
{
    public  enum InteractionType { NONE,Pickup,Examine}
    public InteractionType type;




      private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 7;
    }
    public void Interact()
    {
        switch(type)
        {
            case InteractionType.Pickup:
                Debug.Log("Pickup");
                break;
            case InteractionType.Examine:
                Debug.Log("Examine");
                break;
                default:
                Debug.Log("Null item");
                break;
        }
    }
 }

  //Joonatan