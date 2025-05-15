// 시간 흐름.
// 시간이 종료되면 패배 엔딩
// 이것도 빈 오브젝트에
public class TimeChecker
{
    public float ENDING_TIME = 10000;
    private Clock _clock = new Clock();

    public void Start()
    {
        _clock.InitializeGameTime(0f);
        // 1. 시작 시간 세팅
    }

    public void ElapseTime()
    {
        // 1. 시간 흐름.
        _clock.UpdateTime();
        // 2. 시간이 다 흐르면 패배
        if (_clock.GameTime >= ENDING_TIME)
        {
            GameManager.Instance.Game.GameOver();
        }
    }

    public void InitTime()
    {
        _clock.InitializeGameTime(0f);

    }
}

