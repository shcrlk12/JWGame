using UnityEngine;

public class FirstPersonController : BaseController
{
    private float xRotation = 0f;
    private FirstPersonCamera _firstPersonCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        Cursor.lockState = CursorLockMode.Locked;

        _firstPersonCamera = Camera.main.GetComponent<FirstPersonCamera>();
        _firstPersonCamera.AttachToParent(Eye);

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        xRotation -= PlayerInput.MouseInput.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        Eye.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * PlayerInput.MouseInput.x);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);
    }
}
