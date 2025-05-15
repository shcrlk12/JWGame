using UnityEngine;

//game object에 붙혀 놓아야함.
// 전체적인 게임 진행상황 및 UI 관리
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // 중복 방지
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // 씬 전환에도 살아남음
        Initailize();
    }

    public Game Game { get; private set; }
    public EnergyChecker EnergyChecker { get; private set; }
    public TimeChecker TimeChecker { get; private set; }
    public UIManager UIManager { get; private set; }
    private void Initailize()
    {
        Game = new Game();
        EnergyChecker = new EnergyChecker();
        TimeChecker = new TimeChecker();
        UIManager ??= FindAnyObjectByType<UIManager>();

    }

    private void Update()
    {
        switch (Game.CurrentState)
        {
            case GameState.Playing:
                EnergyChecker.RecoverySoulEnergy();
                TimeChecker.ElapseTime();
                break;
            case GameState.SuccessEnd:
                UIManager.SuccessEndGame();
                break;
            case GameState.GameOver:
                TimeChecker.InitTime();
                break;
        }
    }
}