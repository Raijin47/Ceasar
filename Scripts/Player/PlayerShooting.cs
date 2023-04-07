using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Bullet;

namespace Player
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private BulletManager bullet;
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
                    bullet.CreateBullet();
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