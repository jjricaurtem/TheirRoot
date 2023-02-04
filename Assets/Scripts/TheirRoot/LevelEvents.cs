using UnityEngine;
using UnityEngine.Events;

namespace TheirRoot
{
    [CreateAssetMenu(fileName = "LevelEvents", menuName = "TheirRoot/LevelEvents", order = 0)]
    public class LevelEvents : ScriptableObject
    {
        public int currentLevel;

        /**
        * Array with the level values that change the difficult level-by-level
        */
        public LevelValues[] LevelValuesArray;

        /**
         * When an animation is running we should avoid the gameplay to continua until it's finished
        */
        public bool isGameplayEnable;

        /**
        * Event invoked when the player lose
        */
        public UnityAction EndGame;

        /**
        * Event lunched every time a new level starts
        */
        public UnityAction StartNewLevel;
        
 
    }
}