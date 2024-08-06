using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idk : MonoBehaviour
{
    public RectTransform rectTransform;

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("working");

        rectTransform.GetComponent<CanvasGroup>().alpha = 0f;
        rectTransform.GetComponent<DragDrop>().enabled = false;
    }
}