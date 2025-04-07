using Core.GlobalServices.AssetService;
using UnityEngine;

namespace Core.GlobalServices.CurtainService
{
    public class CurtainGlobalService: ICurtainGlobalService
    {
        private readonly IAssetProviderGlobalService _assetProviderGlobalService;
        private LoadingCurtainView _view;

        public CurtainGlobalService(IAssetProviderGlobalService assetProviderGlobalService)
        {
            _assetProviderGlobalService = assetProviderGlobalService;
        }
        
        public void Initialize()
        {
           var prefab = _assetProviderGlobalService.LoadAssetFromResources<LoadingCurtainView>(AssetAddress.LoadingCurtainViewPath);
           _view = Object.Instantiate(prefab);
           _view.Initialize();
        }

        public void Show(bool animate = true) => _view.Show(animate);
        public void Hide(bool animate = true) => _view.Hide(animate);
    }
}