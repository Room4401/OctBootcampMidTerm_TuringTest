using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject messageTxt;

    private bool offPath = false;
    private string message;
    // Start is called before the first frame update
    void Start()
    {
        messageTxt.SetActive(false);
        GameManager.GetInstance().OnStateChange += SetMessage;
    }

    private void SetMessage(GameManager.GameState state) {
        StateMessage(state);
        messageTxt.GetComponentInChildren<TMP_Text>().text = message;
    }

    private void StateMessage(GameManager.GameState state)
    {
        switch (state)
        {
            case GameManager.GameState.Briefing:
                break;
            case GameManager.GameState.GameOver:
                if (offPath)
                {
                    message = "You have failed the test, as you have walked off the path.";
                }
                else
                {
                    message = "You have failed the test, as you have stepped on a pad twice.";
                }
                break;
            case GameManager.GameState.GameEnd:
                message = "Congratulation, You have Sucessfully passed the test.";
                break;
        }
    }

    public void LevelStartMessage(int level)
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
    
    public void LevelEndMessage(int level)
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