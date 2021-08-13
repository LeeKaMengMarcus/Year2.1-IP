using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transistionTime = 1f;

    public GameObject cameraScript;

    public GameObject player;


    public void LoadNextLevel()
    {
        if(player == null)
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        else
        {
            player.GetComponent<PlayerMovementScript>().speed = 0f;
            player.GetComponent<PlayerMovementScript>().jumpHeight = 0f;
            cameraScript.GetComponent<MouseLook>().mouseSensitivity = 0f;
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
