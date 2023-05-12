using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 
using TMPro; 

public class NPCDialog : MonoBehaviour, IInteractable
{

    public List<string> dialogSequence;

    public GameObject chatPrefab;

    public float chatTime; 

    private TMP_Text chatText;
    private GameObject chatBubble;

    public UnityEvent OnInteractionComplete; 

    [SerializeField] private string interactText;



    private void Awake()
    {

    }

    public void Interact(Transform interactorTransform)
    {



        StartCoroutine(StartDialog()); 
    }

    IEnumerator StartDialog()
    {
        foreach(var dialog in dialogSequence)
        {
            Vector3 position = transform.position;
            GameObject chatBubble = Instantiate(chatPrefab, position + new Vector3(-0.3f, 2.5f, 0f), Quaternion.identity);
            chatText = chatBubble.GetComponentInChildren<TMP_Text>();

            chatText.text = dialog; 
            Debug.Log(dialog);
            //yield return new WaitForSeconds(chatTime);
            yield return WaitForKeyPress();
            Destroy(chatBubble.gameObject); 

        }
        yield return new WaitForSeconds(chatTime);

        Destroy(chatBubble, chatTime);
        OnInteractionComplete.Invoke(); 

        yield return null;
    }

    IEnumerator WaitForKeyPress()
    {
        while(!Input.GetKeyDown(KeyCode.C))
        {
            yield return null;
        }
        yield return new WaitForSeconds(1.0f);
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
