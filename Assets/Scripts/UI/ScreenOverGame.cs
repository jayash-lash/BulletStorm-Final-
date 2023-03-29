using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class ScreenOverGame : MonoBehaviour
    {
        [SerializeField] private ScreenScore _score;

        public void ScreenOn()
        {
            gameObject.SetActive(true);
        }
        public void RestartButton()
        {
            SceneManager.LoadScene("Game");
        }

        public void MainMenuButton()
        {
            
        }
    }
}