using System;

public class Game
{
    public GameState CurrentState { get; private set; }

    public Game()
    {
        CurrentState = GameState.Start;
    }

    public void StartGame()
    {
        CurrentState = GameState.Playing;
        Console.WriteLine("Game Started!");
    }

    public void EndGame()
    {
        CurrentState = GameState.SuccessEnd;
        Console.WriteLine("Game Started!");
    }

    public void PauseGame()
    {
        CurrentState = GameState.Paused;
        Console.WriteLine("Game Paused.");
    }

    public void GameOver()
    {
        CurrentState = GameState.GameOver;
        Console.WriteLine("Game Over.");
    }

    public Boolean IsPlaying()
    {
        return CurrentState == GameState.Playing ? true : false;
    }

    public Boolean IsPaused()
    {
        return CurrentState == GameState.Paused ? true : false;
    }

    public Boolean IsGameOver()
    {
        return CurrentState == GameState.GameOver ? true : false;
    }
}