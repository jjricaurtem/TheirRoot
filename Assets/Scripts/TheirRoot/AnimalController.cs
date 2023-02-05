using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheirRoot
{
    public class AnimalController : MonoBehaviour, IItem
    {//level events si el juego está pausad o, que no se mueva, un solo objeto prefabeado pr¿or nivel, configurable

        public float atackTime = 15;
        public float timer;
        Animator animator;
        LevelEvents levelEvents;
        TileMap tileMap;
        List<Tile> avaiableItems = new List<Tile>();
        void Start()
        {
            TryGetComponent(out tileMap);
            TryGetComponent(out animator);
            //termporary Init, should init through the level settings

            //set initial pos, check how nutrients are placed
            Init();
            timer = 0;
        }

        public void Init()
        {
            //Animation for when it enters the scene
            animator.SetTrigger("Enter");
        }

        // Update is called once per frame
        void Update()
        {
            if (!levelEvents.isGameplayEnable)
            {
                return;
            }

            timer += timer * Time.deltaTime;
            if (timer >= atackTime)
            {
                GetRandomTileToMove();
            }
            
        }

        void GetRandomTileToMove()
        {
            var spaces = tileMap.HexMatrix.Length;
            var randRanX = Random.Range(0, spaces);
            var randRanY = Random.Range(0, spaces);
            var newPos = Vector2.zero * randRanX * randRanY;

            
            //Check avaiable objets
            var tileToPos = tileMap.HexMatrix[randRanX][randRanY];
            if (tileToPos.TryGetComponent(out Tile tile))
            {
                //Must change the condition to see if the item is not rooted
                if (tile.Item != null)
                {
                    transform.position = tile.transform.position;
                    //transform.position *= newPos;
                    //add condition for when it has nutrients in it
                    if (tile.Item == null)
                    {
                        GrabStuff(tile);
                    }
                }
            }
            else
            {
                GetRandomTileToMove();
            }
            timer = 0;
        }
        void GrabStuff(Tile tile)
        {
            //take stuff if it there´s any in the tile
        }
    }
}

