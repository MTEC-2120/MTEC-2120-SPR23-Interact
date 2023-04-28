using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrabbable : MonoBehaviour, IInteractable
{

    [SerializeField] private string interactText;
    public string GetInteractText()
    {
        return interactText;

    }

    public Transform GetTransform()
    {
        return transform;

    }

    public void DestroySelf()
    {
        Destroy(this.gameObject); 
    }


    public void ShowIcon()
    {

    }

    public void SetGrabbed(bool isGrabbed)
    {

    }


    public void Interact(Transform interactorTransform)
    {

        //interactorTransform.GetComponent<PlayerGrabItem>().OnAnimationGrabbedItem()



    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
