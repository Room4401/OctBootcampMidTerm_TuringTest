using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    public UnityEvent OnTriggered;

    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if(!isTriggered && other.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
            OnTriggered?.Invoke();
        }
    }
}