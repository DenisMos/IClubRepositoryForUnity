using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.Netcode.Transports.UNET;
using UnityEngine;

using UnityEngine.Networking.Options;

[RequireComponent(typeof(NetworkManager), typeof(UNetTransport))]
public class NetworkAdapter : MonoBehaviour
{
	private NetworkManager _manager;

	[SerializeField]
	private int Mode = -1;

	private void Start()
	{
		if(Mode > 0) 
		{
			NetworkOptions.Mode = (byte)Mode;
		}

		_manager = FindObjectOfType<NetworkManager>();

		var transport = _manager.gameObject.GetComponent<UNetTransport>();
		_manager.OnTransportFailure += OnFailure;
		_manager.OnClientDisconnectCallback += OnDis;

		if(_manager == null)
		{
			Debug.LogError($"Не создан объект менеджера сети 'NetworkManager'.");
		}

		var mode = NetworkOptions.Mode;

		switch(mode)
		{
			case 0x00:
				break;
			case 0x01:
				//transport.ConnectAddress = NetworkOptions.IP;
				//transport.ConnectPort = NetworkOptions.Port;
				var status = _manager.StartClient();
				Debug.Log($"start client {status}");
				break;
			case 0x02:
				transport.ConnectAddress = NetworkOptions.IP;
				transport.ConnectPort = NetworkOptions.Port;
				_manager.StartHost();
				break;
			default:
				Debug.LogError($"Неизвестное значение параметра 'mode'.");
				break;
		}
	}

	private void OnDis(ulong obj)
	{
		if(obj == 0)
		{
			Debug.Log($"{obj}: Ошибка подключения.");
		}
	}

	private void OnFailure()
	{
		Debug.Log($"Ошибка.");
	}

	private void OnConnectedToServer()
	{
		Debug.Log($"Подключён к серверу.");
	}
}
