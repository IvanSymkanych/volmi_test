using UnityEngine;

namespace UI
{
    public abstract class BasePageView : MonoBehaviour
    {
        public abstract void Initialize();
        public abstract void Dispose();
        public void Show() => gameObject.SetActive(true);
        public void Hide() => gameObject.SetActive(false);
    }
}