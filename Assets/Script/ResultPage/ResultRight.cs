using UnityEngine;
using System.Collections;

public class ResultRight : MonoBehaviour {

    //Expected Position X = 4.5, Y = 0.5
    //Initial Postion X = 13.5, Y = 0.5

    //Animation Value
    private float expect_X = 4.5f;
    private float speed = 10.0f;

    //Trigger
    public bool Right_Set = false;

    //Canvas
    public GameObject right_canvas;

    public bool countdown_ready = false;

    void Start()
    {
        Right_Set = false;
        countdown_ready = false;
    }

    void Update()
    {
        if (!Right_Set)
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (this.gameObject.transform.position.x <= expect_X)
            Right_Set = true;
        if (Right_Set)
        {
            right_canvas.GetComponent<Canvas>().enabled = true;
            countdown_ready = true;
        }
    }
}
