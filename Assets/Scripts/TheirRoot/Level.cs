using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheirRoot
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private GameObject levels;
        [SerializeField] private float movementSpeed;
        [SerializeField] private LevelEvents levelEvents;
        [SerializeField] private TileMap tilemap;
        private readonly int _level = 1;

        private void Start()
        {
            levelEvents.isGameplayEnable = false;
            StartCoroutine(MoveLevelUp());
        }

        private IEnumerator MoveLevelUp()
        {
            var targetPosition = levels.transform.position.y + 8f * _level;
            while (levels.transform.position.y < targetPosition)
            {
                var nextPosition = levels.transform.position;
                nextPosition.y += Time.deltaTime * movementSpeed;
                levels.transform.position = nextPosition;
                yield return null;
            }

            tilemap.buildTileMap();
            levelEvents.isGameplayEnable = true;
        }
    }
}