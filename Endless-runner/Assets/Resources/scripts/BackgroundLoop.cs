using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject background;
    private Camera mainCamera;
    private Vector2 screenBounds;
    private float verticalSizeOfCamera;
    public float widthOfCamera;

    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        verticalSizeOfCamera = Camera.main.orthographicSize * 2.0f;
        widthOfCamera = verticalSizeOfCamera * Screen.width / Screen.height;

        InitializeBackground();
    }
    void InitializeBackground()
    {
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        loadChildObjects(background);
    }
    void DestroyBackground()
    {
        while (background.transform.childCount > 0)
        {
            DestroyImmediate(background.transform.GetChild(0).gameObject);
        }
    }

    void loadChildObjects(GameObject obj)
    {
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x;
        int childsNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth);
        GameObject clone = Instantiate(obj) as GameObject;
        if (childsNeeded > 10) // no more then 10 background children
            childsNeeded = 10;
        for (int i = 0; i <= childsNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        //Destroy(obj.GetComponent<SpriteRenderer>());
    }

    void Update()
    {
        float currentSizeOfCamera = verticalSizeOfCamera * Screen.width / Screen.height;
        if (widthOfCamera != currentSizeOfCamera)
        {
            widthOfCamera = currentSizeOfCamera;
            Debug.Log("Do something!");
            DestroyBackground();
            InitializeBackground();
        }
    }

    void LateUpdate()
    {
        repositionChildObjects(background);
    }
    void repositionChildObjects(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();
        if (children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x;
            if (transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            }
            else if (transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }
        }
    }
}
