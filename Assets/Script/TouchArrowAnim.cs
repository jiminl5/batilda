using UnityEngine;
using System.Collections;

public class TouchArrowAnim : MonoBehaviour {

    private float initial_X;
    private float speed = 1.0f;
    private bool left;
	// Use this for initialization
	void Start () {
        initial_X = this.gameObject.transform.position.x;
        left = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.gameObject.transform.position.x < initial_X + 0.3f && !left)
        {
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (this.gameObject.transform.position.x >= initial_X + 0.3f)
                left = true;
        }
        else if (left && this.gameObject.transform.position.x > initial_X - 0.3f)
        {
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (this.gameObject.transform.position.x <= initial_X - 0.3f)
                left = false;
        }
    }
}
