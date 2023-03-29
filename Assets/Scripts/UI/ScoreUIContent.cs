using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreUIContent : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void UpdateScore(int playerScore)
        {
            _scoreText.text = "Score: " + playerScore;
        }
    }
}
