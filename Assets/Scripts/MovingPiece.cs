using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPiece : MonoBehaviour
{
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }
    }

    void OnMouseDown()
    {
        isMoving = true;
    }

    void OnMouseUp()
    {
        isMoving = false;
    }

    void OnMouseExit()
    {
        if (isMoving)
        {
            isMoving = false;
        }
    }
}
