/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    [SerializeField]
    private GameObject fruit; // GameObject holding the SpriteRenderer

    private SpriteRenderer fruitCondition;

    private int fruitState; // 0 - off, 1 - On

    [SerializeField]
    private Sprite[] switchSprites; // Array to hold the sprites to switch between

    private Image switchImage;

    private void Start()
    {
        // Initialize the SpriteRenderer component from the fruit GameObject
        fruitCondition = fruit.GetComponent<SpriteRenderer>();
        fruitState = 0;

        // Initialize the Button component
        switchImage = GetComponent<Button>().image;
        switchImage.sprite = switchSprites[fruitState]; // Set the initial sprite

        // Add a listener to the button to call TurnOnAndOff when clicked
        GetComponent<Button>().onClick.AddListener(TurnOnAndOff);
    }

    private void TurnOnAndOff()
    {
        // Toggle between 0 and 1
        fruitState = 1 - fruitState;

        // Update the sprite of the button and the fruit GameObject
        switchImage.sprite = switchSprites[fruitState];
        fruitCondition.sprite = switchSprites[fruitState];
    }
}*/
