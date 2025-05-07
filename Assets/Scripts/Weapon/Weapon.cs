using UnityEngine;

public class Weapon : MonoBehaviour
{
    private new Rigidbody rigidbody;

    public Transform worldTransform; // 월드 Transform
    public float throwForce = 10f; // 던지는 힘 (이 값은 조정 가능)
    public float MaxThrowDamage = 10f;
    public WeaponStatus Status;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    public virtual void AttachWeaponToParent(GameObject gameObject)
    {
        transform.SetParent(gameObject.transform);

        if (rigidbody != null)
        {
            rigidbody.isKinematic = true;
        }
    }

    public virtual void ThrowWeapon()
    {
        // 월드 부모로 설정
        transform.SetParent(worldTransform);

        if (rigidbody != null)
        {
            rigidbody.isKinematic = false; // 던지면 물리적 영향을 받게 설정

            // 던지는 힘을 추가 (transform.forward 대신에 원하는 방향을 설정할 수 있음)
            rigidbody.AddForce(transform.forward * throwForce, ForceMode.Impulse); // 던지는 힘을 추가
        }
    }

    public virtual void ChangeStatus(WeaponStatus weaponStatus)
    {
        Status = weaponStatus;
    }

    public virtual void SwingWeapon(GameObject weapon)
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        float impactForce = collision.relativeVelocity.magnitude;

        if (collision.gameObject.CompareTag("Enemy") && impactForce > 5f)
        {
            // 적 스크립트에 데미지 전달
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(5f);
            }
        }
    }
}
