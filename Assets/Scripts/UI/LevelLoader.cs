/******************************************************************************
Author: Marcus

Name of Class: LevelLoader

Description of Class: Plays level loading animation and loads next level.

******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //set animator
    public Animator transition;
    //time for transition
    public float transistionTime = 1f;
    //set camera
    public GameObject cameraScript;
    //get player info
    public GameObject player;


    public void LoadNextLevel()
    {
        //if player is referenced
        if(player == null)
        {
            //load next scene
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        else
        {

            //disable player
            player.GetComponent<PlayerMovementScript>().speed = 0f;
            player.GetComponent<PlayerMovementScript>().jumpHeight = 0f;
            cameraScript.GetComponent<MouseLook>().mouseSensitivity = 0f;
            //load scene
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transistionTime);

        //Load scene
        SceneManager.LoadScene(levelIndex);



    }
}
