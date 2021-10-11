using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5;

    private float speedModifier = 0.01f;

    private Vector3 startPositionMouse;
    private Vector3 startPositionPlayer;

    private Animator playerAnim;

    private void Start()
    {
        playerAnim = GetComponent<Animator>();

        startPositionPlayer = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPositionMouse = Input.mousePosition;
            playerAnim.SetBool("isRun", true);
        }

        if (Input.GetMouseButton(0))
        {
            var directionX = startPositionMouse.x - Input.mousePosition.x;
            var x = directionX * speedModifier;

            transform.position = new Vector3(
                startPositionPlayer.x + x,
                transform.position.y,
                transform.position.z + (speed * -1) * Time.deltaTime); ;
        }

        if(Input.GetMouseButtonUp(0))
        {
            startPositionPlayer = transform.position;
            playerAnim.SetBool("isRun", false);
        }
    }
}
