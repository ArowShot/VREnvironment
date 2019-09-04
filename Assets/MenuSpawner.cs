using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MenuSpawner : MonoBehaviour
{
    public SteamVR_Action_Boolean spawnMenuAction;
    public GameObject menu;
    public Transform headCamera;

    public Transform controllerRight;
    public Transform controllerLeft;
    void Start()
    {
        spawnMenuAction.onStateDown += SpawnMenu;
    }

    void SpawnMenu(SteamVR_Action_Boolean action, SteamVR_Input_Sources source)
    {
        if (menu.activeInHierarchy)
        {
            menu.SetActive(false);
        }
        else
        {
            menu.SetActive(true);
            /*if (source == SteamVR_Input_Sources.LeftHand)
            {
                menu.transform.position = transform.position;
            } else if (source == SteamVR_Input_Sources.RightHand)
            {
                menu.transform.position = controllerRight.position;
            }*/
            var position = transform.position;
            menu.transform.position = position;
            menu.transform.LookAt(2 * position - headCamera.position);
        }
    }
}
