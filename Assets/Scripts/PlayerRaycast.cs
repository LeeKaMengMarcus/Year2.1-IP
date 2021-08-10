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
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to enter.");
                GetComponent<InteractableGameObject>().ShowGuide();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<LevelLoader>().LoadNextLevel();
                }
            }
            else if(hit.collider.tag == "Generator")
            {
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to interact.");
                GetComponent<InteractableGameObject>().ShowGuide();
            }
            else if(hit.collider.tag == "Data" && GetComponent<QuestLog>().quest1 == false)
            {
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to talk.");
                GetComponent<InteractableGameObject>().ShowGuide();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<InteractableGameObject>().HideGuide();
                    dataCharacter.GetComponent<DialogueTrigger>().TriggerDialogue();
                    GetComponent<QuestLog>().quest1 = true;
                }
            }
            else if(hit.collider.tag == "Computer")
            {
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to view.");
                GetComponent<InteractableGameObject>().ShowGuide();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Cursor.lockState = CursorLockMode.None;
                    GetComponent<Player>().ComputerMenu();
                }
            }
            else
            {
                GetComponent<InteractableGameObject>().HideGuide();

            }
        }
    }
}
