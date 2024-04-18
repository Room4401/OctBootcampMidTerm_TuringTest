using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LevelManager[] levels;
    private static GameManager Instance;

    private GameState currentState;
    private bool isInputActive = true;

    private LevelManager currentLevel;
    private int currentLevelIndex = 0;

    public Action<GameState> OnStateChange;
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

        OnStateChange(currentState);
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
        Debug.Log("Well, briefing Started");
        isInputActive = false;
        Changestate(GameState.LevelStart);
    }

    private void StartLevel()
    {
        Debug.Log("Well, Level Initialised");
        isInputActive = true;
        currentLevel.StartLevel();
    }

    private void CompleteLevel()
    {
        Debug.Log("Well, Level Completed");
        currentLevelIndex++;
        Changestate(GameState.LevelStart);
    }

    private void GameOver()
    {
        Debug.Log("Well, Level Game Over and You Lose");
        UnlockCursor();
    }

    private void GameEnd()
    {
        Debug.Log("Well, Game has Ended and You Win");
        UnlockCursor();
    }

    private static void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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