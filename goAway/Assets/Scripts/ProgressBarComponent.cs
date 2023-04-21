using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace N.Fridman.ProgressBar.Scripts
{
    public class ProgressBarComponent : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private Image image;

        [Header("Properties")]
        [SerializeField] private int value = 0;
        [SerializeField] private int maxValue = 50;
        [SerializeField] private bool isCorrectlyConfigured = false;

        private void Start()
        {
            StartCoroutine(addScore()); //Старт корутины
        }

        private void Awake()
        {
            if (image.type == Image.Type.Filled & image.fillMethod == Image.FillMethod.Horizontal)
            {
                isCorrectlyConfigured = true;
            }
            else
            {
                Debug.Log("{GameLog} => [ProgressBarController] - (<color=red>Error</color>) -> Components Parameters Are Incorrectly Configured! \n" +
                          "Required Type: Filled \n" +
                          "Required FillMethod: Horizontal");
            }
        }

        private void LateUpdate()
        {
            if (!isCorrectlyConfigured) return;
            image.fillAmount = (float)value / maxValue;
        }

        public void SetValue(int value) => this.value = value;
        public void SetMaxValue(int maxValue) => this.maxValue = maxValue;

        private IEnumerator addScore()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                if (value < 50)
                {
                    value++;
                }

            }
        }


    }
}