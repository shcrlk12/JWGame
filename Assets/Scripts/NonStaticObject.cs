using UnityEngine;

public class NonStaticObject : MonoBehaviour
{
    [Tooltip("오브젝트의 무게 단위:kg")]
    public float Mass;

    [Tooltip("오브젝트의 HP")]
    public float HP;

    [Tooltip("무적 오브젝트인지 판별")]
    public float IsInvincibility;

    public bool IsHide;
}
