using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public GameObject messageTxt;
    public UnityEvent OnMessageUpdate;

    private bool offPath = false;
    private string message;

    void Awake()
    {
        messageTxt.SetActive(false);
        GameManager.GetInstance().OnStateChange += SetMessage;
    }

    private void SetMessage(GameManager.GameState state, int level)
    {
        StateMessage(state, level);
        messageTxt.GetComponentInChildren<TMP_Text>().text = message;
        OnMessageUpdate?.Invoke();
    }

    private void StateMessage(GameManager.GameState state, int level)
    {
        switch (state)
        {
            case GameManager.GameState.Briefing:
                message = "Welcome to the Turing Test, "
                    + "You will be able to move around with the W, A, S, D button, "
                    + "SPACE to jump, E to interact, "
                    + "shoot bullet with LEFT mouse button, "
                    + "and rocket with RIGHT mouse button.";
                break;
            case GameManager.GameState.GameOver:
                if (offPath)
                    message = "You have failed the test, as you have walked off the path.";
                else
                    message = "You have failed the test, as you have stepped on a pad twice.";
                break;
            case GameManager.GameState.GameEnd:
                message = "Congratulation, You have Sucessfully Completed the test.";
                break;
            case GameManager.GameState.LevelStart:
                LevelStartMessage(level);
                break;
            case GameManager.GameState.LevelEnd:
                LevelEndMessage(level);
                break;
        }
    }

    private void LevelStartMessage(int level)
    {
        switch (level)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }

    private void LevelEndMessage(int level)
    {
        switch (level)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }
    }

    public void OffPathGameOver()
    {
        offPath = true;
    }
}