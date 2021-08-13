/******************************************************************************
Author: Marcus

Name of Class: DialogueManager

Description of Class: Registers the name and dialogue box, then queues up the 
sentences and checks number of sentences.

******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    //Locate chat ui
    public GameObject chatUi;

    //Locate Name box
    public TMP_Text nameText;
    //Locate Dialogue box
    public TMP_Text dialogueText;

    //Queues sentence
    private Queue<string> sentences;

    //Get info from player
    public GameObject playerMovement;
    //Get info from camera
    public GameObject playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        //Gets sentence
        sentences = new Queue<string>();
    }

    //Starts dialogue
    public void StartDialogue (Dialogue dialogue)
    {
        //makes screen not able to move
        playerCamera.GetComponent<MouseLook>().mouseSensitivity = 0f;
        playerMovement.GetComponent<PlayerMovementScript>().speed = 0f;
        playerMovement.GetComponent<PlayerMovementScript>().jumpHeight = 0f;

        //To see chat ui
        chatUi.SetActive(true);

        //Enable cursor
        Cursor.lockState = CursorLockMode.None;

        //register name of npc into text box
        nameText.text = dialogue.name;

        //clear queue for sentence
        sentences.Clear();

        //sentences in the array
        foreach (string sentence in dialogue.sentences)
        {
            //queue next sentence
            sentences.Enqueue(sentence);
        }

        //show next sentence
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //check whether if no sentence
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //register sentence for next queue
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        //check if triggered
        Debug.Log("end of conversation");
        //disable cursor
        Cursor.lockState = CursorLockMode.Locked;
        //disable chat ui
        chatUi.SetActive(false);
        //make player able to move
        playerCamera.GetComponent<MouseLook>().mouseSensitivity = 100f;
        playerMovement.GetComponent<PlayerMovementScript>().speed = 12f;
        playerMovement.GetComponent<PlayerMovementScript>().jumpHeight = 3f;
    }
}
