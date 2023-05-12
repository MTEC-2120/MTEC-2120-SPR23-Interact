using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastInteractor : MonoBehaviour, IInteractor
{
    public IInteractable GetInteractableObject()
    {
        IInteractable interactable = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
 
            if(hit.transform.gameObject.GetComponent<IInteractable>() != null)
            {
                Debug.Log(hit.transform.name);
                Debug.Log("hit");
                interactable = hit.transform.gameObject.GetComponent<IInteractable>(); 
                return interactable;
            }

            //if (hit.transform.gameObject.GetComponent<ObjectInteraction>() != null)
            //{
            //    Debug.Log(hit.transform.name);
            //    Debug.Log("hit");
            //    if(Input.GetMouseButtonDown(0))
            //    {
            //        hit.transform.gameObject.GetComponent<ObjectInteraction>().Interact();

            //    }
            //    //if (Input.GetMouseButtonUp(0))
            //    //{
            //    //    hit.transform.gameObject.GetComponent<ObjectInteraction>().In();

            //    //}
            //    return interactable;
            //}

        }


        return interactable;


    }



    // Update is called once per frame
    void Update()
    {
        IInteractable interactable = GetInteractableObject();
        if (interactable != null)
        {
            interactable.Interact(transform);
        }

        
    }
}
