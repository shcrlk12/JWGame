public class LittleGhost : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        HP = 30;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        base.FollowPlayer(Target);
    }
}