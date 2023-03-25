using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Manager : MonoBehaviour
{

    public NetworkManager ManagerNet { get; private set; }

    private void Start()
    {
        
    }


    public void connect()
    {
        ManagerNet.StartHost();
    }
}
