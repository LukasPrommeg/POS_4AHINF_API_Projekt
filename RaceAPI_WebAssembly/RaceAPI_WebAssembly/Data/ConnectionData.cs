using System.Xml.Linq;

namespace RaceAPI_WebAssembly.Data
{
    public class ConnectionData
    {
        private string apiURL;
        public string url
		{
			get { return apiURL; }
			set
			{
				apiURL = value;
				raiseURLChangedEvent();
			}
		}

		public event EventHandler urlChanged;
		public event EventHandler connectingFinished;

		private void raiseURLChangedEvent()
		{
			urlChanged?.Invoke(this, null);
		}
		public void finishedConnecting()
		{
			connectingFinished?.Invoke(this, null);
		}
    }
}
