using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour
{

    public GameObject FPS;

    public override void OnStartLocalPlayer()
    {
        GetComponent<playerMovement>().enabled = true;
        GetComponent<Profile>().enabled = true;
        GetComponent<GunSystem>().enabled = true;
        FPS.SetActive(true);
    }
}
