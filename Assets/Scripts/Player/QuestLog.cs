using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestLog : MonoBehaviour
{
    //public Animator popUp;

    public bool quest1;
    public bool quest2;
    public bool quest3;

    public int key;

    public GameObject questUi;

    public GameObject hiddenKey;

    public TMP_Text questInfo;

    public bool hideDoor;

    public int enemyKilled;

    private void Start()
    {
        
    }

    private void Update()
    {
        Quest1();
        Quest2();
        Quest3();
    }

    public void Quest1()
    {
        if (quest1 == true)
        {
            questInfo.text = ("Defeat enemy: " + enemyKilled + "/6");
            if (enemyKilled >= 6)
            {
                quest2 = true;
                quest1 = false;
            }
        }
    }

    public void Quest2()
    {
        if (quest2 == true)
        {
            questInfo.text = ("Enter building.");
        }
    }

    public void Quest3()
    {
        if (quest3 == true)
        {
            questInfo.text = ("Defeat enemies and find key to unlock secret room.");
            if (enemyKilled >= 6 && GetComponent<PlayerRaycast>().hideKey==false)
            {
                hiddenKey.SetActive(true);
            }
            if (key >= 4)
            {
                hideDoor = true;
            }
        }
    }
}
