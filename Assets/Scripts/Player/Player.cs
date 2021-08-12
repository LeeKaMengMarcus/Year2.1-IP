using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject menuUi;
    public GameObject computerUi;

    public int maxHealth = 100;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(menuUi.activeSelf == true)
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
    }

    public void ComputerMenu()
    {
        computerUi.SetActive(true);
    }
    public void CloseComputerMenu()
    {
        computerUi.SetActive(false);
    }
}


