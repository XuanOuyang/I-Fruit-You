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

    }

    void Update()
    {
        Button nextSlideButton = nextButton.GetComponent<Button>();

        // If it's at the last panel, will determine whether to immediately transition to the next
        // scene or wait for the button to be clicked
        if (currentPanelIndex == panels.Count - 1)
        {
            if (immediateTransition == false)
            {
                nextSlideButton.onClick.AddListener(OnClick);
            }
            else if (immediateTransition == true)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }

    public void NextSlide()
    {      
        if (isTransitioning == false && currentPanelIndex < panels.Count - 1)
        {
            int nextPanelIndex = currentPanelIndex + 1;
            StartCoroutine(Slide(currentPanelIndex, nextPanelIndex));
        }
    }

    private void OnClick()
    {
        SceneManager.LoadScene(nextScene);
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

        if (currentPanelIndex < panels.Count - 1 || immediateTransition == false)
        {
            nextButton.SetActive(true);
        }
    }
}
