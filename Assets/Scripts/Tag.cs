using System;

public enum Tag
{
    Untagged,
    Respawn,
    Finish,
    EditorOnly,
    MainCamera,
    Player,
    GameController,
    NormalEnemy,
    BossEnemy,
    NPC,
    Weapon,
    Checkpoint,
    Hazard,
    Projectile,
    Interactable,
    Friendly
}

public static class TagExtensions
{
    // Enum 값에 대한 설명을 반환하는 메서드
    public static string GetName(this Tag tag)
    {
        return Enum.GetName(typeof(Tag), tag);
    }
}