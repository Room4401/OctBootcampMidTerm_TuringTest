using UnityEngine;

public class DelayedSetActive : MonoBehaviour
{
    private float timer = 0;
    private bool active = false;
    private void Update()
    {
        timer -= Time.deltaTime;
        if (active && timer < 0)
        {
            timer = 0;
            active = false;
            gameObject.SetActive(false);
        }
    }

    public void Deactivate(float delay)
    {
        active = true;
        timer = delay;
    }
}