namespace UnityEngine.Networking.Options {

	/// <summary>Описывает схему подключения.</summary>
	public static class NetworkOptions
	{
		public static string IP { get; set; } = "127.0.0.1";

		public static int Port { get; set; } = 7777;

		/// <summary>2 - host, 1 - client, 0 - off-line</summary>
		public static byte Mode { get; set; } = 0;
	}
}
