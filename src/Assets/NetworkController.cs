using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UNET;
using UnityEngine;

public class NetworkController : MonoBehaviour
{
    public NetworkManager NetworkManager;
    public UNetTransport Net;

	// Start is called before the first frame update
	void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            NetworkManager.StartHost();
        }
		if(Input.GetKeyDown(KeyCode.P))
		{
			Debug.Log($"{Net.ConnectAddress}");
			NetworkManager.StartClient();
		}
	}
}
