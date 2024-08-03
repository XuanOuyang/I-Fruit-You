using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{

    private float CurrentTime;
    public float speed = 0.2f;

    public RectTransform rectTransform;

    public Vector3 startpos;
    public Vector3 endpos;

    // Start is called before the first frame update
    void Start()
    {
        //x to y over time and values are basically 1 over 1second would turn to 2
        //0 to 1
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime = CurrentTime + Time.deltaTime;

        rectTransform.localPosition = Vector3.Lerp(startpos, endpos, CurrentTime * speed);
    }
}
