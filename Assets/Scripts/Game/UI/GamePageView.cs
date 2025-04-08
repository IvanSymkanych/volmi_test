using Game.Controllers;
using TMPro;
using UI;
using UnityEngine;
using VContainer;

namespace Game.UI
{
    public class GamePageView : BasePageView
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        
        private IScoreController _scoreController;

        [Inject]
        private void Construct(IScoreController scoreController)
        {
            _scoreController = scoreController;
        }

        public override void Initialize()
        {
            scoreText.SetText("0");
            _scoreController.OnScoreChange += OnScoreChange;
        }

        public override void Dispose() => _scoreController.OnScoreChange -= OnScoreChange;
        private void OnScoreChange(int value) => scoreText.SetText(value.ToString());
    }
}