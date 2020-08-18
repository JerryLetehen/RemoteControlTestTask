using System.Threading;
using System.Threading.Tasks;
using UnityEngine.Networking;

namespace Game.Network
{
    public class GameNetwork
    {
        public async Task<string> GetText(string url, CancellationTokenSource token)
        {
            using (var request = UnityWebRequest.Get(url))
            {
                string result = null;
                request.SendWebRequest();

                while (token.IsCancellationRequested == false && request.isDone == false)
                {
                    await Task.Yield();
                }

                if (request.isDone)
                {
                    result = request.downloadHandler.text;
                }

                return result;
            }
        }
    }
}