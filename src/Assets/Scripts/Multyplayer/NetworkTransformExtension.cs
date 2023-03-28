using System.Collections;
using System.Collections.Generic;
using Unity.Netcode.Components;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkTransformExtension : NetworkTransform
{
	protected override bool OnIsServerAuthoritative()
	{
		return false;
	}
}
