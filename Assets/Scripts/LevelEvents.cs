using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "LevelEvents", menuName = "TheirRoot/LevelEvents", order = 0)]
    public class LevelEvents : ScriptableObject
    {
        /**
         * Array with the level values that change the difficult level-by-level
         */
        public LevelValues[] LevelValuesArray;

        public bool isPaused;
        /**
         * Event lunched every time a new level starts
         */
        public UnityAction<LevelValues, int> StartNewLevel;
        /**
         * Event invoked when the player lose
         */
        public UnityAction EndGame;
    }
}