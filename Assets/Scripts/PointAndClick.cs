using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointAndClick : MonoBehaviour
{
    public List<Sprite> sprites; // List of sprites
    public Button myButton; // Existing button within scene
    public string nextScene;

    [SerializeField]
    private GameObject obj; // GameObject holding the SpriteRenderer, GameObject sprite to change
    private SpriteRenderer currSprite; // Current sprite

    [SerializeField]

    private int currentImageIndex = 0;
    private int totalImageIndex;

    void Start()
    {
        Button btn = myButton.GetComponent<Button>();
        totalImageIndex = sprites.Count-1;

        // Initialize the SpriteRenderer component from the GameObject
        currSprite = obj.GetComponent<SpriteRenderer>();
        currentImageIndex = 0;

        // Button listens to call NextImage when 
        btn.onClick.AddListener(NextImage);
    }

    void NextImage()
    {
        if (currentImageIndex >= totalImageIndex)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            currentImageIndex++;
           
            // Update the sprite of the GameObject
            currSprite.sprite = sprites[currentImageIndex];
        }
    }
}