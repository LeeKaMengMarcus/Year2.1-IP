using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableGameObject : MonoBehaviour
{
    public GameObject generator;
    public GameObject generatorText;
    public GameObject nextSceneText;

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
}
