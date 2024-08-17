using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MultiPanelSlideTransition : MonoBehaviour
{
    public List<GameObject> panels;
    public string nextScene;
    public bool immediateTransition;
    public GameObject nextButton;
    public float transitionDuration = 1.0f;
    private bool isTransitioning = false;
    private int currentPanelIndex = 0;

    void Start()
    {
        // Ensure all panels except the first start off-screen equidistant to (0, 0)
        for (int i = 1; i < panels.Count; i++)
        {
            panels[i].transform.position = new Vector2(20, 0);
        }

        Button nextSlideButton = nextButton.GetComponent<Button>();
    }

    void Update()
    {
        // Trigger the transition with the a click
        /*if (Input.GetMouseButtonDown(0) && !isTransitioning && currentPanelIndex < panels.Count - 1)
        {
            int nextPanelIndex = currentPanelIndex + 1;
            StartCoroutine(Slide(currentPanelIndex, nextPanelIndex));
        }

        // Go to the next scene at the end of slideshow
        if (currentPanelIndex == panels.Count-1)
        {
            if (immediateTransition == false && Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(nextScene);
            } else if (immediateTransition == true)
            {
                SceneManager.LoadScene(nextScene);
            }
        }*/
    }

    public void NextSlide()
    {
        if (!isTransitioning && currentPanelIndex < panels.Count - 1)
        {
            int nextPanelIndex = currentPanelIndex + 1;
            StartCoroutine(Slide(currentPanelIndex, nextPanelIndex));
        }

        // Go to the next scene at the end of slideshow
        if (currentPanelIndex == panels.Count - 1)
        {
            if (immediateTransition == false && Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(nextScene);
            }
            else if (immediateTransition == true)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }

    IEnumerator Slide(int fromPanelIndex, int toPanelIndex)
    {
        isTransitioning = true;
        nextButton.SetActive(false);

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
        nextButton.SetActive(true);
    }
}
