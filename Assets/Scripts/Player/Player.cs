using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject menuUi;
    public GameObject questUi;
    public GameObject computerUi;

    public GameObject deathScreen;

    public GameObject cameraScript;

    public int maxHealth = 100;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (questUi.activeSelf == true)
            {
                questUi.SetActive(false);
                menuUi.SetActive(true);
            }
            else if(menuUi.activeSelf == true)
            {
                menuUi.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                menuUi.SetActive(true);
            }
        }
        Die();
    }

    public void ComputerMenu()
    {
        computerUi.SetActive(true);
    }
    public void CloseComputerMenu()
    {
        computerUi.SetActive(false);
    }

    public void Die()
    {
        if (currentHealth <= 0)
        {
            GetComponent<PlayerMovementScript>().speed = 0f;
            GetComponent<PlayerMovementScript>().jumpHeight = 0f;
            cameraScript.GetComponent<MouseLook>().mouseSensitivity = 0f;
            deathScreen.SetActive(true);
        }
    }
}


