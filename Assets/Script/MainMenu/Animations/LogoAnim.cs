using UnityEngine;
using System.Collections;

public class LogoAnim : MonoBehaviour {

    private Vector3 wobble_effect_1 = new Vector3(0f, 0f, 5f);
    private Vector3 wobble_effect_2 = new Vector3(0f, 0f, 355f);

    private Vector3 current_angle;

    private bool wobble;

    public float wobble_acc = 3.0f;

    // Use this for initialization
    void Start () {
        current_angle = this.gameObject.transform.eulerAngles;
        wobble = true;
        Time.timeScale = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (wobble)
        {
            current_angle = new Vector3(
            Mathf.LerpAngle(current_angle.x, wobble_effect_1.x, Time.deltaTime),
            Mathf.LerpAngle(current_angle.y, wobble_effect_1.y, Time.deltaTime),
            Mathf.LerpAngle(current_angle.z, wobble_effect_1.z, Time.deltaTime * wobble_acc));
            this.gameObject.transform.eulerAngles = current_angle;

            if (this.gameObject.transform.rotation.eulerAngles.z >= 4.2f && this.gameObject.transform.rotation.eulerAngles.z < 355.8f)
            {
                wobble = false;
            }
        }

        else if (!wobble)
        {
            current_angle = new Vector3(
            Mathf.LerpAngle(current_angle.x, wobble_effect_2.x, Time.deltaTime),
            Mathf.LerpAngle(current_angle.y, wobble_effect_2.y, Time.deltaTime),
            Mathf.LerpAngle(current_angle.z, wobble_effect_2.z, Time.deltaTime * wobble_acc));
            this.gameObject.transform.eulerAngles = current_angle;

            if (this.gameObject.transform.rotation.eulerAngles.z <= 355.8f && this.gameObject.transform.rotation.eulerAngles.z > 4.2f)
            {
                wobble = true;
            }
        }
    }
}
