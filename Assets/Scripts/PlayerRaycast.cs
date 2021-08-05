using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public GameObject dataCharacter;

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            if(hit.collider.tag == "NextScene")
            {
                GetComponent<InteractableGameObject>().NextSceneDetect();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<LevelLoader>().LoadNextLevel();
                }
            }
            else if(hit.collider.tag == "Generator")
            {
                GetComponent<InteractableGameObject>().GeneratorDetect();
            }
            else if(hit.collider.tag == "Data" && GetComponent<QuestLog>().quest1 == false)
            {
                GetComponent<InteractableGameObject>().DataDetect();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<InteractableGameObject>().NoDataDetect();
                    dataCharacter.GetComponent<DialogueTrigger>().TriggerDialogue();
                    GetComponent<QuestLog>().quest1 = true;
                }
            }
            else
            {
                GetComponent<InteractableGameObject>().NoGeneratorDetect();
                GetComponent<InteractableGameObject>().NoNextSceneDetect();
                GetComponent<InteractableGameObject>().NoDataDetect();
            }
        }
    }
}
