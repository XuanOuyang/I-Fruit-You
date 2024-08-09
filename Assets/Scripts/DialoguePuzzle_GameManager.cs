using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialoguePuzzle_GameManager : MonoBehaviour
{
    public List<GameObject> allPuzzlePieces;
    public string nextScene;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int currPiecesLocked = 0;
        // Not the most efficient way, but checks locked state of all puzzle pieces each update
        for (int i = 0; i < allPuzzlePieces.Count; i++)
        {
            if (allPuzzlePieces[i].GetComponent<movepiece>().lockedStatus)
            {
                currPiecesLocked++;
                Debug.Log("what's the lock status: " + currPiecesLocked);
            }
            // Once all pieces are locked, it does the next thing
            if (currPiecesLocked == allPuzzlePieces.Count)
            {
                SceneManager.LoadScene(nextScene);
                Debug.Log("all pieces are locked!");
            }
        }
        // check the locked state of each puzzle piece, if every puzzle piece is locked
        // 1. make a bubble of that puzzle appear as a talking thing 2. wait a moment, then go to the next puzzle/scene

    }
}
