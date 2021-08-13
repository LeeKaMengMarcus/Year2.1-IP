using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public GameObject dataCharacter;
    public GameObject moData;

    public GameObject ogStand;
    public GameObject updatedStand;

    public bool moDaTalked;

    public Animator upgrade;

    public bool isUpgrade = false;
    public bool getUpgrade = false;

    public GameObject upgradeDoor;

    public GameObject swordBlue;

    public Material redSword;

    public GameObject upgradeSword;

    public GameObject hiddenDoor;

    public bool hideKey = false;

    public GameObject key1;
    public GameObject key3;
    public GameObject key2;

    public GameObject cage;

    public GameObject winScreen;

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10))
        {
            if (hit.collider.tag == "NextScene")
            {
                    GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to enter.");
                    GetComponent<InteractableGameObject>().ShowGuide();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        GetComponent<LevelLoader>().LoadNextLevel();
                    }
            }
            else if (hit.collider.tag == "HiddenDoor")
            {
                    GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to unlock.");
                    GetComponent<InteractableGameObject>().ShowGuide();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                    hiddenDoor.SetActive(false);
                    }
            }
            else if (hit.collider.tag == "UnlockCage")
            {
                    GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to unlock.");
                    GetComponent<InteractableGameObject>().ShowGuide();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                    cage.SetActive(false);
                    }
            }
            
            else if (hit.collider.tag == "Escape")
            {
                if(GetComponent<QuestLog>().enemyKilled >= 9){

                    GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to exit.");
                    GetComponent<InteractableGameObject>().ShowGuide();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                    winScreen.SetActive(true);
                    }
                }
            }
            
            else if (hit.collider.tag == "HiddenKey")
            {
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to collect.");
                GetComponent<InteractableGameObject>().ShowGuide();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hideKey = true;
                    GetComponent<QuestLog>().key += 1;
                    GetComponent<QuestLog>().hiddenKey.SetActive(false);
                }
            }
            else if (hit.collider.tag == "Key1")
            {
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to collect.");
                GetComponent<InteractableGameObject>().ShowGuide();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<QuestLog>().key += 1;
                    key1.SetActive(false);
                }
            }
            else if (hit.collider.tag == "Key2")
            {
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to collect.");
                GetComponent<InteractableGameObject>().ShowGuide();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<QuestLog>().key += 1;
                    key2.SetActive(false);
                }
            }
            else if (hit.collider.tag == "Key3")
            {
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to collect.");
                GetComponent<InteractableGameObject>().ShowGuide();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<QuestLog>().key += 1;
                    key3.SetActive(false);
                }
            }


            else if (hit.collider.tag == "DataHouseExit")
            {
                if (GetComponent<QuestLog>().quest1 == true)
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
            else if (hit.collider.tag == "Upgrade" && isUpgrade == false)
            {
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
            else if (hit.collider.tag == "Get" && isUpgrade == true && getUpgrade == false)
            {
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
            
            else if (hit.collider.tag == "UpgradeEntrance")
            {
                if (GetComponent<QuestLog>().enemyKilled >= 6 && moDaTalked == true)
                {
                    GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to Enter.");
                    GetComponent<InteractableGameObject>().ShowGuide();
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        upgradeDoor.SetActive(false);
                    }
                }
            }
            else if (hit.collider.tag == "FortressEntrance")
            {
                if (GetComponent<QuestLog>().enemyKilled >= 6)
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
            else if (hit.collider.tag == "Generator")
            {
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to interact.");
                GetComponent<InteractableGameObject>().ShowGuide();
            }
            else if (hit.collider.tag == "Data" && GetComponent<QuestLog>().quest1 == false)
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
            else if (hit.collider.tag == "Modata" && GetComponent<QuestLog>().quest2 == true)
            {
                GetComponent<InteractableGameObject>().guide.text = ("Press 'E' to talk.");
                GetComponent<InteractableGameObject>().ShowGuide();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GetComponent<InteractableGameObject>().HideGuide();
                    moData.GetComponent<DialogueTrigger>().TriggerDialogue();
                    moDaTalked = true;
                    GetComponent<QuestLog>().quest2 = false;
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
