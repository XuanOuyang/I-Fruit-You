using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class AirportScript : MonoBehaviour, IDropHandler
{
    public string nextScene;

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