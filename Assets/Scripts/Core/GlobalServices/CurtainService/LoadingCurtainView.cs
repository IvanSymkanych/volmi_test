using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Core.GlobalServices.CurtainService
{
    [RequireComponent(typeof(CanvasGroup))]
    public class LoadingCurtainView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI loadingText;
        
        private CanvasGroup _canvasGroup;

        public void Initialize()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            DontDestroyOnLoad(gameObject);
        }

        public void Show(bool animate = true)
        {
            gameObject.SetActive(true);
            ToggleCanvasGroup(true);
            
            if (animate)
                _canvasGroup.DOFade(1, 0.5f).From(0);
        }

        public void Hide(bool animate = true)
        {
            ToggleCanvasGroup(false);
            
            if (animate)
                _canvasGroup.DOFade(0, 0.5f).From(1).OnComplete((() => gameObject.SetActive(false)));
            else
                gameObject.SetActive(false);
        }

        private void ToggleCanvasGroup(bool value)
        {
            _canvasGroup.interactable = value;
            _canvasGroup.blocksRaycasts = value;
        }
    }
}