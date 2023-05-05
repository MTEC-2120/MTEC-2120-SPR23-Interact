using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;


public class PickUpInteractable : MonoBehaviour, IInteractable
{

    [SerializeField] private string interactText;


    private Animator m_Animator; 
    private Rig rig;
    private Vector3 cachedPosition;

    public string GetInteractText()
    {

        Debug.Log("GetInteractText...");
        return interactText;
    }

    public Transform GetTransform()
    {
        return this.transform;
    }

    public void Interact(Transform interactorTransform)
    {

        rig = interactorTransform.GetComponentInChildren<Rig>();
        if (rig == null)
        {
            Debug.Log("No Rig Found.");

            return;

        }

        Transform target = rig.transform.Find("Right Arm IK/RH IK Target");
        if (target == null)
        {
            Debug.Log("No IK Target Found.");

            return;

        }


        m_Animator = interactorTransform.GetComponent<Animator>();
        m_Animator.SetTrigger("Pickup");

        cachedPosition = target.position;
        target.position = transform.position;

        rig.weight = 1;

        StartCoroutine(EndInteraction());

    }



    public void OnPickup()
    {
        TwoBoneIKConstraint ik = rig.GetComponentInChildren<TwoBoneIKConstraint>();

        this.transform.SetParent(ik.data.tip); 


    }

    IEnumerator EndInteraction()
    {
        yield return new WaitForSeconds(2);

        //m_Animator.SetTrigger("PutAway");

        Transform target = rig.transform.Find("Right Arm IK/RH IK Target");
        if (target == null)
        {
            Debug.Log("No IK Target Found.");
        }
        target.position = cachedPosition;
        rig.weight = 0;

        Destroy(this.gameObject); 
    }


}
