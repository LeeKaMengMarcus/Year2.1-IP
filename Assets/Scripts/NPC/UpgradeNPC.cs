using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeNPC : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray detectPlayer = new Ray(transform.position, Vector3.forward);

        if (Physics.Raycast(detectPlayer, out hit, 100))
        {
            if(hit.collider.tag == "Player")
            {
                GetComponent<DialogueTrigger>().TriggerDialogue();
            }
        }
    }
}
