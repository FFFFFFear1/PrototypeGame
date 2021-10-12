using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5;
    [SerializeField] private float timeToMaxSpeed = 1f;

    private float speed = 0;
    private float accelRatePerSec;

    private float modifierVelocityX = 0.01f;

    private Vector3 startPositionMouse;
    private Vector3 startPositionPlayer;

    private Animator playerAnim;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        playerAnim = GetComponent<Animator>();
        startPositionPlayer = transform.position;
        accelRatePerSec = maxSpeed / timeToMaxSpeed;
    }

    private void Update()
    {
        //TODO bad!
        if (UIController.instance.Pause)
        {
            playerAnim.SetBool("isRun", false);
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            startPositionMouse = Input.mousePosition;
            playerAnim.SetBool("isRun", true);
        }

        if (Input.GetMouseButton(0))
        {
            var directionX = Input.mousePosition.x - startPositionMouse.x;
            var x = directionX * modifierVelocityX;

            speed += accelRatePerSec * Time.fixedDeltaTime;

            transform.position = new Vector3(
                startPositionPlayer.x + x,
                transform.position.y,
                transform.position.z + Mathf.Min(speed, maxSpeed) * Time.deltaTime);
        }

        if(Input.GetMouseButtonUp(0))
        {
            speed = 0;

            startPositionPlayer = transform.position;
            playerAnim.SetBool("isRun", false);
        }
    }
}
