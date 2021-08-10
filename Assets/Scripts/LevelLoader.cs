using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transistionTime = 1f;

    public GameObject cameraScript;


    public void LoadNextLevel()
    {
        GetComponent<PlayerMovementScript>().speed = 0f;
        GetComponent<PlayerMovementScript>().jumpHeight = 0f;
        cameraScript.GetComponent<MouseLook>().mouseSensitivity = 0f;
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
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
