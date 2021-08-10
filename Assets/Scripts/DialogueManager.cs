using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject chatUi;

    public TMP_Text nameText;
    public TMP_Text dialogueText;

    private Queue<string> sentences;

    public GameObject playerMovement;
    public GameObject playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        playerCamera.GetComponent<MouseLook>().mouseSensitivity = 0f;
        playerMovement.GetComponent<PlayerMovementScript>().speed = 0f;
        playerMovement.GetComponent<PlayerMovementScript>().jumpHeight = 0f;
        chatUi.SetActive(true);

        Cursor.lockState = CursorLockMode.None;

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("end of conversation");
        Cursor.lockState = CursorLockMode.Locked;
        chatUi.SetActive(false);
        playerCamera.GetComponent<MouseLook>().mouseSensitivity = 100f;
        playerMovement.GetComponent<PlayerMovementScript>().speed = 12f;
        playerMovement.GetComponent<PlayerMovementScript>().jumpHeight = 3f;
    }
}
