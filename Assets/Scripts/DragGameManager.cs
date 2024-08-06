using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragGameManager : MonoBehaviour
{
    public int totalPieces;
    public GameObject spriteToChange;
    private int currentLocked;

    // Start is called before the first frame update
    void Start()
    {
        currentLocked = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentLocked == totalPieces)
        {

        }
    }
}
