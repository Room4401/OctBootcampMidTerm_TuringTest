using UnityEngine;

public class DelayedSetActive : MonoBehaviour
{
    private float timer = 0;
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 0;
            gameObject.SetActive(false);
        }
    }

    public void Deactivate(float delay)
    {
        timer = delay;
    }
}