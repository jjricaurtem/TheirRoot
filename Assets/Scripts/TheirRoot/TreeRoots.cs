using UnityEngine;


/*
   TODO: check if the game is paused.
   TODO: Decreasing the health on time taking the decreasingSpeed from the levelValues
   TODO: Modify the tree material according with the health, tip: you can use Lerp for modify the HSV values of the albedo color
   TODO: if the health decrease to 0 or below then invoke the envent for game lose
   TODO: if the health increase to level's max health or higher then send invoke StartNewLevel event
   TODO: listen for item consumption to increase the health. 
 */
namespace TheirRoot
{
    public class TreeRoots : MonoBehaviour
    {
        public LevelValues levelValues;
        public LevelEvents levelEvents;
        float _health;
        public Renderer myRender;
        int indexlevel=1;


        private void Start()
        {           
            _health = levelValues.initNutrition;
            TryGetComponent(out myRender);
        
        }

        public void Update()
        {       
            DecreasingHealthyByTime();
            ModifyTreeMaterial();
            Debug.Log(_health+" "+myRender.material.color);
        }
        public void DecreasingHealthyByTime()
        {
            if (_health>=levelValues.minNutrition)
            {
                _health -= Time.deltaTime * levelValues.healDecreasingSpeed;
            }
            else{ 
            //levelEvents.LevelLose();//leveUI
            }
        }

        public void ModifyTreeMaterial()
        {
            //y=mx+b for normalized values
            var m = (0.8f - 0.2f) / (levelValues.maxNutrition - levelValues.minNutrition);
            var b = 0.8f-levelValues.maxNutrition*m;

            var normalValue = _health*m + b;

            var targetColor = Color.HSVToRGB(normalValue,normalValue,normalValue);
            myRender.material.color = Color.Lerp(myRender.material.color, targetColor, Time.deltaTime/(_health-levelValues.minNutrition));
        }

        public void increaseHealth(int addHealth)
        {
            _health += addHealth;
            if (_health >= levelValues.maxNutrition)
            {
                indexlevel++;
                levelEvents.currentLevel++;
                levelEvents.StartNewLevel?.Invoke();
            }
        }
    }
}