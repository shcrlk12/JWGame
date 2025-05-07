using UnityEngine;
using UnityEngine.XR;

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
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
        Jump();
        E();
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

    protected virtual void E()
    {
        if (playerInput.E)
        {
            playerRigidbody.AddForce(new Vector3(0, JumpPower, 0));
        }
    }

    //void GetHands()
    //{
    //    //1. ray로 Collider를 쏘고 Object인지 확인한다.
    //    RaycastHit hit;
    //    LayerMask layerMask = LayerMask.GetMask("Object");
    //    Debug.DrawRay(Eye.transform.position, Eye.transform.forward * 15, Color.white);
    //    var isObejct = Physics.Raycast(Eye.transform.position, Eye.transform.forward, out hit, 15f, layerMask);

    //    if (isObejct)
    //        print("Found an object - distance: " + hit.distance);

    //    if (isObejct == true && hit.collider != null)
    //    {
    //        //2. Object라면 그 Object의 Collider를 가져온다.
    //        GameObject gameObject = hit.collider.gameObject;

    //        //3. Collider의 transform을 가져온다.
    //        _grabbedObject = gameObject;
    //        _grabbedObject.GetComponent<Rigidbody>().isKinematic = true; // Rigidbody를 비활성화
    //        _isGrabbed = true;

    //    }
    //}

    //void ThrowObject()
    //{
    //    Rigidbody rigidbody = _grabbedObject.GetComponent<Rigidbody>();
    //    rigidbody.isKinematic = false;
    //    rigidbody.AddForce(Hand.transform.forward * throwForce);
    //    _isGrabbed = false;
    //}
}
