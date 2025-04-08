using System.Threading;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Lobby.Controller
{
    public class LobbyController : ILobbyController , IAsyncStartable
    {
        public async UniTask StartAsync(CancellationToken cancellation)
        {
        }
    }
}