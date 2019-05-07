using KeePass.Plugins;

namespace KeePassQuery
{
	public class KeePassQueryExt : Plugin
	{
		//public override string UpdateUrl => ""; //TODO

		private IPluginHost _pluginHost;

		public override bool Initialize(IPluginHost host)
		{
			if (host == null) return false;
			_pluginHost = host;

			return true;
		}

		public override void Terminate()
		{
			base.Terminate();
		}
	}
}
