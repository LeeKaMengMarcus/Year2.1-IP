using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableGameObject : MonoBehaviour
{
    public GameObject generator;
    public GameObject generatorText;


    public void GeneratorDetect()
    {
        generatorText.SetActive(true);
    }

    public void NoGeneratorDetect()
    {
        generatorText.SetActive(false);
    }

}
