using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using Unity.Netcode.Components;

namespace Assets.Scripts.Network
{
	public class NetworkTransformExtansion : NetworkTransform
	{
		/// <summary>Переопределение оверайда.</summary>
		/// <returns></returns>
		protected override bool OnIsServerAuthoritative()
		{
			return false;
		}
	}
}
