using Lobby.UI;
using UI;
using UnityEngine;

namespace Lobby.Factory
{
    public interface ILobbyFactory
    {
        BasePageView CreatePage(BasePageView pagePrefab);
        ScoreView CreateScoreView(ScoreView prefab, RectTransform parent);
    }
}