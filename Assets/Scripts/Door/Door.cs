using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private int toggleCount;
    [SerializeField] private float waitTime = 0.5f;

    public bool isLocked { get; private set; }

    private int toggledSwitch;
    private float timer = 0;
    private Animator doorAnim;

    private void Awake()
    {
        doorAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        UnlockDoor();
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

    private void UnlockDoor()
    {
        if (toggledSwitch >= toggleCount)
            isLocked = false;
        else
            isLocked = true;
    }

    public void ToggleIncrease()
    {
        toggledSwitch++;
    }

    public void ToggleDecrease()
    {
        if (toggledSwitch <= 0)
            return;
        toggledSwitch--;
    }
}