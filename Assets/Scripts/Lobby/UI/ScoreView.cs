using TMPro;
using UnityEngine;

namespace Lobby.UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        
        public void SetScore(int score) => scoreText.SetText(score.ToString());
    }
}