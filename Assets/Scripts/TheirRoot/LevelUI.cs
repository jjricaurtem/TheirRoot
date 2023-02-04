using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TheirRoot
{
    public class LevelUI : MonoBehaviour
    {
        [SerializeField] private LevelEvents levelEvents;
        [SerializeField] private GameObject uiFinalMessagePanel;
        [SerializeField] private TMP_Text levelText;

        private void Awake()
        {
            levelEvents.EndGame += EndGame;
            levelEvents.StartNewLevel += StartNewLevel;
        }

        private void StartNewLevel()
        {
            levelText.text = $"Level: {levelEvents.cuerrenteLevel}";
        }

        private void Start()
        {
            uiFinalMessagePanel.SetActive(false);
        }

        private void OnDestroy()
        {
            levelEvents.EndGame -= EndGame;
            levelEvents.StartNewLevel -= StartNewLevel;
        }

        private void EndGame()
        {
            uiFinalMessagePanel.SetActive(true);
        }

        public void Restart() => SceneManager.LoadScene("GameScene");
    }
}