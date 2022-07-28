using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]

public class ScreenBounds : MonoBehaviour
{
    public Camera mainCamera;
    BoxCollider2D boxCollider;

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
        transform.position = new Vector3(1, 0, 0);
        UpdateBoundsSize();
    }

    public void UpdateBoundsSize()
    {
        float ySize = mainCamera.orthographicSize * 2;
        Vector2 boxColliderSize = new Vector2(ySize * mainCamera.aspect - 2, ySize);
        boxCollider.size = boxColliderSize;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ExitTriggerFired?.Invoke(collision);
    }

    public bool AmIOutOfBounds(Vector3 worldPosition)
    {
        return
            Mathf.Abs(worldPosition.x) > Mathf.Abs(boxCollider.bounds.min.x) ||
            Mathf.Abs(worldPosition.y) > Mathf.Abs(boxCollider.bounds.min.y);

    }

    public Vector2 CalculateWrappedPosition(Vector2 worldPosition)
    {

        bool xLeftBoundResult =
            worldPosition.x < (boxCollider.bounds.min.x);
        bool xRightBoundResult =
            worldPosition.x > (boxCollider.bounds.max.x);
        bool yBoundResult =
            Mathf.Abs(worldPosition.y) > (Mathf.Abs(boxCollider.bounds.min.y));

        Vector2 signWorldPosition =
            new Vector2(Mathf.Sign(worldPosition.x), Mathf.Sign(worldPosition.y));
        Vector2 xOffset = new Vector2(2, 0);

        if ((xLeftBoundResult || xRightBoundResult) && yBoundResult)
        {
            return Vector2.Scale(worldPosition, Vector2.one * -1)
                    + Vector2.Scale(new Vector2(teleportOffset, teleportOffset),
                    signWorldPosition) 
                    + xOffset;
        }
        else if (xLeftBoundResult || xRightBoundResult)
        {
            return new Vector2(worldPosition.x * -1, worldPosition.y)
                + new Vector2(teleportOffset * signWorldPosition.x, 0)
                + xOffset;
        }
        else if (yBoundResult)
        {
            return new Vector2(worldPosition.x, worldPosition.y * -1)
                + new Vector2(0, teleportOffset * signWorldPosition.y);
        }
        else
        {
            return worldPosition;
        }
        
    }
}
