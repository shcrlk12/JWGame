using UnityEngine;

class FirstPersonCamera : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AttachWeaponToParent(GameObject gameObject)
    {
        transform.SetParent(gameObject.transform);
        transform.localPosition = Vector3.zero;
    }
}
