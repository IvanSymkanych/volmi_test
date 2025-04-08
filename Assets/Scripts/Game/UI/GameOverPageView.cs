using Game.Controllers;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.UI
{
    public class GameOverPageView : BasePageView
    {
        [SerializeField] private Button goToLobbyButton;
        [SerializeField] private TextMeshProUGUI scoreTitleText;
        [SerializeField] private TextMeshProUGUI scoreText;

        private IGameController _gameController;
        private IScoreController _scoreController;

        [Inject]
        private void Construct (IGameController gameController, IScoreController scoreController)
        {
            _gameController = gameController;
            _scoreController = scoreController;
        }

        public override void Initialize()
        {
            goToLobbyButton.onClick.AddListener(GoToLobbyButtonOnClick);
            var titleText = _scoreController.Score > _scoreController.HighScore ? "New High Score" : "Score";
            scoreTitleText.SetText(titleText);
            scoreText.SetText(_scoreController.Score.ToString());
        }

        public override void Dispose() => goToLobbyButton.onClick.RemoveAllListeners();
        private void GoToLobbyButtonOnClick() => _gameController.GoToLobby();
    }
}