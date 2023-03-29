using System;
using UnityEngine;

namespace UI
{
    public class UIScore : MonoBehaviour
    {
        public event Action<int> OnScoreChanged;
        public int Score => _score;
        
        [SerializeField] private ScoreUIContent _scoreUI;
        
        private int _score;
        
        public void IncreaseScore(int points)
        {
            _score += points;
            _scoreUI.UpdateScore(_score);
            OnScoreChanged?.Invoke(_score);
        }
    }
}