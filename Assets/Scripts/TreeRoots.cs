using DefaultNamespace;
using UnityEngine;


/*
   TODO: check if the game is paused.
   TODO: Decreasing the health on time taking the decreasingSpeed from the levelValues
   TODO: Modify the tree material according with the health, tip: you can use Lerp for modify the HSV values of the albedo color
   TODO: if the health decrease to 0 or below then invoke the envent for game lose
   TODO: if the health increase to level's max health or higher then send invoke StartNewLevel event
   TODO: listen for item consumption to increase the health. 
 */
public class TreeRoots : MonoBehaviour
{
    public LevelValues levelValues;
    public LevelEvents levelEvents;
    private float _health;

    public void DecreasingHealthyByTime()
    {
    }
}