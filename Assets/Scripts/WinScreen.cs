using System;
using TMPro;
using UnityEngine.SceneManagement;

namespace Root
{
    public class WinScreen: Screen
    {
        public TextMeshProUGUI TextMeshProUGUI;
        public void SetWinner(SignType winnerTypeValue)
        {
            switch (winnerTypeValue)
            {
                case SignType.None:
                    break;
                case SignType.Cross:
                    TextMeshProUGUI.SetText("Cross");
                    break;
                case SignType.Circle:
                    TextMeshProUGUI.SetText("Circle ");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(winnerTypeValue), winnerTypeValue, null);
            }
        }

        public void OnRestartClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}