/******************************************************************************
Author: Marcus

Name of Class: QuestLog

Description of Class: Checks quest and keep tracks of points.

******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestLog : MonoBehaviour
{
    
    //check for quest
    public bool quest1;
    public bool quest2;
    public bool quest3;

    //check point
    public int key;
    public int enemyKilled;

    //get ui
    public GameObject questUi;
    public TMP_Text questInfo;

    //get game object
    public GameObject hiddenKey;

    //check if able to hide
    public bool hideDoor;


    private void Update()
    {
        Quest1();
        Quest2();
        Quest3();
    }

    public void Quest1()
    {
        //check if quest available
        if (quest1 == true)
        {
            //change quest info
            questInfo.text = ("Defeat enemy: " + enemyKilled + "/6");
            //check if achieved
            if (enemyKilled >= 6)
            {
                quest2 = true;
                quest1 = false;
            }
        }
    }

    public void Quest2()
    {
        //check if quest available
        if (quest2 == true)
        {
            //change quest info
            questInfo.text = ("Enter building.");
        }
    }

    public void Quest3()
    {
        //check if quest available
        if (quest3 == true)
        {
            //change quest info
            questInfo.text = ("Defeat enemies and find key to unlock secret room.");
            //check if achieved
            if (enemyKilled >= 6 && GetComponent<PlayerRaycast>().hideKey==false)
            {
                hiddenKey.SetActive(true);
            }
            //check if achieved
            if (key >= 4)
            {
                hideDoor = true;
            }
        }
    }
}
