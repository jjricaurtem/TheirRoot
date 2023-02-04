using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheirRoot
{
    public class AnimalController : MonoBehaviour
    {//level events si el juego está pausad o, que no se mueva, un solo 

        public float atackTime = 15;
        public float timer;
        TileMap tileMap;
        void Start()
        {
            timer = 0;
        }

        // Update is called once per frame
        void Update()
        {
            timer += timer * Time.deltaTime;
            if (timer >= atackTime)
            {
                MoveTo();
            }

        }

        void MoveTo()
        {
            var randRan = Random.Range(0, 1);
            var newPos = Vector3.zero * randRan;
            transform.position += newPos;
            timer = 0;
        }
    }
}

