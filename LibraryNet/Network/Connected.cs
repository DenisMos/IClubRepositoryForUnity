using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Connected : MonoBehaviour
{
    private NetworkManager NetworkManager;

    // Start is called before the first frame update
    void Start()
    {
        NetworkManager= GetComponent<NetworkManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        { 
            NetworkManager.StartClient();
        }
		if(Input.GetKeyDown(KeyCode.L))
		{
			NetworkManager.StartHost();
		}
	}
}
