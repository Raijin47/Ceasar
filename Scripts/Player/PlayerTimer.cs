using UnityEngine;

namespace Player
{
    public class Timer : PlayerShooting
    {
        public bool IsCompleted = false;
        public float CurrentTime => _currentTime;

        protected readonly float _requiredTime = 0;
        protected float _delayStartTime = 0;
        protected float _currentTime = 0;

        public Timer(float timer, float delay = 0)
        {
            _delayStartTime = delay;
            _requiredTime = timer;
            _currentTime = _requiredTime;
        }

        private bool StartDelay()
        {
            if (_delayStartTime > 0f)
            {
                _delayStartTime -= Time.deltaTime;
                if (_delayStartTime <= 0f)
                {
                    _delayStartTime = 0;
                    return false;
                }

                return true;
            }

            return false;
        }

        public virtual void Update()
        {
            if (IsCompleted)
            {
                return;
            }

            if (_currentTime > 0f && !StartDelay())
            {
                _currentTime -= Time.deltaTime;
                if (_currentTime <= 0f)
                {
                    _currentTime = 0;
                    IsCompleted = true;
                }
            }
        }

        public virtual void RestartTimer()
        {
            _currentTime = _requiredTime;
            IsCompleted = false;
        }
    }
}