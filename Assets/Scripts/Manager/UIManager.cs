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
                    + "SPACE to jump, E to pick up / interact, "
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
                message = "Welcome to the second test";
                break;
            case 2:
                message = "For the third test, You will have to walk over every tile without stepping on the same one.";
                break;
            case 3:
                message = "Welcome to the fourth and the last test!"
                    + " In this test, there will be a correct patten which will unlock the door. "
                    + "Lookout for hints that may help you in solving the puzzle";
                break;
        }
    }

    private void LevelEndMessage(int level)
    {
        switch (level)
        {
            case 0:
                message = "Nice Work! Please proceed to the next test.";
                break;
            case 1:
                message = "Fantastic!";
                break;
            case 2:
                message = "Impressive! Your performance has exceed our expectation.";
                break;
        }
    }

    public void OffPathGameOver()
    {
        offPath = true;
    }
}