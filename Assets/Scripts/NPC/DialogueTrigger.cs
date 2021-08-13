/******************************************************************************
Author: Marcus

Name of Class: DialogueTrigger

Description of Class: To retrieve and trigger the dialogue.

******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //get name and sentences
    public Dialogue dialogue;

    //trigger the chat
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
