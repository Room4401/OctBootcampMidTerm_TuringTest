using UnityEngine;
using UnityEngine.Events;

public class Targets : MonoBehaviour
{
    [SerializeField] private string projectileTag;

    public UnityEvent OnDestroy;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(projectileTag))
        {
            OnDestroy?.Invoke();
        }
    }
}