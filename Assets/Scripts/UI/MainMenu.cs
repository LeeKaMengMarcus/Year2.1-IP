/******************************************************************************
Author: Marcus

Name of Class: MainMenu

Description of Class: Enable play and quit aplplication function for buttons.

******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        //load next scene
        GetComponent<LevelLoader>().LoadNextLevel();
    }
    public void QuitButton()
    {
        //quit game
        Application.Quit();
    }
}
