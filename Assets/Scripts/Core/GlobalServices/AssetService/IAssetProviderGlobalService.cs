using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Core.GlobalServices.AssetService
{
    public interface IAssetProviderGlobalService
    {
        UniTask InitializeAsync();
        UniTask<TAsset> Load<TAsset>(string key) where TAsset : class;
        UniTask WarmupAssetsByLabel(string label);
        UniTask ReleaseAssetsByLabel(string label);
        T LoadAssetFromResources<T>(string path) where T : UnityEngine.Object;
    }
}