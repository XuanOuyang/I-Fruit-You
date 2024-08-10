using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MultiPanelSlideTransition : MonoBehaviour
{
    public List<GameObject> panels;
    public string nextScene;
    public bool immediateTransition = false;
    public float transitionDuration = 1.0f;
    private bool isTransitioning = false;
    private int currentPanelIndex = 0;

    void Start()
    {
        // Ensure all panels except the first start off-screen
        for (int i = 1; i < panels.Count; i++)
        {
            panels[i].transform.position = new Vector2(20, 0);
        }
    }

    void Update()
    {
        // Check for left mouse click or Xbox controller "B" button press
        if ((Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire2")) && !isTransitioning)
        {
            if (currentPanelIndex < panels.Count - 1)
            {
                int nextPanelIndex = currentPanelIndex + 1;
                StartCoroutine(Slide(currentPanelIndex, nextPanelIndex));
            }
            else
            {
                // Trigger scene transition when the last panel is already shown
                if (immediateTransition)
                {
                    LoadNextScene();
                }
                else if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire2"))
                {
                    LoadNextScene();
                }
            }
        }
    }

    IEnumerator Slide(int fromPanelIndex, int toPanelIndex)
    {
        isTransitioning = true;
        float elapsedTime = 0f;

        Vector2 fromPanelStartPos = panels[fromPanelIndex].transform.position;
        Vector2 toPanelStartPos = new Vector2(20, 0);
        Vector2 fromPanelEndPos = new Vector2(-20, 0);
        Vector2 toPanelEndPos = Vector2.zero;

        panels[toPanelIndex].transform.position = toPanelStartPos;

        while (elapsedTime < transitionDuration)
        {
            panels[fromPanelIndex].transform.position = Vector2.Lerp(fromPanelStartPos, fromPanelEndPos, elapsedTime / transitionDuration);
            panels[toPanelIndex].transform.position = Vector2.Lerp(toPanelStartPos, toPanelEndPos, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        panels[fromPanelIndex].transform.position = fromPanelEndPos;
        panels[toPanelIndex].transform.position = toPanelEndPos;

        currentPanelIndex = toPanelIndex;
        isTransitioning = false;
    }

    void LoadNextScene()
    {
        // Ensure the next scene name is valid and not empty
        if (!string.IsNullOrEmpty(nextScene))
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            Debug.LogError("Next scene name is not set or is empty!");
        }
    }
}
