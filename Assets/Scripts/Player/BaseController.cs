using System;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public PlayerInput PlayerInput;
    public float PlayerSpeed;
    public float PlayerDashSpeed;
    public float JumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public float ThrowPower = 5.0f;

    public GameObject Eye, Hand;
    public Weapon Weapon;

    private CharacterController _controller;

    private bool _isChatchedObject;
    private bool _isGrounded;
    private Vector3 _playerVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        _isGrounded = _controller.isGrounded;

        CharacterMoving();
        //Move();
        //Jump();
        CatchObejct();
    }

    protected void CharacterMoving()
    {
        //Move
        Vector3 move = ((transform.forward * PlayerInput.MoveInput.z) + (transform.right * PlayerInput.MoveInput.x)).normalized;

        // Jump
        if (PlayerInput.Jump && _isGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(JumpHeight * -2.0f * gravityValue);
        }

        // Apply gravity
        _playerVelocity.y += gravityValue * Time.deltaTime;

        if (_isGrounded && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        // Combine horizontal and vertical movement
        Vector3 finalMove = (move * PlayerSpeed) + (_playerVelocity.y * Vector3.up);
        _controller.Move(finalMove * Time.deltaTime);
    }

    protected virtual void Move()
    {
        //float speed = PlayerInput.Dash ? DashSpeed : Speed;

        //Vector3 moveVector = (playerRigidbody.transform.forward * PlayerInput.MoveInput.z) + (playerRigidbody.transform.right * PlayerInput.MoveInput.x);

        //characterController.Move(moveVector.normalized * speed * Time.deltaTime);
    }

    protected virtual void Jump()
    {
        //if (isGrounded && PlayerInput.Jump)
        //{
        //    playerRigidbody.AddForce(new Vector3(0, JumpPower, 0));
        //}
    }

    //TODO: 안됨
    protected virtual void CatchObejct()
    {
        if (PlayerInput.E)
        {
            if (_isChatchedObject == true)
            {
                //Throw
                Weapon.ThrowWeapon(ThrowPower);
                _isChatchedObject = false;
            }
            else if (_isChatchedObject == false)
            {
                // Catch
                RaycastHit hit;
                var isObejct = Physics.Raycast(Eye.transform.position, Eye.transform.forward, out hit, 15f, LayerExtensions.GetLayerMask(Layer.Object));

                if (isObejct == true && hit.collider != null)
                {
                    Weapon = hit.collider.gameObject.GetComponent<Weapon>();
                    if (Weapon != null)
                    {
                        Weapon.AttachWeaponToParent(Hand);
                        _isChatchedObject = true;
                    }
                    else
                    {
                        throw new InvalidOperationException("Weapon is null");
                    }
                }
            }
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
