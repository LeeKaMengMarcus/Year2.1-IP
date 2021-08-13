using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestLog : MonoBehaviour
{
    public Animator popUp;

    public bool quest1;
    public bool quest2;
    public bool quest3;

    public GameObject questUi;

    public TMP_Text questInfo;

    public int enemyKilled;

    private void Start()
    {
        enemyKilled = 0;
    }

    private void Update()
    {
        Quest1();
        Quest2();
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
}
