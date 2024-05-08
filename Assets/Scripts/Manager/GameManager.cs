using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager[] levels;
    private static GameManager Instance;

    private GameState currentState;
    private bool isInputActive = true;

    private LevelManager currentLevel;
    private int currentLevelIndex = 0;

    public Action<GameState, int> OnStateChange;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public static GameManager GetInstance()
    {
        return Instance;
    }

    public bool IsInputActive()
    {
        return isInputActive;
    }

    void Start()
    {
        //Go to the briefing state of the game
        if (levels.Length > 0)
        {
            Changestate(GameState.Briefing);
        }
    }

    public void Changestate(GameState state)
    {
        currentState = state;
        currentLevel = levels[currentLevelIndex];

        OnStateChange(currentState, currentLevelIndex);
        switch (currentState)
        {
            case GameState.Briefing:
                StartBriefing();
                break;
            case GameState.LevelStart:
                StartLevel();
                break;
            case GameState.LevelEnd:
                CompleteLevel();
                break;
            case GameState.GameOver:
                GameOver();
                break;
            case GameState.GameEnd:
                GameEnd();
                break;
        }
    }

    private void StartBriefing()
    {
        DisableControl();
    }

    private void StartLevel()
    {
        if (!isInputActive)
            isInputActive = true;
        currentLevel.StartLevel();
    }

    private void CompleteLevel()
    {
        currentLevelIndex++;
        currentLevel.EndLevel();
    }

    private void GameOver()
    {
        DisableControl();
        UnlockCursor();
    }

    private void GameEnd()
    {
        DisableControl();
        UnlockCursor();
    }

    private static void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void DisableControl()
    {
        isInputActive = false;
    }

    public enum GameState
    {
        Briefing,
        LevelStart,
        LevelEnd,
        GameOver,
        GameEnd
    }
}