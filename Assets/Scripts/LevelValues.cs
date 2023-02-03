using UnityEngine;

[CreateAssetMenu(fileName = "LevelValues", menuName = "TheirRoot/LevelValues", order = 0)]
public class LevelValues : ScriptableObject
{
    public float healDecreasingSpeed;
    public float maxHealth;
    public int itemsByLevel;
}