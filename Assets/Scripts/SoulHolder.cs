using UnityEngine;

public class SoulHolder : MonoBehaviour
{
    public float HP = 10f;

    public void Hit(float demage)
    {
        HP -= demage;
        if (HP <= 0)
            Broken();
    }

    public void Broken()
    {
        //TODO: 파괴된 오브젝트랑 교체

        //SoulEnergy 감소
        GameManager.Instance.EnergyChecker.ReduceSoulEnergy(HP * 10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(TagExtensions.GetName(Tag.Weapon))
            || collision.collider.CompareTag(TagExtensions.GetName(Tag.Projectile)))
        {
            Hit(1);
        }
    }
}
