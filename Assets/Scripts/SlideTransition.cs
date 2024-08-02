using UnityEngine;
using UnityEngine.UI;

public class SlideTransition : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public float transitionDuration = 1.0f;
    private bool isTransitioning = false;

    void Start()
    {
        // Ensure Panel2 starts off-screen
        panel2.transform.position = new Vector2(panel2.transform.position.x, 0);
    }

    void Update()
    {
        // Example of triggering the transition with a key press
        if (Input.GetKeyDown(KeyCode.Space) && !isTransitioning)
        {
            StartCoroutine(Slide());
        }
    }

    System.Collections.IEnumerator Slide()
    {
        isTransitioning = true;
        float elapsedTime = 0f;

        Vector2 panel1StartPos = panel1.transform.position;
        Vector2 panel2StartPos = panel2.transform.position;
        Vector2 panel1EndPos = new Vector2(-20, 0);
        Vector2 panel2EndPos = Vector2.zero;

        while (elapsedTime < transitionDuration)
        {
            panel1.transform.position = Vector2.Lerp(panel1StartPos, panel1EndPos, elapsedTime / transitionDuration);
            panel2.transform.position = Vector2.Lerp(panel2StartPos, panel2EndPos, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        panel1.transform.position = panel1EndPos;
        panel2.transform.position = panel2EndPos;
        isTransitioning = false;
    }
}