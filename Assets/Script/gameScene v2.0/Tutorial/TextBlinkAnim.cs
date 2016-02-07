using UnityEngine;
using System.Collections;

public class TextBlinkAnim : MonoBehaviour {

    public GameObject speech_bubble;

    private bool up = true;

    void Update()
    {
        if (speech_bubble.GetComponent<SpriteRenderer>().enabled == true)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            if (speech_bubble.name.ToString() == "speechBubble")
            {
                if (up)
                {
                    this.transform.localPosition += new Vector3(0, 0.005f, 0);
                    if (this.transform.localPosition.y >= -1.28f)
                        up = false;
                }
                if (!up)
                {
                    this.transform.localPosition -= new Vector3(0, 0.005f, 0);
                    if (this.transform.localPosition.y <= -1.36f)
                        up = true;
                }
            }
            if (speech_bubble.name.ToString() == "speechBubble_1")
            {
                if (up)
                {
                    this.transform.localPosition += new Vector3(0, 0.005f, 0);
                    if (this.transform.localPosition.y >= 0.23f)
                        up = false;
                }
                if (!up)
                {
                    this.transform.localPosition -= new Vector3(0, 0.005f, 0);
                    if (this.transform.localPosition.y <= 0.15f)
                        up = true;
                }
            }
        }
        else if (speech_bubble.GetComponent<SpriteRenderer>().enabled == false)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
