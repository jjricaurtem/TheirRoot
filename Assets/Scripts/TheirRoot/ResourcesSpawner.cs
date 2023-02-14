using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheirRoot
{
    public class ResourcesSpawner : MonoBehaviour
    {
        public LevelValues levelValues;
        public LevelEvents levelEvents;
        public List<GameObject> goodResources = new List<GameObject>();
        public List<GameObject> badResources = new List<GameObject>();
        public Tile[] childTileMap;
        public GameObject tileMap;
        bool thereAreGoodResources = false;
        bool thereAreBadResources = false;
 

        public void Update()
        {
            if (!levelEvents.isGameplayEnable) return;
            if (childTileMap.Length==0) childTileMap = tileMap.GetComponentsInChildren<Tile>();
                      
            var lenghtGood=(int)Random.Range(levelValues.minGoodResources, levelValues.maxGoodResources);
            var lenghtBad=(int)Random.Range(levelValues.minBadResources, levelValues.maxBadResources);
            
            if(!thereAreGoodResources) InstantiateGoodResources(lenghtGood);
            if(!thereAreBadResources) InstantiateBadResources(lenghtBad);            

        }

        public void InstantiateGoodResources(int length)
        {
            for (int i = 0; i < length; i++)
            {
                var indexResourse = (int)Random.Range(0, goodResources.Count);
                var indexTile = (int)Random.Range(0, childTileMap.Length);
                var newResource= Instantiate(goodResources[indexResourse]);
                newResource.transform.localEulerAngles = new Vector3(-90, 0, 0);
                newResource.transform.position = childTileMap[indexTile].transform.position;
                newResource.transform.localScale = new Vector3(25, 25, 25);
            }
            thereAreGoodResources = true;
        }        
        
        public void InstantiateBadResources(int length)
        {
            for (int i = 0; i < length; i++)
            {
                var indexResourse = (int)Random.Range(0, badResources.Count);
                var indexTile = (int)Random.Range(0, childTileMap.Length);
                var newResource = Instantiate(badResources[indexResourse]);
                newResource.transform.localEulerAngles = new Vector3(-90, 0, 0);
                newResource.transform.position = childTileMap[indexTile].transform.position;
                newResource.transform.localScale = new Vector3(25, 25, 25);

            }
            thereAreBadResources = true;
        }

    }
}