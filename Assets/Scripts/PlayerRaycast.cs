using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if(hit.collider.tag == "generator")
            {
                GetComponent<InteractableGameObject>().GeneratorDetect();
            }
            else
            {
                GetComponent<InteractableGameObject>().NoGeneratorDetect();
            }
        }
    }
}
