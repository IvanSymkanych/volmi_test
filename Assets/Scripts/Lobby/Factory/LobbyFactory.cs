using Core.GlobalServices.ConfigService;
using Lobby.UI;
using UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Lobby.Factory
{
    public sealed class LobbyFactory : ILobbyFactory
    {
        private readonly GameConfigsSO _configs;
        private readonly IObjectResolver _objectResolver;

        public LobbyFactory(GameConfigsSO configs, IObjectResolver objectResolver)
        {
            _configs = configs;
            _objectResolver = objectResolver;
        }
        
        public BasePageView CreatePage(BasePageView pagePrefab)
        {
            var instance = Object.Instantiate(pagePrefab);
            instance.Hide();
            _objectResolver.InjectGameObject(instance.gameObject);
            return instance;
        }

        public ScoreView CreateScoreView(ScoreView prefab, RectTransform parent)
        {
            var instance = Object.Instantiate(prefab, parent);
            _objectResolver.InjectGameObject(instance.gameObject);
            return instance;
        }
    }
}