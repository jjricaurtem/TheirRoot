using UnityEngine;
using UnityEngine.UI;

namespace TheirRoot
{
    public class TreeRoots : MonoBehaviour
    {
        public LevelValues levelValues;
        public LevelEvents levelEvents;
        public Renderer myRender;
        public Slider slider;
        private float _health;

        private void Start()
        {
            _health = levelValues.initNutrition;
            UpdateHealBarUi();
            if (myRender == null) TryGetComponent(out myRender);
        }

        public void Update()
        {
            if (!levelEvents.isGameplayEnable) return;
            DecreasingHealthyByTime();
            ModifyTreeMaterial();
            UpdateHealBarUi();
        }

        private void UpdateHealBarUi()
        {
            slider.maxValue = levelValues.maxNutrition;
            slider.minValue = levelValues.minNutrition;
            slider.value = _health;
        }

        private void DecreasingHealthyByTime()
        {
            if (_health >= levelValues.minNutrition) _health -= Time.deltaTime * levelValues.healDecreasingSpeed;
            else levelEvents.EndGame.Invoke();
        }

        private void ModifyTreeMaterial()
        {
            //y=mx+b for normalized values
            var m = (0.8f - 0.2f) / (levelValues.maxNutrition - levelValues.minNutrition);
            var b = 0.8f - levelValues.maxNutrition * m;

            var normalValue = _health * m + b;

            var targetColor = Color.HSVToRGB(normalValue, normalValue, normalValue);
            // myRender.material.color = Color.Lerp(myRender.material.color, targetColor,
            //     Time.deltaTime / (_health - levelValues.minNutrition));
        }

        public void IncreaseHealth(int addHealth)
        {
            _health += addHealth;
            if (!(_health >= levelValues.maxNutrition)) return;

            levelEvents.currentLevel++;
            levelEvents.StartNewLevel?.Invoke();
        }
    }
}