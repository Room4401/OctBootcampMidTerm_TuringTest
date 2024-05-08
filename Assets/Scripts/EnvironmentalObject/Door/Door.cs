using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour
{
    [SerializeField] private float waitTime = 0.5f;

    public UnityEvent OnDoorStateChange;
    public bool isLocked { get; private set; }

    private float timer = 0;
    private Animator doorAnim;

    private void Awake()
    {
        isLocked = true;
        doorAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isLocked)
        {
            timer = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isLocked) return;
        if (!other.CompareTag("Player")) return;

        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            timer = waitTime;
            doorAnim.SetBool("Door", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.SetBool("Door", false);
        }
    }

    public void UnlockDoor()
    {
        isLocked = false;
        OnDoorStateChange?.Invoke();
    }

    public void LockDoor()
    {
        isLocked = true;
        OnDoorStateChange?.Invoke();
    }
}