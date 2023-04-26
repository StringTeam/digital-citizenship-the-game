using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(BoxCollider2D))]
  public class item : MonoBehaviour
{
    public enum InteractionType { NONE, Pickup, Examine }
    public InteractionType type;
    [Header("Exmaine")]
    public string descriptionText;
    public Sprite image;


    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 7;
    }

    public void Interact()
    {
        switch (type)
        {
            case InteractionType.Pickup:
                // Lis‰t‰‰n objekti 'PickedUpItems'-listaan InteractionSystem-luokassa
            
                // Poistetaan objekti
                Destroy(gameObject);
                break; //Steven
            case InteractionType.Examine:
             //FindObjectOfType<InteractionSystem>().ExamineItem(this);

                Debug.Log("Examine");
                break;
            default:
                Debug.Log("Null item");
                break;
        }
    }
 }

  //Joonatan