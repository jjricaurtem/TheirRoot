using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace TheirRoot
{
    public class LevelUI : MonoBehaviour
    {
        [SerializeField] private LevelEvents levelEvents;
        [SerializeField] private GameObject uiFinalMessagePanel;
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private Button restartButton;

        private void Awake()
        {
            levelEvents.EndGame += EndGame;
            levelEvents.StartNewLevel += StartNewLevel;
            restartButton.onClick.AddListener(Restart);
        }

        private void StartNewLevel()
        {
            levelText.text = $"Level: {levelEvents.currentLevel}";
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