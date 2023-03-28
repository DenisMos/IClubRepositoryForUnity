using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Scene
{
	public static class SceneDataNetwork
	{
		public static string Ip { get; set; } = "127.0.0.1";

		public static int Port { get; set; } = 7777;

		public static bool HasConnect { get; set; } = false;
	}
}
