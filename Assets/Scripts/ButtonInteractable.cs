using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations; 
using UnityEngine.Animations.Rigging;


public class ButtonInteractable : MonoBehaviour, IInteractable
{

    public Rig rig; 
    public string GetInteractText()
    {

        Debug.Log("GetInteractText...");
        return "Please press the button";
    }  

    public Transform GetTransform()
    {
        return this.transform; 
    }

    public void Interact(Transform interactorTransform)
    {

        rig.weight = 1; 

    }


}
