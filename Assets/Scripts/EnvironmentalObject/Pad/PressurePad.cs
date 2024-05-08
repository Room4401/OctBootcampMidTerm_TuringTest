using UnityEngine;
using UnityEngine.Events;

public class PressurePad : Pad
{
    [SerializeField] private LayerMask pickUpLayer;
    [SerializeField] private float checkRange;

    public UnityEvent OnPlaced, OnRemoved;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pickable"))
            CollisionCheck();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pickable"))
            CollisionCheck();
    }

    private void CollisionCheck()
    {
        Vector3 checkBox =
            GetComponent<Collider>().bounds.extents / 2;
        checkBox.y *= 3;

        Collider[] colliders =
            Physics.OverlapBox(transform.position,
            checkBox, Quaternion.identity, pickUpLayer);

        if (colliders == null || colliders.Length == 0)
        {
            TogglePad(false);
            OnRemoved?.Invoke();
            OnToggled?.Invoke(this);
            return;
        }

        foreach (Collider collider in colliders)
        {
            if (collider.gameObject.CompareTag("Pickable"))
            {
                TogglePad(true);
                OnPlaced?.Invoke();
                OnToggled?.Invoke(this);
                return;
            }
        }
    }
}