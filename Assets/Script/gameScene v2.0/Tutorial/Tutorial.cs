using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

    private float pause_time = 0.0001f;
    public int count;
    int temp;
    bool next = false;

    public int cap;
    //If TUTORIAL LEVEL && Open sign is destroyed call this function
    void Start () {
        count = 0;
        temp = count;
        next = false;
        cap = 3;
    }
	
    public void TutDialogue()
    {
        next = false;
        if (count < cap)
        {
            Time.timeScale = pause_time;
            GameObject.Find("speechBubble").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("speechBubble").GetComponent<BoxCollider2D>().enabled = true;
            GameObject.Find("Batilda").GetComponent<SpriteRenderer>().sortingOrder = 10;
            GameObject.Find("bg_trans").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("bg_trans").GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (count == cap)
        {
            if (count == 3)
                GameObject.Find("meat").GetComponent<SpriteRenderer>().sortingOrder = 10;
            else if (count == 5)
                GameObject.Find("grill").GetComponent<SpriteRenderer>().sortingOrder = 10;
            else if (count == 7)
                GameObject.Find("firewood").GetComponent<SpriteRenderer>().sortingOrder = 10;
            else if (count == 9)
                GameObject.Find("furnace1_cheap").GetComponent<SpriteRenderer>().sortingOrder = 10;
            else if (count == 10)
                GameObject.Find("finished meat(Clone)").GetComponent<SpriteRenderer>().sortingOrder = 10;
            else if (count == 11)
                GameObject.Find("dish_1").GetComponent<SpriteRenderer>().sortingOrder = 10;
            if (count <= 13)
            {
                GameObject.Find("highlight").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("highlight").GetComponent<BoxCollider2D>().enabled = true;
            }
            else if (count > 13)
            {
                Destroy(GameObject.Find("highlight"));
            }
        }
    }

	// Update is called once per frame
	void Update () {
        if (temp < count)
        {
            print("COUNT:" + count);
            temp = count;
        }
        if (count == cap && !next)
        {
            TutDialogue();
            next = true;
        }
        if (count == 15)
        {
            Destroy(GameObject.Find("bg_trans"));
            Destroy(GameObject.Find("speechBubble"));
            Time.timeScale = 1.0f;
            GameObject.Find("Batilda").GetComponent<SpriteRenderer>().sortingOrder = 3;
            GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().Setup_Tile();
            GameObject.Find("Main Camera").GetComponent<Tutorial>().enabled = false;
        }
    }
}
