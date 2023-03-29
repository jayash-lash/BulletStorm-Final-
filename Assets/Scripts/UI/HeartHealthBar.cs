using UnityEngine;

namespace UI
{
    public class HeartHealthBar : MonoBehaviour
    {
        [SerializeField] private HeartView[] _hearts;
        [SerializeField] private int _maxHearts = 3;
        [SerializeField] private int _currentHearts;

        private void Awake()
        {
            UpdateHearts();
        }
        
        public void UpdateHearts()
        {
            for (int i = 0; i < _hearts.Length; i++)
            {
                if (i < _currentHearts) _hearts[i].SetActive(true);
                else _hearts[i].SetActive(false);
            }
        }

        public void Heal(int amount)
        {
            _currentHearts += amount;
            _currentHearts = Mathf.Min(_currentHearts, _maxHearts);

            UpdateHearts();
        }

        public void TakeDamage(int amount)
        {
            _currentHearts -= amount;
            _currentHearts = Mathf.Max(_currentHearts, 0);

            UpdateHearts();
        }
    }
}