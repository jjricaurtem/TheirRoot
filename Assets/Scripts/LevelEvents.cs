using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "LevelEvents", menuName = "TheirRoot/LevelEvents", order = 0)]
public class LevelEvents : ScriptableObject
{
    /**
         * Array with the level values that change the difficult level-by-level
         */
    public LevelValues[] LevelValuesArray;

    /**
         * When an animation is running we should avoid the gameplay to continua until it's finished
         */
    public bool isAnimating;

    /**
         * Event invoked when the player lose
         */
    public UnityAction EndGame;

    /**
         * Event lunched every time a new level starts
         */
    public UnityAction<LevelValues, int> StartNewLevel;
}