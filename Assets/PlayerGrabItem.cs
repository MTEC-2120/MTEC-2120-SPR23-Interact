using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabItem : MonoBehaviour
{
    //private ItemGrabbable itemGrabbable = null; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float grabRange = 1.5f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, grabRange);
        foreach (Collider collider in colliderArray)
        {
            //if (collider.gameObject.TryGetComponent<ItemGrabbable>(out itemGrabbable))
            //{
            //    itemGrabbable = collider.gameObject.GetComponent<ItemGrabbable>();
            //    if (itemGrabbable != null)
            //    {
            //        itemGrabbable.SetGrabbed(true);
            //    }
            //}
        }
        
    }
}
