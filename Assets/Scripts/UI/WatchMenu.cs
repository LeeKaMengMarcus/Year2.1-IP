using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WatchMenu : MonoBehaviour
{
    public Animator transition;

    public float transistionTime = 1f;

    public GameObject menuUi;

    public GameObject cameraScript;

    public GameObject player;

    public int build;

    // Start is called before the first frame update
    void Start()
    {
        build = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        menuUi.SetActive(false);
    }

    public void LoadMainMenu()
    {
        player.GetComponent<PlayerMovementScript>().speed = 0f;
        player.GetComponent<PlayerMovementScript>().jumpHeight = 0f;
        cameraScript.GetComponent<MouseLook>().mouseSensitivity = 0f;
        StartCoroutine(LoadMenu(SceneManager.GetActiveScene().buildIndex - build));
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
