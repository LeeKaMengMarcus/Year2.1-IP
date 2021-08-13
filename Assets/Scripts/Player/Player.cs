/******************************************************************************
Author: Marcus

Name of Class: Player

Description of Class: Checks quest and stats of player.

******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //get ui
    public GameObject menuUi;
    public GameObject questUi;
    public GameObject computerUi;

    public GameObject deathScreen;

    //get camera info
    public GameObject cameraScript;


    //set health and capacity
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        //set health and capacity
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(currentHealth);
        //open menu
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
            //disable palyer
            GetComponent<PlayerMovementScript>().speed = 0f;
            GetComponent<PlayerMovementScript>().jumpHeight = 0f;
            cameraScript.GetComponent<MouseLook>().mouseSensitivity = 0f;
            //enable death screen
            deathScreen.SetActive(true);
        }
    }
}


