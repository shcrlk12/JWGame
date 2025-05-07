using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public PlayerInput playerInput;
    private Rigidbody playerRigidbody;
    public float Speed;
    public float DashSpeed;
    public bool isGround;
    public float JumpPower;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    protected virtual void Move()
    {
        float speed = playerInput.Dash ? DashSpeed : Speed;

        var vector = new Vector3(playerInput.MoveInput.x, 0, playerInput.MoveInput.z).normalized;

        playerRigidbody.transform.position += vector * speed * Time.deltaTime;
    }

    protected virtual void Jump()
    {
        if (playerInput.Jump)
        {
            playerRigidbody.AddForce(new Vector3(0, JumpPower, 0));
        }
    }
}
