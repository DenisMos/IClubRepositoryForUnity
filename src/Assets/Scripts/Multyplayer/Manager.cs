using UnityEngine;
using Unity.Netcode;

public class Manager : MonoBehaviour
{

	public NetworkManager ManagerNet;

	private void Start()
	{
		if(Input.GetKeyDown(KeyCode.LeftShift))
		{ 
			
		}

		if(Input.GetKeyUp(KeyCode.LeftShift))
		{

		}

		if(Input.GetButtonDown("Shift"))
		{ 
			
		}
	}

	public void createServer()
	{
		ManagerNet.StartHost();
	}

	public void connectToOthers()
	{
		ManagerNet.StartClient();
	}
}
