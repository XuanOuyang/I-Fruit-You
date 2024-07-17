using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MultiPanelSlideTransition : MonoBehaviour
{
    public List<RectTransform> panels;
    public float transitionDuration = 1.0f;
    private bool isTransitioning = false;
    private int currentPanelIndex = 0;

    void Start()
    {
        // Ensure all panels except the first start off-screen
        for (int i = 1; i < panels.Count; i++)
        {
            panels[i].anchoredPosition = new Vector2(panels[0].rect.width, 0);
        }
    }

    void Update()
    {
        // Trigger the transition with the spacebar
        if (Input.GetKeyDown(KeyCode.Space) && !isTransitioning)
        {
            int nextPanelIndex = (currentPanelIndex + 1) % panels.Count;
            StartCoroutine(Slide(currentPanelIndex, nextPanelIndex));
        }
    }

    IEnumerator Slide(int fromPanelIndex, int toPanelIndex)
    {
        isTransitioning = true;
        float elapsedTime = 0f;

        Vector2 fromPanelStartPos = panels[fromPanelIndex].anchoredPosition;
        Vector2 toPanelStartPos = new Vector2(panels[fromPanelIndex].rect.width, 0);
        Vector2 fromPanelEndPos = new Vector2(-panels[fromPanelIndex].rect.width, 0);
        Vector2 toPanelEndPos = Vector2.zero;

        panels[toPanelIndex].anchoredPosition = toPanelStartPos;

        while (elapsedTime < transitionDuration)
        {
            panels[fromPanelIndex].anchoredPosition = Vector2.Lerp(fromPanelStartPos, fromPanelEndPos, elapsedTime / transitionDuration);
            panels[toPanelIndex].anchoredPosition = Vector2.Lerp(toPanelStartPos, toPanelEndPos, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        panels[fromPanelIndex].anchoredPosition = fromPanelEndPos;
        panels[toPanelIndex].anchoredPosition = toPanelEndPos;

        currentPanelIndex = toPanelIndex;
        isTransitioning = false;
    }
}
