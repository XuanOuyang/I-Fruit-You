using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CursorController : MonoBehaviour
{
    public float cursorSpeed = 5f; // Speed at which the cursor moves
    public string xboxAButton = "joystick button 0"; // "A" button on Xbox controller

    private RectTransform cursorRectTransform;
    private GameObject draggedObject = null; // The object being dragged
    private bool isDragging = false;

    void Start()
    {
        cursorRectTransform = GetComponent<RectTransform>(); // Get the RectTransform component
    }

    void Update()
    {
        MoveCursor();
        HandleMouseClick();
    }

    void MoveCursor()
    {
        // Get controller input for cursor movement (left stick)
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector2 moveDirection = new Vector2(moveX, moveY);

        // Update the cursor position in UI space
        cursorRectTransform.anchoredPosition += moveDirection * cursorSpeed * Time.deltaTime;

        // If dragging, move the object with the cursor
        if (isDragging && draggedObject != null)
        {
            Vector3 cursorWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(cursorRectTransform.position.x, cursorRectTransform.position.y, Camera.main.nearClipPlane));
            draggedObject.transform.position = new Vector3(cursorWorldPosition.x, cursorWorldPosition.y, draggedObject.transform.position.z);
        }
    }

    void HandleMouseClick()
    {
        // Check if the "A" button on the Xbox controller is pressed
        if (Input.GetKeyDown(xboxAButton))
        {
            // Start drag if clicking on a draggable object
            StartDrag();
        }
        else if (Input.GetKeyUp(xboxAButton))
        {
            // Release the object when the button is released
            EndDrag();
        }
    }

    void StartDrag()
{
    Vector2 clickPosition = cursorRectTransform.anchoredPosition;
    PointerEventData eventData = new PointerEventData(EventSystem.current)
    {
        position = clickPosition
    };

    List<RaycastResult> results = new List<RaycastResult>();
    EventSystem.current.RaycastAll(eventData, results);

    Debug.Log("Raycast results count: " + results.Count); // Debug: Check how many objects are being detected

    foreach (RaycastResult result in results)
    {
        Debug.Log("Hit object: " + result.gameObject.name); // Debug: Log the object names that are being hit

        // Check if the object is draggable
        if (result.gameObject != null)
        {
            isDragging = true;
            draggedObject = result.gameObject;
            Debug.Log("Dragging object: " + draggedObject.name); // Debug: Confirm that dragging has started
            break;
        }
    }
}

    void EndDrag()
    {
        if (isDragging)
        {
            isDragging = false;
            draggedObject = null;
        }
    }
}
