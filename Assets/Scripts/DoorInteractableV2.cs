using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorInteractableV2 : MonoBehaviour, IInteractable
{

    public UnityEvent onPress; // The event that is called when a full successful interaction is made
    public UnityEvent onInteract; // The event that is called when the object is interacted with




    public void Interact(Transform interactorTransform)
    {
        if(onInteract !=null)
        {
            onInteract.Invoke(); 

        }

        //if(interactorTransform.GetComponent<ObjectInteraction>() != null)
        //{
        //    interactorTransform.GetComponent<ObjectInteraction>().Interact(); 
        //}
    }

    public string GetInteractText()
    {
        return "Open/Close Door";
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
