/******************************************************************************
Author: Marcus

Name of Class: Dialogue

Description of Class: Set name and dialogue for the UIs.

******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    //Name of Npc
    public string name;

    //Size of dialogue box
    [TextArea(3, 120)]
    //storing sentence
    public string[] sentences;
    
}
