using UnityEngine;

public class ChractoerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move()
    {
        Input.GetAxis("Horizental");
    }
}
