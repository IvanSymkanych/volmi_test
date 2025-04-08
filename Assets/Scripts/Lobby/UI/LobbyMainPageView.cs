using System.Linq;
using Core.GlobalServices.ConfigService;
using Core.GlobalServices.SaveLoadService;
using Lobby.Controller;
using Lobby.Factory;
using UI;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Lobby.UI
{
    public class LobbyMainPageView : BasePageView
    {
        [SerializeField] private Button playButton;
        [SerializeField] private RectTransform rankContainer;
        
        private ILobbyController _lobbyController;
        private ISaveLoadService _saveLoadService;
        private ILobbyFactory _lobbyFactory;
        private GameConfigsSO _gameConfigs;

        [Inject]
        private void Construct(ILobbyController lobbyController, ISaveLoadService saveLoadService, ILobbyFactory lobbyFactory, GameConfigsSO gameConfigs)
        {
            _lobbyController = lobbyController;
            _saveLoadService = saveLoadService;
            _lobbyFactory = lobbyFactory;
            _gameConfigs = gameConfigs;
        }

        public override void Initialize()
        {
            playButton.onClick.AddListener(OnPlayButtonClicked);
            PopulateRankContainer();
        }

        public override void Dispose() => playButton.onClick.RemoveAllListeners();

        private void OnPlayButtonClicked() => _lobbyController.GoToGameState();

        private void PopulateRankContainer()
        {
            var scores = _saveLoadService.GameSaveModel.scoreList.OrderByDescending(s => s);

            foreach (var score in scores)
            {
                var instance = _lobbyFactory.CreateScoreView(_gameConfigs.ScoreViewPrefab, rankContainer);
                instance.SetScore(score);
            }
        }
    }
}