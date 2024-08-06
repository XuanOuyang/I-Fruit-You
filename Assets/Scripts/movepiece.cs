using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movepiece : MonoBehaviour
{
    public string pieceStatus = "";
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (pieceStatus != "locked" && isMoving)
        {
            Vector2 mousePoition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPoition = Camera.main.ScreenToWorldPoint(mousePoition);
            transform.position = objPoition;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == gameObject.name)
        {
            transform.position = other.gameObject.transform.position;
            pieceStatus = "locked";
            //update locked??
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
