using System;
using Cinemachine;
using DG.Tweening;
using Enemy;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class LevelManager : MonoBehaviour
    {
        [Header("PLayer Settings")] 
        [SerializeField] private int _scoresToWin = 10000;
        [SerializeField] private Health _playerHealth;
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _playerMissileSpawner;
        
        [Header("Enemy Settings")]
        [SerializeField] private GameObject _enemySpawner;
        [SerializeField] private GameObject _enemyManager;
        
        [Header("UI Settings")]
        [SerializeField] private GameObject _scoreText;
        [SerializeField] private GameObject _hearts;
        [SerializeField] private GameObject _playerScoreObject;
        [SerializeField] private UIScore _playerScore;
        
        [Header("UI Screen over Game")]
        [SerializeField] private ScreenOverGame _deathScreen;
        [SerializeField] private ScreenOverGame _winScreen;
        [SerializeField] private ScreenScore _screenScoreDeath;
        [SerializeField] private ScreenScore _screenScoreWin;

        [Header("Camera")] [SerializeField] private CinemachineVirtualCamera _vCamera;
        
        
        private void Start()
        {
            _playerHealth.OnHealthZero += PlayerDie;
            _playerScore.OnScoreChanged += PlayerWin;
        }
        
        public void PlayerDie()
        {
            if (_playerHealth.CurrentHealth <= 0)
            {
                _screenScoreDeath.Setup(_playerScore.Score);
                _playerScoreObject.SetActive(false);
                _enemySpawner.SetActive(false);
                _playerMissileSpawner.SetActive(false);
                _enemyManager.SetActive(false);
                _scoreText.SetActive(false);
                _hearts.SetActive(false);
                
                _deathScreen.ScreenOn();
                
                Debug.Log("DEATH");
                _player.SetActive(false);
            }
        }

        public void PlayerWin(int score)
        {
            if (score >= _scoresToWin)
            {
                _screenScoreWin.Setup(_playerScore.Score);
                _playerScoreObject.SetActive(false);
                _enemySpawner.SetActive(false);
                _playerMissileSpawner.SetActive(false);
                _enemyManager.SetActive(false);
                _scoreText.SetActive(false);
                _hearts.SetActive(false);
                
                _winScreen.ScreenOn();
                
                Debug.Log("WIN");
                _player.SetActive(false);
            }
        }

        private void StartAppearances()
        {
           transform.DOMoveY(-16,2).From(_player.transform.position);
           _vCamera.gameObject.SetActive(true);
           
        }
        private void OnDestroy()
        {
            _playerHealth.OnHealthZero -= PlayerDie;
        }
        
    }
}
