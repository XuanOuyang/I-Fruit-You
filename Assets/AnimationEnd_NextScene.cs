using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnd_NextScene : MonoBehaviour
{
    public string nextScene;

    public void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
    }
}
