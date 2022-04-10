using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using Utilities;

namespace Game
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float startMinutes;

        [SerializeField] private TMP_Text timer;
        
        private float _currentTime;

        private bool _timerActive;
        
        private void OnEnable()
        {
            EventManager.StartGame += StartTimer;
        }
        
        private void OnDisable()
        {
            EventManager.StartGame -= StopTimer;
        }

        private void Start()
        {
            _currentTime = startMinutes * 60f;
            timer.text = "--:--";
        }

        private void Update()
        {
            if (!_timerActive) return;

            if (_currentTime <= 0)
            {
                // RESTART
                _timerActive = false;
                Start();
                EventManager.OnStopGame();
            }
            
            _currentTime -= Time.deltaTime;
            var time = TimeSpan.FromSeconds(_currentTime);
            
            if (timer) timer.text = $"{time.Minutes,0:D2}" + ":" + $"{time.Seconds,0:D2}";
        }

        private void StartTimer()
        {
            _timerActive = true;
        }

        private void StopTimer()
        {
            _timerActive = false;
        }
        
    }
}
