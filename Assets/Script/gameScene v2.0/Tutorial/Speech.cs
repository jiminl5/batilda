using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Speech : MonoBehaviour {
    public Text speech_text;
    public Text speech_text1;
    private bool start_speech = true;

    public Text key_text;

    void Update()
    {
        if (start_speech)
        {
            if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 0 && GameObject.Find("speechBubble").GetComponent<SpriteRenderer>().enabled)
            {
                speech_text.enabled = true;
                speech_text.text = "We're open for business! First, let's wait for a <color=#B43104><b>customer</b></color>...";
                start_speech = false;
            }
        }
        if (!GameObject.Find("speechBubble").GetComponent<SpriteRenderer>().enabled)
            speech_text.enabled = false;
        if (GameObject.Find("speechBubble").GetComponent<SpriteRenderer>().enabled)
        {
            if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 1)
            {
                speech_text.enabled = true;
                speech_text.text = "Looks like the customer wants some <color=#B43104><b>steak</b></color>! Let’s get cooking!";
            }
            else if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 2)
            {
                speech_text.enabled = true;
                speech_text.text = "Tap an <color=#B43104><b>ingredient</b></color> to have Foxanna pick it up. For steak, we need some <color=#B43104><b>beef</b></color>!";
            }
            else if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 3)
            {
                speech_text.enabled = true;
                speech_text.text = "Tap the <color=#B43104><b>grill</b></color> to start cooking the beef.";
            }
            else if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 4)
            {
                speech_text.enabled = true;
                speech_text.text = "Oh wait! In order for the appliances to work, I need to keep the furnace running! First, I need to grab a <color=#B43104><b>log</b></color>...";
            }
            else if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 5 && !GameObject.Find("fire_0").GetComponent<SpriteRenderer>().enabled)
            {
                speech_text.enabled = true;
                speech_text.text = "...and then throw it into the <color=#B43104><b>furnace</b></color>!";
            }
            else if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 5 && GameObject.Find("fire_0").GetComponent<SpriteRenderer>().enabled)
            {
                speech_text.enabled = true;
                speech_text.text = "Great! Now the grill is hot and we just have to wait for the meat to <color=#B43104><b>cook</b></color>...!";
            }
            else if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 7)
            {
                speech_text.enabled = true;
                speech_text.text = "It’s done! Tap to pick up the finished steak. Don’t let it <color=#B43104><b>burn</b></color> on the grill!";
            }
            else if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 8)
            {
                speech_text.enabled = true;
                speech_text.text = "Now that it’s ready, set it down on a <color=#B43104><b>warming plate</b></color>.";
            }
            else if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 9)
            {
                speech_text.enabled = true;
                speech_text.text = "Once it’s on a warming plate, I can pick it up...";
            }
            else if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 10)
            {
                speech_text.enabled = true;
                speech_text.text = "...and deliver it to the customer!";
            }
        }
        else if (GameObject.Find("speechBubble_1").GetComponent<SpriteRenderer>().enabled)
        {
            if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 11)
            {
                speech_text1.enabled = true;
                speech_text1.text = "Perfect! The last thing we have to do is pick up the <color=#B43104><b>payment</b></color>.";
            }
            else if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 12)
            {
                speech_text1.enabled = true;
                speech_text1.text = "I think we’re ready! Time to make this <color=#B43104><b>Cavern</b></color> into a real <color=#B43104><b>Tavern</b></color>!";
            }
        }
    }
    void OnMouseDown()
    {
        if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 0)
        {
            GameObject.Find("speechBubble").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("speechBubble").GetComponent<BoxCollider2D>().enabled = false;
            GameObject.Find("bg_trans").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("bg_trans").GetComponent<BoxCollider2D>().enabled = false;
            GameObject.Find("Main Camera").GetComponent<Tutorial>().count++;
            GameObject.Find("Main Camera").GetComponent<Tutorial>().cap = 2;
            Time.timeScale = 1.0f;
            GameObject.Find("Map").GetComponent<TileMap1>().GenerateMapData();
            GameObject.Find("Map").GetComponent<TileMap1>().GeneratePathfindingGraph();
            GameObject.Find("Map").GetComponent<TileMap1>().GenerateMapVisual();
            GameObject.Find("Batilda").GetComponent<SpriteRenderer>().sortingOrder = 4;
        }
        else if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count < GameObject.Find("Main Camera").GetComponent<Tutorial>().cap)
        {
            if (CircleHighLight.customerCame)
                GameObject.Find("Main Camera").GetComponent<Tutorial>().count++;
        }
        if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 6)
        {
            GameObject.Find("speechBubble").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("speechBubble").GetComponent<BoxCollider2D>().enabled = false;
            GameObject.Find("bg_trans").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("bg_trans").GetComponent<BoxCollider2D>().enabled = false;
            GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().Setup_Tile();
            GameObject.Find("Main Camera").GetComponent<Tutorial>().cap = 7; // Increase the size of CAP
            Time.timeScale = 1.0f;
            GameObject.Find("highlight").GetComponent<CircleHighLight>().NextMoveBool();
            GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().RemoveAllTileColliders();
        }
    }

}
