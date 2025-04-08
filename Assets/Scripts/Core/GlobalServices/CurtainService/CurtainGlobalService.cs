using Core.GlobalServices.ConfigService;
using UnityEngine;

namespace Core.GlobalServices.CurtainService
{
    public class CurtainGlobalService: ICurtainGlobalService
    {
        private readonly GameConfigsSO _gameConfigs;
        private LoadingCurtainView _view;

        public CurtainGlobalService(GameConfigsSO gameConfigs) => _gameConfigs = gameConfigs;

        public void Initialize()
        {
           _view = Object.Instantiate(_gameConfigs.LoadingCurtainViewPrefab);
           _view.Initialize();
        }

        public void Show(bool animate = true) => _view.Show(animate);
        public void Hide(bool animate = true) => _view.Hide(animate);
    }
}