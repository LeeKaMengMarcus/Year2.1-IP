/******************************************************************************
Author: Marcus

Name of Class: PlayerManager

Description of Class: Keeps track of player.

******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    #region Singleton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;

}
