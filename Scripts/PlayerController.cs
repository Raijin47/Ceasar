using UnityEngine;
using Bullet;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    private Animator anim;
    private CharacterController characterController;

    [SerializeField] private GameObject gameOverPunel;
    [SerializeField] private Score score;
    [SerializeField] private BulletManager bullet;
    [SerializeField] private Text ammoCountText;

    private Coroutine corReloadTimer;
    private Coroutine corIntervalShot;

    [SerializeField] private float acceleration;
    [SerializeField] private float speed;
    [SerializeField] private float controllability;
    private float currentControllability;
    private float controllabilityOnAcceleration;
    private float currentSpeed;
    private float intervalShot;
    private float reloadTime;
    private int currentAmmoCount;
    private int ammoCount;
    private int damage;

    [Header("KeyCode")]
    [SerializeField] private KeyCode RunningKeyCode;
    [SerializeField] private KeyCode ReloadKeyCode;

    Vector3 moveDirection = Vector3.zero;

    private bool isPauseShot = false;
    private bool canMove = true;
    private bool isRunning = false;
    private bool isFire = false;
    private bool isReload = false;
    private int deathCount;

    private static readonly int DeathA = Animator.StringToHash("isDeath");
    private static readonly int isFireA = Animator.StringToHash("isFire");

    private void Start()
    {
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        deathCount = 0;
        //speed = Equipment.speed;
        //controllability = Equipment.controllability;
        //acceleration = Equipment.acceleration;

        ammoCount = 100;
        damage = 10;
        reloadTime = 5f;
        intervalShot = 0.5f;

        isReload = false;
        isPauseShot = false;
        //ammoCount = Equipment.ammoCount;
        //damage = Equipment.damageValue;
        //reloadTime = Equipment.reloadTime;
        //intervalShot = Equipment.intervalShot;
        //currentReloadTime = reloadTime;
        
        currentSpeed = speed;
        currentControllability = controllability;
        controllabilityOnAcceleration = controllability -0.1f;
        currentAmmoCount = ammoCount;
        ammoCountText.text = currentAmmoCount.ToString();
    }

    private void Update()
    {
        isFire = Input.GetMouseButton(0);
        isRunning = Input.GetKey(RunningKeyCode);
        if (isFire) Fire();

        //if (Input.GetKeyDown(RunningKeyCode)) currentControllability = controllabilityOnAcceleration;
        //if (Input.GetKeyUp(RunningKeyCode)) currentControllability = controllability;
        if (Input.GetKeyDown(ReloadKeyCode) && !isReload) Reload();
        anim.SetFloat("DirectionY", Input.GetAxis("Vertical"));
        Movement();
    }

    private void Movement()
    {
        //float currentSpeed = canMove ? (isRunning ? acceleration : speed) : 0;

        if (isRunning && currentSpeed < acceleration)
        {
            currentSpeed += 2 * Time.deltaTime;
            currentControllability -= 0.1f * Time.deltaTime;
        }

        else if (!isRunning && currentSpeed > speed)
        {
            currentSpeed -= 2 * Time.deltaTime;
            currentControllability += 0.1f * Time.deltaTime;
        }

        moveDirection = new Vector3(1, 0f, Input.GetAxis("Vertical") * currentControllability);
        moveDirection *= currentSpeed;

        characterController.Move(moveDirection * Time.deltaTime);
    }

    private void Death() => StartCoroutine(StartDeathCOR());

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Obstacle"))
    //    {
    //        canMove = false;
    //        anim.SetBool(DeathA, true);
    //        Death();
    //    }
    //}

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
        while(isReload)
        {
            yield return new WaitForSeconds(reloadTime);           
            currentAmmoCount = ammoCount;
            ammoCountText.text = currentAmmoCount.ToString();
            isReload = false;
            yield break;
        }
    }

    private IEnumerator StartDeathCOR()
    {
        while(true)
        {
            yield return new WaitForSeconds(2);
            Time.timeScale = 0;
            gameOverPunel.SetActive(true);
            score.GameOver();
            yield break;
        }
    }
}