using UnityEngine;
using System.Collections;

public class OpenSignAnim : MonoBehaviour
{

    private Rigidbody rb;
    private BoxCollider bc;
    private float fall_speed = -10.0f;

    bool start = false;

    private float pause_timer;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        bc = this.GetComponent<BoxCollider>();
        rb.velocity = new Vector3(0, fall_speed, 0);
        start = true;
        pause_timer = Time.time; // started time
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.y < 4.215f && this.gameObject.transform.position.x == 7.79999f && start)
        {
            bc.enabled = false;
            rb.detectCollisions = false;
            rb.isKinematic = true;
            Destroy(GameObject.Find("openSign_collider"));
            start = false;
        }
        else if (!start && ((pause_timer + 3.5f <= Time.time))) // pause about 3.5 seconds
        {
            this.transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
            this.transform.Translate(Vector3.right * 15.0f * Time.deltaTime); // Slide off speed 15.0f

            if (this.gameObject.transform.position.x >= 20f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
