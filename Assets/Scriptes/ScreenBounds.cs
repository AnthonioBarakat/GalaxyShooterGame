using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// The line below will add a BoxCollider2D to every game object attached this script `ScreenBounds`
[RequireComponent(typeof(BoxCollider2D))]
public class ScreenBounds : MonoBehaviour
{
    public Camera mainCamera;
    public BoxCollider2D boxCollider;

    public UnityEvent<Collider2D> ExitTriggerFired;

    [SerializeField]
    private float teleportOffset = 0.2f;

    private void Awake()
    {
        this.mainCamera.transform.localScale = Vector3.one;
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
    }

    private void Start()
    {
        transform.position = Vector3.zero;
        UpdateBoundsSize();
    }

    public void UpdateBoundsSize()
    {
        // orhtographic size = half the size of the height of the screen. =>
        float ySize = mainCamera.orthographicSize * 2;
        // width of the camera depends on height y and the aspect ratio
        Vector2 boxColliderSize = new Vector2(ySize * mainCamera.aspect, ySize);
        boxCollider.size = boxColliderSize;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ExitTriggerFired?.Invoke(collision);        
    }

    public bool AmIOutOfBounds(Vector3 worldPosition)
    {
        return Mathf.Abs(worldPosition.x) > Mathf.Abs(boxCollider.bounds.min.x) ||
               Mathf.Abs(worldPosition.y) > Mathf.Abs(boxCollider.bounds.min.y);
    }

    public Vector2 CalculateWrappedPosition(Vector2 worldPosition)
    {
        bool xBoundresult = Mathf.Abs(worldPosition.x) > Mathf.Abs(boxCollider.bounds.min.x - 1);
        bool yBoundresult = Mathf.Abs(worldPosition.y) > Mathf.Abs(boxCollider.bounds.min.y - 1);

        Vector2 signWorldPosition = new Vector2(Mathf.Sign(worldPosition.x), Mathf.Sign(worldPosition.y));

        if (xBoundresult && yBoundresult)
        {
            return Vector2.Scale(worldPosition, Vector2.one * -1) + 
                    Vector2.Scale(new Vector2(teleportOffset, teleportOffset), signWorldPosition);
        }

        else if (xBoundresult)
        {
            return new Vector2(worldPosition.x * -1, worldPosition.y) +
                    new Vector2(teleportOffset * signWorldPosition.x, teleportOffset);
        }
        else if (yBoundresult)
        {
            return new Vector2(worldPosition.x, worldPosition.y * -1) +
                    new Vector2(teleportOffset, teleportOffset * signWorldPosition.y);
        }
        else
        {
            return worldPosition;
        }
    }

}
