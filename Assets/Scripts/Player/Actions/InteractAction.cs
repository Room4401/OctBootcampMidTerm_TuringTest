using UnityEngine;

public class InteractAction : PlayerAction
{
    [SerializeField] private RaycastAction raycastAction;

    private ISelectable selection;

    public override void TakeAction()
    {
        if (raycastAction.RayActionCheck())
        {
            //Debug.Log("We hit " + raycastAction.hit.collider.name);
            //Debug.DrawRay(raycastAction.hit.origin, raycastAction.hit.distance, Color.red);
            selection = raycastAction.hit.transform.GetComponent<ISelectable>();
            if (selection != null)
            {
                selection.OnHoverEnter();
                if (playerInput.interactInput)
                {
                    selection.OnSelect();
                }
            }
        }
        if (raycastAction.hit.transform == null && selection != null)
        {
            selection.OnHoverExit();
            selection = null;
        }
    }
}