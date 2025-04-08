using System;
using Game.Collectable;

namespace Core.GlobalServices.ConfigService.Config
{
    [Serializable]
    public struct FruitConfig
    {
        public int score;
        public int spawnChanceWeight;
        public FruitController fruitControllerPrefab;
    }
}