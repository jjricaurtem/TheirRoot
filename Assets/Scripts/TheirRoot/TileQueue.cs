using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TheirRoot
{
    public class TileQueue : MonoBehaviour
    {
        [SerializeField] private RootPartSo[] allRootPartsSo;
        [SerializeField] private Image nextRootPartImage;
        [SerializeField] private AvailableTile availableTile1;
        [SerializeField] private AvailableTile availableTile2;
        [SerializeField] private TMP_Text countDownText;

        [SerializeField] private LevelEvents levelEvents;
        private RootPartSo _nextRootPartSo;

        private void Start()
        {
            GenerateNewNextRootPart();
            availableTile1.FillTile(_nextRootPartSo);
            GenerateNewNextRootPart();
            availableTile2.FillTile(_nextRootPartSo);
            GenerateNewNextRootPart();
            StartCoroutine(generateNewRootPart());
        }

        private IEnumerator generateNewRootPart()
        {
            var rootGenerationSpeed = levelEvents.LevelValuesArray[levelEvents.currentLevel - 1].rootGenerationSpeed;
            var currentSeconds = rootGenerationSpeed;
            while (true)
            {
                countDownText.text = currentSeconds.ToString();
                // if the gameplay is paused then skip this frame
                if (!levelEvents.isGameplayEnable)
                {
                    yield return null;
                    continue;
                }

                if (currentSeconds <= 0)
                {
                    if (availableTile1.IsEmpty) availableTile1.FillTile(_nextRootPartSo);
                    else if (availableTile2.IsEmpty) availableTile2.FillTile(_nextRootPartSo);

                    if (!availableTile1.IsEmpty || !availableTile2.IsEmpty) currentSeconds = rootGenerationSpeed;
                }
                else
                {
                    currentSeconds--;
                }

                yield return new WaitForSeconds(1f);
            }
        }

        private void GenerateNewNextRootPart()
        {
            var nextRootPartIndex = Random.Range(0, allRootPartsSo.Length);
            _nextRootPartSo = allRootPartsSo[nextRootPartIndex];
            nextRootPartImage.sprite = _nextRootPartSo.rootSprite;
        }
    }
}