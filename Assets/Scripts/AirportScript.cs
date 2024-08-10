using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class AirportScript : MonoBehaviour, IDropHandler
{
    public string nextScene;
    public RectTransform cursor; // Reference to the cursor RectTransform
    private DraggableItem selectedItem; // The item currently selected by the controller

    void Update()
    {
        // Check for Xbox controller "A" button press to pick up or drop an item
        if (Input.GetButtonDown("Fire1")) // "Fire1" typically maps to the "A" button
        {
            HandleDragAndDrop();
        }
    }

    void HandleDragAndDrop()
    {
        if (selectedItem == null)
        {
            // Try to pick up an item
            TryPickUpItem();
        }
        else
        {
            // Drop the item if one is selected
            TryDropItem();
        }
    }

    void TryPickUpItem()
    {
        // Perform a 2D raycast using the cursor's collider
        RaycastHit2D hit = Physics2D.Raycast(cursor.position, Vector2.zero);

        if (hit.collider != null)
        {
            DraggableItem draggableItem = hit.collider.GetComponent<DraggableItem>();
            if (draggableItem != null)
            {
                selectedItem = draggableItem;
                selectedItem.OnPickUp(); // Call the OnPickUp method in DraggableItem
            }
        }
    }

    void TryDropItem()
    {
        selectedItem.OnDrop(); // Call the OnDrop method in DraggableItem
        selectedItem = null;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
            Invoke("NextScene", 0.5f);
        }
        else
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();

            GameObject current = transform.GetChild(0).gameObject;
            DraggableItem currentDraggable = current.GetComponent<DraggableItem>();

            currentDraggable.transform.SetParent(draggableItem.parentAfterDrag);
            draggableItem.parentAfterDrag = transform;
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
