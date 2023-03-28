using UnityEngine;
using Unity.Netcode;

public class Manager : MonoBehaviour
{

	public NetworkManager ManagerNet;

	private void Start()
	{
		
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
