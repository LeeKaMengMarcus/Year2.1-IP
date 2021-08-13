/******************************************************************************
Author: Marcus

Name of Class: interactableGameObject

Description of Class: Enable Ui if object is interactable.

******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class InteractableGameObject : MonoBehaviour
{
    //ui if interactable
    public GameObject guideUi;
    public TMP_Text guide;

    public void ShowGuide()
    {
        guideUi.SetActive(true);
    }
    public void HideGuide()
    {
        guideUi.SetActive(false);
    }
}
