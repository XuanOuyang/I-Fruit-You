using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighlightOnMouseOver : MonoBehaviour
{
    //private Color originalColor;
    //public Color highlightColor = Color.yellow;
    public Sprite hoverSprite;
    private Sprite originalSprite;

    public GameObject button;
    public GameObject tbdButton;

    public string nextScene;
    public bool inProgress = true;
    private bool inProgressButtonShow = false;

    private SpriteRenderer spriteRenderer;
    private bool isHighlighted = false;

    void Start()
    {
        // Get the SpriteRenderer component of the game object
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Save the original color of the game object
        //originalColor = spriteRenderer.color;
        originalSprite = spriteRenderer.sprite;

        Button btn = button.GetComponent<Button>();
        Button inProgressButton = tbdButton.GetComponent<Button>();
        if (!inProgress)
        {
            btn.onClick.AddListener(NextScene);
        } else
        {
            btn.onClick.AddListener(showInProgress);
        }
    }

    void Update()
    {
        // Create a ray from the camera to the mouse position
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        // Check if the ray hits any collider
        if (hit.collider != null)
        {
            // Check if the game object hit by the ray is this game object
            if (hit.collider.gameObject == gameObject)
            {
                if (!isHighlighted)
                {
                    // Change the color of the game object to the highlight color
                    //spriteRenderer.color = highlightColor;
                    spriteRenderer.sprite = hoverSprite;
                    isHighlighted = true;
                }
            }
            else
            {
                if (isHighlighted)
                {
                    // Revert the color of the game object to the original color
                    //spriteRenderer.color = originalColor;
                    spriteRenderer.sprite = originalSprite;
                    isHighlighted = false;
                }
            }
        }
        else
        {
            if (isHighlighted)
            {
                // Revert the color of the game object to the original color
                spriteRenderer.sprite = originalSprite;
                //spriteRenderer.color = originalColor;
                isHighlighted = false;
            }
        }
    }

    void NextScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    public void showInProgress()
    {
        if (inProgressButtonShow == true)
        {
            tbdButton.SetActive(false);
            inProgressButtonShow = false;
        } else if (inProgressButtonShow == false)
        {
            tbdButton.SetActive(true);
            inProgressButtonShow = true;
        }
    }
}
