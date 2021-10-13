using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5;
    [SerializeField] private float timeToMaxSpeed = 1f;

    private float speed = 0;
    private float accelRatePerSec;

    private float modifierVelocityX = 0.01f;

    private Vector3 startPositionMouse;
    private Vector3 positionPlayer;

    private Animator playerAnim;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        positionPlayer = transform.position;
        accelRatePerSec = maxSpeed / timeToMaxSpeed;

        UIController.instance.OnGameFinished += Finish;
    }

    private void Update()
    {
        if (UIController.instance.Finished) return;

        if (Input.GetMouseButtonDown(0))
        {
            startPositionMouse = Input.mousePosition;
            playerAnim.SetBool("isRun", true);
        }
        if (Input.GetMouseButton(0))
        {
            var directionX = Input.mousePosition.x - startPositionMouse.x;
            var x = directionX * modifierVelocityX;

            speed += accelRatePerSec * Time.deltaTime;

            transform.position = new Vector3(
                positionPlayer.x + x,
                transform.position.y,
                transform.position.z + Mathf.Min(speed, maxSpeed) * Time.deltaTime);
        }
        if (Input.GetMouseButtonUp(0))
        {
            speed = 0;
            positionPlayer = transform.position;
            playerAnim.SetBool("isRun", false);
        }
    }

    private void Finish() => StartCoroutine(Delay());

    private IEnumerator Delay()
    {
        var timer = 0f;

        while (timer < timeToMaxSpeed)
        {
            transform.Translate(Vector3.forward * maxSpeed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        playerAnim.SetBool("isRun", false);
    }
}
