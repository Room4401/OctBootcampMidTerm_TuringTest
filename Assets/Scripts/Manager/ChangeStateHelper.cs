using UnityEngine;

public class ChangeStateHelper : MonoBehaviour
{
    public void StartLevel()
    {
        ChangeState(GameManager.GameState.LevelStart);
    }

    public void FinishLevel()
    {
        ChangeState(GameManager.GameState.LevelEnd);
    }

    public void GameOver()
    {
        ChangeState(GameManager.GameState.GameOver);
    }

    public void GameFinish()
    {
        ChangeState(GameManager.GameState.GameEnd);
    }

    private void ChangeState(GameManager.GameState state)
    {
        GameManager.GetInstance().Changestate(state);
    }
}