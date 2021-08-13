/******************************************************************************
Author: Marcus

Name of Class: PlayerRaycast

Description of Class: Creates raycast, keeps track of player's timing in
triggering dialogue ui and enabling or disabling objects after interacting.

******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    //info from ai
    public GameObject dataCharacter;
    public GameObject moDaTa;
    public GameObject moData;
    public GameObject player;
    public bool moDaTalked;

    //get game object
    public GameObject ogStand;
    public GameObject updatedStand;
    public GameObject upgradeDoor;
    public GameObject swordBlue;
    public Material redSword;
    public GameObject hiddenDoor;
    public GameObject upgradeSword;
    public GameObject key1;
    public GameObject key3;
    public GameObject key2;
    public GameObject cage;
    public GameObject winScreen;

    //check if upgraded
    public bool isUpgrade = false;
    public bool getUpgrade = false;

    //animation
    public Animator upgrade;

    //check if got key from enemy
    public bool hideKey = false;

    void Update()
    {
        //mouse position
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //info of raycasted object
        RaycastHit hit;
        //sends raycast
        if (Physics.Raycast(ray, out hit, 10))
        {
            //if looking correct at object
            if (hit.collider.tag == "NextScene")
            {
                //show interactable
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to enter.");
                GetComponent<InteractableGameObject>().ShowGuide();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        //load next level
                        GetComponent<LevelLoader>().LoadNextLevel();
                    }
            }
            //if looking correct at object
            else if (hit.collider.tag == "HiddenDoor")
            {
                //show interactable
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to unlock.");
                    GetComponent<InteractableGameObject>().ShowGuide();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                    hiddenDoor.SetActive(false);
                    }
            }
            //if looking correct at object
            else if (hit.collider.tag == "UnlockCage")
            {
                //show interactable
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to unlock.");
                    GetComponent<InteractableGameObject>().ShowGuide();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                    cage.SetActive(false);
                    }
            }
            //if looking correct at object
            else if (hit.collider.tag == "Escape")
            {
                if(GetComponent<QuestLog>().enemyKilled >= 9){
                    //show interactable
                    GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to exit.");
                    GetComponent<InteractableGameObject>().ShowGuide();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                    winScreen.SetActive(true);
                    }
                }
            }
            //if looking correct at object
            else if (hit.collider.tag == "HiddenKey")
            {
                //show interactable
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to collect.");
                GetComponent<InteractableGameObject>().ShowGuide();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hideKey = true;
                    GetComponent<QuestLog>().key += 1;
                    GetComponent<QuestLog>().hiddenKey.SetActive(false);
                }
            }
            //if looking correct at object
            else if (hit.collider.tag == "Key1")
            {
                //show interactable
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to collect.");
                GetComponent<InteractableGameObject>().ShowGuide();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<QuestLog>().key += 1;
                    key1.SetActive(false);
                }
            }
            //if looking correct at object
            else if (hit.collider.tag == "Key2")
            {
                //show interactable
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to collect.");
                GetComponent<InteractableGameObject>().ShowGuide();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<QuestLog>().key += 1;
                    key2.SetActive(false);
                }
            }
            //if looking correct at object
            else if (hit.collider.tag == "Key3")
            {
                //show interactable
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to collect.");
                GetComponent<InteractableGameObject>().ShowGuide();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<QuestLog>().key += 1;
                    key3.SetActive(false);
                }
            }

            //if looking correct at object
            else if (hit.collider.tag == "DataHouseExit")
            {
                if (GetComponent<QuestLog>().quest1 == true)
                {
                    //show interactable
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
            //if looking correct at object with conditon
            else if (hit.collider.tag == "Upgrade" && isUpgrade == false)
            {
                //show interactable
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to interact.");
                GetComponent<InteractableGameObject>().ShowGuide();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    swordBlue.SetActive(false);
                    upgradeSword.SetActive(true);
                    upgrade.SetTrigger("upgrade");
                    swordBlue.GetComponent<MeshRenderer>().material = redSword;
                    isUpgrade = true;
                    ogStand.SetActive(false);
                    updatedStand.SetActive(true);
                }
            }
            //if looking correct at object with conditon
            else if (hit.collider.tag == "Get" && isUpgrade == true && getUpgrade == false)
            {
                //show interactable
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to obtain sword.");
                GetComponent<InteractableGameObject>().ShowGuide();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    upgradeSword.SetActive(false);
                    swordBlue.SetActive(true);
                    getUpgrade = true;
                    GetComponent<QuestLog>().quest2 = false;
                    GetComponent<QuestLog>().quest3 = true;
                }
            }
            //if looking correct at object
            else if (hit.collider.tag == "UpgradeEntrance")
            {
                if (GetComponent<QuestLog>().enemyKilled >= 6 && moDaTalked == true)
                {
                    //show interactable
                    GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to Enter.");
                    GetComponent<InteractableGameObject>().ShowGuide();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        upgradeDoor.SetActive(false);
                    }
                }
            }
            //if looking correct at object
            else if (hit.collider.tag == "FortressEntrance")
            {
                if (GetComponent<QuestLog>().enemyKilled >= 6)
                {
                    //show interactable
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
            //if looking correct at object
            else if (hit.collider.tag == "Generator")
            {
                //show interactable
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to interact.");
                GetComponent<InteractableGameObject>().ShowGuide();
            }
            //if looking correct at object with conditon
            else if (hit.collider.tag == "Data" && GetComponent<QuestLog>().quest1 == false)
            {
                //show interactable
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to talk.");
                GetComponent<InteractableGameObject>().ShowGuide();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<InteractableGameObject>().HideGuide();
                    dataCharacter.transform.LookAt(player.transform);
                    dataCharacter.GetComponent<DialogueTrigger>().TriggerDialogue();
                    GetComponent<QuestLog>().quest1 = true;
                }
            }
            //if looking correct at object with conditon
            else if (hit.collider.tag == "Modata" && GetComponent<QuestLog>().quest2 == true)
            {
                //show interactable
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to talk.");
                GetComponent<InteractableGameObject>().ShowGuide();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<InteractableGameObject>().HideGuide();
                    moDaTa.transform.LookAt(player.transform);
                    moData.GetComponent<DialogueTrigger>().TriggerDialogue();
                    moDaTalked = true;
                    GetComponent<QuestLog>().quest2 = false;
                }
            }
            //if looking correct at object
            else if (hit.collider.tag == "Computer")
            {
                //show interactable
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
