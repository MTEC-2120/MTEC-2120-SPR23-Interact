using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;


/// <summary>
/// Attach this modified script to a game object in your scene, and it should also allow you to select 
/// objects by clicking on them with your mouse or tapping them on a touch screen device.
/// </summary>
public class ObjectSelector : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        // Check if the clicked object is interactable
        GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
        if (clickedObject != null && clickedObject.activeInHierarchy && clickedObject.GetComponent<ON.ON_InteractableEvents>() != null)
        {

            ON.ON_InteractableEvents pinger = clickedObject.transform.gameObject.GetComponent<ON.ON_InteractableEvents>();

            // Select the object
            //clickedObject.GetComponent<ON.ON_InteractableEvents>().Select();
            if (pinger != null)
                pinger.Ping();
        }
    }
}