using TMPro;
using UnityEngine;

namespace UI
{
    public class ScreenScore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _pointsTextMeshPro;

        public void Setup(int playerScore)
        {
            _pointsTextMeshPro.text = "With Final Score: " + playerScore + " points";
        }
    }
}
