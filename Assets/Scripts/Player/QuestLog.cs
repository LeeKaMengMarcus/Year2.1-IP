using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestLog : MonoBehaviour
{
    public bool quest1;
    public bool quest2;
    public bool quest3;

    public GameObject questUi;

    public TMP_Text questInfo;

    private void Start()
    {
        quest1 = false;
        quest2 = false;
        quest3 = false;
    }

    public void Quest1()
    {
        if (quest1 == true)
        {

        }
    }

}
