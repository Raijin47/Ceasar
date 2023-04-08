using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Bullet;

namespace Player
{
    public class PlayerShooting : MonoBehaviour
    {
        //[SerializeField] private BulletManager bullet;
        private BulletParticle bullet;
        [SerializeField] private Text ammoCountText;
        [SerializeField] private KeyCode ReloadKeyCode;

        private Coroutine corReloadTimer;
        private Coroutine corIntervalShot;

        private float intervalShot;
        private float reloadTime;
        private int currentAmmoCount;
        private int ammoCount;

        private bool isPauseShot = false;
        private bool isFire = false;
        private bool isReload = false;

        void Start()
        {
            bullet = GetComponentInChildren<BulletParticle>();

            ammoCount = Equipment.ammoCount;
            reloadTime = Equipment.reloadTime;
            intervalShot = Equipment.intervalShot;

            currentAmmoCount = ammoCount;
            ammoCountText.text = currentAmmoCount.ToString();
        }

        void Update()
        {
            isFire = Input.GetMouseButton(0);
            if (isFire) Fire();
            if (Input.GetKeyDown(ReloadKeyCode) && !isReload) Reload();
        }

        private void Reload()
        {
            isReload = true;
            corReloadTimer = StartCoroutine(ReloadTimerCOR());
        }

        private void Fire()
        {
            if (currentAmmoCount > 0)
            {
                if (!isPauseShot && !isReload)
                {
                    currentAmmoCount--;
                    bullet.Shot();
                    ammoCountText.text = currentAmmoCount.ToString();
                    isPauseShot = true;
                    corIntervalShot = StartCoroutine(IntervalShotCOR());
                }
            }
        }

        private IEnumerator IntervalShotCOR()
        {
            while (isPauseShot)
            {
                yield return new WaitForSeconds(intervalShot);
                isPauseShot = false;
                yield break;
            }
        }

        private IEnumerator ReloadTimerCOR()
        {
            while (isReload)
            {
                yield return new WaitForSeconds(reloadTime);
                currentAmmoCount = ammoCount;
                ammoCountText.text = currentAmmoCount.ToString();
                isReload = false;
                yield break;
            }
        }
    }
}



/*{   [Serializable]
public class Timer
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
}*/