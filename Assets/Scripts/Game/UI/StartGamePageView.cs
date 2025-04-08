using Game.Controllers;
using UI;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.UI
{
    public class StartGamePageView : BasePageView
    {
        [SerializeField] private Button startGameButton; 
        
        private IGameController _gameController;

        [Inject]
        private void Construct(IGameController gameController)
        {
            _gameController = gameController;
        }

        public override void Initialize() => startGameButton.onClick.AddListener(StartGameButtonClicked);
        
        public override void Dispose() => startGameButton.onClick.RemoveAllListeners(); 
        private void StartGameButtonClicked() => _gameController.StartGame();
    }
}