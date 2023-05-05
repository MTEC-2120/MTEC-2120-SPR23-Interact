using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class NPCDialog : MonoBehaviour, IInteractable
{

    public List<string> dialogSequence;

    public GameObject chatPrefab;

    public float chatTime; 

    private TMP_Text chatText;
    private GameObject chatBubble; 

    [SerializeField] private string interactText;



    private void Awake()
    {

    }

    public void Interact(Transform interactorTransform)
    {
        Vector3 position = transform.position;
        GameObject chatBubble = Instantiate(chatPrefab, position + new Vector3(-0.3f, 2.5f, 0f), Quaternion.identity);
        chatText = chatBubble.GetComponentInChildren<TMP_Text>(); 

        StartCoroutine(StartDialog()); 
    }

    IEnumerator StartDialog()
    {
        foreach(var dialog in dialogSequence)
        {
            chatText.text = dialog; 
            Debug.Log(dialog);
            yield return new WaitForSeconds(chatTime);
        }
        yield return new WaitForSeconds(chatTime);

        Destroy(chatBubble, chatTime); 

        yield return null;
    }

    public string GetInteractText()
    {
        return interactText;
    }

    public Transform GetTransform()
    {
        return transform;
    }

}
