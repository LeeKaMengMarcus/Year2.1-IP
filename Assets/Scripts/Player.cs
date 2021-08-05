using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject menuUi;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(menuUi.activeSelf == true)
            {
                menuUi.SetActive(false);
            }
            else
            {
                menuUi.SetActive(true);
            }
        }
    }
}
