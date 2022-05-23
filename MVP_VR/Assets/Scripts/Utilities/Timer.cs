using System;
using Sound;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Utilities
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private int startMinutes;

        [SerializeField] private TMP_Text timerTextField;
        
        [SerializeField] private InputActionReference shootActionReference;
        
        private float _currentTime;

        private bool _timerActive, _timerSoundAlreadyPlayed;
        
        private void OnEnable()
        {
            EventManager.StartGame += StartTimer;
            shootActionReference.action.performed += OnResetTimer;
        }
        
        private void OnDisable()
        {
            EventManager.StartGame -= StartTimer;
            shootActionReference.action.performed -= OnResetTimer;
        }

        private void OnResetTimer(InputAction.CallbackContext obj)
        {
            ResetTimer();
        }

        private void Start()
        {
            _currentTime = startMinutes * 60f;
            timerTextField.text = "--:--";
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

            if (_currentTime <= 10f && !_timerSoundAlreadyPlayed)
            {
                FindObjectOfType<AudioManager>().PlaySound("Timer");
                _timerSoundAlreadyPlayed = true;
            }
            
            _currentTime -= Time.deltaTime;
            var time = TimeSpan.FromSeconds(_currentTime);
            
            if (timerTextField) timerTextField.text = $"{time.Minutes,0:D2}" + ":" + $"{time.Seconds,0:D2}";
        }

        public void SetTimer(int minutes)
        {
            startMinutes = minutes;
        }

        private void StartTimer()
        {
            _timerActive = true;
        }

        private void ResetTimer()
        {
            _currentTime = 0;
        }

    }
}
