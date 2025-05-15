using UnityEngine;

class Clock
{
    public float GameTime { get; private set; } = 0f;

    // unit "game min"/ "real min"
    public float ElapseTimePerMinute { get; set; }

    public void UpdateTime()
    {
        GameTime += ElapseTimePerMinute * Time.deltaTime;
    }

    public void UpdateTime(float elapseTimePerMinute)
    {
        GameTime += elapseTimePerMinute * Time.deltaTime;
    }
    public void InitializeGameTime(float gametime)
    {
        GameTime = gametime;
    }
}
