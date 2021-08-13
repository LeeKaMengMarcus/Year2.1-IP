/******************************************************************************
Author: Kah Min

Name of Class: QuestNpc

Description of Class: Detects player when enter certain range and trigger
dialogue.

******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QuestNpc : MonoBehaviour
{

    //get Ui
    public GameObject chatUi;

    private void Update()
    {
        //ray cast hit info
        RaycastHit hit;
        //raycast direction
        Ray spotRay = new Ray(transform.position, Vector3.forward);
        //sends raycast
        if (Physics.Raycast(spotRay, out hit, 10))
        {
            //enable Ui
            chatUi.SetActive(true);
            //Trigger dialogue
            GetComponent<DialogueTrigger>().TriggerDialogue();
            //disable this script to not repeat
            this.enabled = false;
        }
    }
}
