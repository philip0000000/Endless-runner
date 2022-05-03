using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{
    public PlayerController playerController;
    //public BackgroundLoop backgroundLoop;
    //public GameObject Player;
    

    Sprite ObstacleSprite;
    int n = 0;

    // Start is called before the first frame update
    void Start()
    {
        ObstacleSprite = Resources.Load<Sprite>("img/Square");

        GameObject gameObject = new GameObject("Obstacle" + n, typeof(SpriteRenderer), typeof(BoxCollider2D));
        gameObject.transform.position = new Vector3(0, 0, -1);
        gameObject.tag = "Obstacle";
        SpriteRenderer ObstacleSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        ObstacleSpriteRenderer.sprite = ObstacleSprite;
        n++;
    }

    // Update is called once per frame
    void Update()
    {
        // loop throuth child objects

        // add score if we have passed obstacle
        //if (Player.transform.position.x + 1.0f > transform.position.x)
            //playerController.Score++;

        //Debug.Log(backgroundLoop.widthOfCamera / 2);
    }
}
