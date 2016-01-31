using UnityEngine;
using System.Collections;

public class ResultLeft : MonoBehaviour {

    //Expected Position X = -4.5, Y = 0.5
    //Initial Postion X = -13.5, Y = 0.5

    //Animation Value
    private float expect_X = -4.5f;
    private float speed = 10.0f;

    //Trigger
    public bool Left_Set = false;

	void Start () {
        Left_Set = false;
	}
	
	void Update () {
        if (!Left_Set)
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (this.gameObject.transform.position.x >= expect_X)
            Left_Set = true;
	}
}
