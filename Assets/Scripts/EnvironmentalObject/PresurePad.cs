using UnityEngine;
using UnityEngine.Events;

public class PresurePad : MonoBehaviour
{
    [SerializeField] private LayerMask pickUpLayer;
    [SerializeField] private float checkRange;

    public UnityEvent OnPlaced;
    public UnityEvent OnRemoved;

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRange, pickUpLayer);

        Debug.Log(colliders.Length);

        foreach (Collider collider in colliders)
        {
            Debug.Log(collider.gameObject.name);

            if (collision.gameObject.CompareTag("Pickable"))
            {
                Debug.Log("Placed");
                OnPlaced?.Invoke();
                break;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pickable"))
        {
            OnRemoved?.Invoke();
        }
    }
}