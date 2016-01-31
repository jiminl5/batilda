using UnityEngine;
using System.Collections;

public class ResultLael : MonoBehaviour {

    // Initial Scale X = 0, Y = 0
    // Expected Scale X = 1.2, Y = 1.2

    //Animation Value
    private float expect_Scale = 1.2f;
    private Vector3 current_angle;
    private float rotation_speed = 1000.0f;
    private float scaling_speed = 0.05f;
    //Animation Trigger
    public bool Label_Set = false;
	void Start () {
        Label_Set = false;
	}

    void Update() {
        if (!Label_Set 
        && GameObject.Find("results_parchment_left").GetComponent<ResultLeft>().Left_Set
        && GameObject.Find("results_parchment_right").GetComponent<ResultRight>().Right_Set)
        {
            this.transform.localScale += new Vector3(scaling_speed, scaling_speed, 0);
            this.transform.Rotate(new Vector3(0, 0, 3.6f) * Time.deltaTime * rotation_speed);
        }
        if (this.transform.localScale.x >= expect_Scale
        && this.gameObject.transform.localScale.y >= expect_Scale)
        {
            if (this.gameObject.transform.rotation.eulerAngles.z != 0.0f)
            {
                current_angle = this.gameObject.transform.eulerAngles;
                current_angle = new Vector3(
                    Mathf.LerpAngle(current_angle.x, 0.0f, Time.deltaTime),
                    Mathf.LerpAngle(current_angle.y, 0.0f, Time.deltaTime),
                    Mathf.LerpAngle(current_angle.z, 0.0f, Time.deltaTime * rotation_speed)
                );
                this.gameObject.transform.eulerAngles = current_angle;
            }
            Label_Set = true;
        }
    }
}
