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
        if (Physics.Raycast(ray, out hit, 10))
        {
            if(hit.collider.tag == "DataHouseExit")
            {
                if(GetComponent<QuestLog>().quest1 == true)
                {
                    GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to Exit.");
                    GetComponent<InteractableGameObject>().ShowGuide();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        GetComponent<LevelLoader>().LoadNextLevel();
                    }
                }
                else
                {
                    GetComponent<InteractableGameObject>().guide.text = ("Talk to 'Data' first.");
                    GetComponent<InteractableGameObject>().ShowGuide();
                }
            }
            else if(hit.collider.tag == "FortressEntrance")
            {
                if(GetComponent<QuestLog>().enemyKilled >= 6)
                {
                    GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to Enter.");
                    GetComponent<InteractableGameObject>().ShowGuide();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        GetComponent<LevelLoader>().LoadNextLevel();
                    }
                }
                else
                {
                    GetComponent<InteractableGameObject>().guide.text = ("Defeat all the enemies.");
                    GetComponent<InteractableGameObject>().ShowGuide();
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
