using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableGameObject : MonoBehaviour
{
    public GameObject generator;
    public GameObject generatorText;
    public GameObject nextSceneText;
    public GameObject dataDetect;

    public void GeneratorDetect()
    {
        generatorText.SetActive(true);
    }

    public void NoGeneratorDetect()
    {
        generatorText.SetActive(false);
    }

    public void NextSceneDetect()
    {
        nextSceneText.SetActive(true);
    }

    public void NoNextSceneDetect()
    {
        nextSceneText.SetActive(false);
    }
    public void DataDetect()
    {
        dataDetect.SetActive(true);
    }
    public void NoDataDetect()
    {
        dataDetect.SetActive(false);
    }
}
