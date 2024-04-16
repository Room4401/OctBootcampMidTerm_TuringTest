using UnityEngine;

public class PickUpAction : PlayerAction
{
    [SerializeField] private Transform attachTransform;
    [SerializeField] private RaycastAction raycastAction;

    private IPickable pickable;
    private bool isPicked = false;

    public override void TakeAction()
    {
        //Cast a ray
        if (raycastAction.RayActionCheck())
        {
            //Debug.Log("We hit " + raycastAction.hit.collider.name);
            //Debug.DrawRay(raycastAction.hit.origin, raycastAction.hit.distance, Color.red);
            if (playerInput.interactInput && !isPicked)
            {
                pickable = raycastAction.hit.transform.GetComponent<IPickable>();
                if (pickable == null) return;

                pickable.OnPicked(attachTransform);
                isPicked = true;
                return;
            }
        }
        if (playerInput.interactInput && isPicked && pickable != null)
        {
            pickable.OnDropped();
            isPicked = false;
        }
    }
}