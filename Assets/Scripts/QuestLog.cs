using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLog : MonoBehaviour
{
    public bool quest1;
    public bool quest2;
    public bool quest3;

    private void Awake()
    {
        quest1 = false;
        quest2 = false;
        quest3 = false;
    }

}
