using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    private int n = 0;
    private float NumberOfBackgroundWindows = 0.0f;
    public Camera MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float verticalSize = Camera.main.orthographicSize * 2.0f;
        float width = verticalSize * Screen.width / Screen.height;
        float HowManyBackgroundWindowsDoWeNeed = width / 20;
        Debug.Log(HowManyBackgroundWindowsDoWeNeed);
    }

    void CreateBackgroundImage(float x)
    {
        GameObject gameObject = new GameObject("Background_" + n);
        n++;
    }
}
