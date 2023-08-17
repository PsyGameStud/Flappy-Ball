using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : Singleton<GameplayManager>
{
    [SerializeField] private PlayerBehaviour _player;
    public bool IsStarted { get; private set; }
    
    public event Action OnStartGame;

    public void StartGame()
    {
        IsStarted = true;
        OnStartGame?.Invoke();
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    public PlayerBehaviour GetPlayer() => _player;
}
