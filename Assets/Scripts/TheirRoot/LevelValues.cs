using UnityEngine;

namespace TheirRoot
{
    [CreateAssetMenu(fileName = "LevelValues", menuName = "TheirRoot/LevelValues", order = 0)]
    public class LevelValues : ScriptableObject
    {
        public float healDecreasingSpeed;
        public float maxNutrition;
        public float minNutrition;
        public float initNutrition;
        public int rootGenerationSpeed;
        public AudioClip audioClip;
        public int maxGoodResources;
        public int minGoodResources;
        public int maxBadResources;
        public int minBadResources;
        public IAnimal animal;
    }
}