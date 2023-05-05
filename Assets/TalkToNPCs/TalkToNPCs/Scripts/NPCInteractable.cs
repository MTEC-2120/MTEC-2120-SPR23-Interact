using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCInteractable : MonoBehaviour, IInteractable {

    [SerializeField] private string interactText;
    [SerializeField] private GameObject chatBubble;
    private TMP_Text chatText;

    private Animator animator;
    private NPCHeadLookAt npcHeadLookAt;

    private void Awake() {
        animator = GetComponent<Animator>();
        npcHeadLookAt = GetComponent<NPCHeadLookAt>();
    }

    public void Interact(Transform interactorTransform) {


        Vector3 position = transform.position;
        GameObject go = Instantiate(chatBubble, position + new Vector3(-0.3f, 2.5f, 0f), Quaternion.identity);
        chatText = go.GetComponentInChildren<TMP_Text>();
        chatText.text = "Hello there!";

        Destroy(go, 6f); 
        //animator.SetTrigger("Talk");

        float playerHeight = 1.7f;
        npcHeadLookAt.LookAtPosition(interactorTransform.position + Vector3.up * playerHeight);
    }

    public string GetInteractText() {
        return interactText;
    }

    public Transform GetTransform() {
        return transform;
    }

}