using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerpTest : MonoBehaviour
{ 

        public float _health;
        public Renderer myRender;
        int indexlevel = 1;
        public float maxVal;
        public float minVal;
        public float speed;

        private void Start()
        {
           // _health = 100;
            TryGetComponent(out myRender);

        }

        public void Update()
        {
            DecreasingHealthyByTime();
            ModifyTreeMaterial();
            Debug.Log(_health + " " + myRender.material.color);
        }
        public void DecreasingHealthyByTime()
        {
            if (_health >= minVal)
            {
                _health -= Time.deltaTime * speed;
            }
            else
            {
                //levelEvents.LevelLose();//leveUI
            }
        }

        public void ModifyTreeMaterial()
        {
            //y=mx+b for normalized values
            var m = (0.8f - 0.2f)/ (maxVal - minVal);
            var b = 0.8f - m* maxVal;
            var normalValue = _health * m + b;
           // Debug.Log(normalValue);

            var targetColor = Color.HSVToRGB(normalValue, normalValue, normalValue);
            myRender.material.color = Color.Lerp(myRender.material.color, targetColor, Time.deltaTime/( _health-minVal));//revisar
           
        }


}
