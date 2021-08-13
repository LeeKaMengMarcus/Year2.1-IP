/******************************************************************************
Author: Marcus

Name of Class: WatchMenu

Description of Class: Opens up watch Menu Ui for player to use, able to quit to
main menu, view quest and resume game.

******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WatchMenu : MonoBehaviour
{
    // get animation
    public Animator transition;

    //set duration
    public float transistionTime = 1f;

    //get ui
    public GameObject menuUi;
    public GameObject questUi;

    //get info
    public GameObject cameraScript;
    public GameObject player;

    //set integer
    public int build;

    // Start is called before the first frame update
    void Start()
    {
        //set to current build level
        build = SceneManager.GetActiveScene().buildIndex;
    }

    public void ResumeGame()
    {
        //disable cursor
        Cursor.lockState = CursorLockMode.Locked;
        //disable menu
        menuUi.SetActive(false);
    }

    public void LoadMainMenu()
    {
        //disable player movement
        player.GetComponent<PlayerMovementScript>().speed = 0f;
        player.GetComponent<PlayerMovementScript>().jumpHeight = 0f;
        cameraScript.GetComponent<MouseLook>().mouseSensitivity = 0f;
        //set buildindex to 0
        StartCoroutine(LoadMenu(SceneManager.GetActiveScene().buildIndex - build));
    }

    public void OpenNote()
    {
        menuUi.SetActive(false);
        questUi.SetActive(true);
    }

    public void BackToWatch()
    {
        questUi.SetActive(false);
        menuUi.SetActive(true);
    }

    IEnumerator LoadMenu(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transistionTime);

        //Load scene
        SceneManager.LoadScene(levelIndex);
    }

}
