using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartGuide : MonoBehaviour
{
    public bool inputW;
    public bool inputA;
    public bool inputS;
    public bool inputD;
    public bool inputEsc;

    public GameObject startUi;
    public TMP_Text guideUi;

    // Start is called before the first frame update
    void Start()
    {
        inputW = false;
        inputA = false;
        inputS = false;
        inputD = false;
        inputEsc = false;
        startUi.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        InputTrue();
        if (inputW == false && inputA == false && inputS == false && inputD == false && inputEsc == false)
        {
            guideUi.text = ("Press 'W A S D' to move around.");
        }
        else if (inputEsc == false)
        {
            guideUi.text = ("Press 'Esc' to open menu.");
        }
        else
        {
            startUi.SetActive(false);
        }
    }
    void InputTrue()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            inputW = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            inputA = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            inputS = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            inputD = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inputEsc = true;
        }
    }
}
