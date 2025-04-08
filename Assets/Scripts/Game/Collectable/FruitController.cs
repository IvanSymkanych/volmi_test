using Core.GlobalServices.ConfigService.Config;
using Game.Controllers;
using UnityEngine;
using VContainer;

namespace Game.Collectable
{
    public class FruitController : MonoBehaviour ,ICollectable
    {
        [Inject] private IScoreController _scoreController;

        private FruitConfig _fruitConfig;
        
        public void Initialize(FruitConfig fruitConfig)
        {
            _fruitConfig = fruitConfig;
        }
        
        public void Pickup()
        {
            _scoreController.AddScore(_fruitConfig.score);
            Destroy(gameObject);
        }
    }
}