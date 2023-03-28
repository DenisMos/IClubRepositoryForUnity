using Assets.Scripts.Scene;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UNET;
using UnityEngine;

public class NetworkInitialize : MonoBehaviour
{
    void Start()
    {
        var connect = SceneDataNetwork.HasConnect;
		var manager = FindObjectOfType<NetworkManager>();
		var transport = FindObjectOfType<UNetTransport>();

		if(connect)
        {
            transport.ConnectPort = SceneDataNetwork.Port;
            transport.ConnectAddress = SceneDataNetwork.Ip;
            manager.StartClient();
        }
        else
        {
			transport.ConnectPort = SceneDataNetwork.Port;
			manager.StartHost();
		}
    }
}
