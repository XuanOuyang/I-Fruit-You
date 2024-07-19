using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler {

    [SerializeField] private GameObject image;

    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
        Debug.Log(eventData.pointerDrag);

            if (eventData.pointerDrag != null)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            }
            if (eventData.pointerDrag.GetComponent<CanvasGroup>().alpha == 0.999f)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.GetComponent<CanvasGroup>().alpha = 0f;
                eventData.pointerDrag.GetComponent<DragDrop>().enabled = false;
            }

            if (eventData.pointerDrag.GetComponent<CanvasGroup>().alpha == 0.998f)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.GetComponent<DragDrop>().enabled = false;
            }
           
    }
}
