using UnityEngine;

public class FirstPersonController : CharacterController
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        base.Move();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.tag);
    }
}
