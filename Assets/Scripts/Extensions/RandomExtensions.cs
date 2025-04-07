using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class RandomExtensions
    {
        public static T GetRandomItem<T>(this List<T> list) => 
            list.Count == 0 ? default : list[Random.Range(0, list.Count)];

        public static void Shuffle<T>(this List<T> list)
        {
            var listCount = list.Count;
            for (var i = 0; i < listCount-1; i++)
            {
                var oldVal = list[i];
                var randomIndex = Random.Range(i, listCount);
                list[i] = list[randomIndex];
                list[randomIndex] = oldVal;
            }
        }
        
        /// <summary>
        /// Returns a random number (uniformly distributed) in the range from -1f to 1f
        /// </summary>
        public static float RandomFloat11 => Random.value * 2f - 1f;
    }
}