public enum Layer
{
    Default = 0,
    TransparentFX = 1,
    IgnoreRaycast = 2,
    Water = 4,
    UI = 5,
    Player = 6,
    Enemy = 7,
    Environment = 8,
    Ground = 9,
    Trigger = 10,
    Projectile = 11,
    Pickup = 12,
    Usable = 13,
    Object = 14
}

public static class LayerExtensions
{
    // Enum 값에 대한 설명을 반환하는 메서드
    public static int GetLayerMask(this Layer layer)
    {
        return 1 << (int)layer;
    }
}