﻿using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

    private float pause_time = 0.0001f;
    public int count;
    int temp;
    bool next = false;

    public int cap;

    GameObject[] waitressTile;
    //If TUTORIAL LEVEL && Open sign is destroyed call this function
    void Start () {
        count = 0;
        temp = count;
        next = false;
        cap = 1;
    }
	
    void SetTiles()
    {
        waitressTile = GameObject.FindGameObjectsWithTag("tile_red");
    }

    public void TutDialogue()
    {
        SetTiles();
        next = false;
        if (count < cap)
        {
            Time.timeScale = pause_time;
            if (cap <= 10)
            {
                GameObject.Find("speechBubble").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("speechBubble").GetComponent<BoxCollider2D>().enabled = true;
            }
            else {
                GameObject.Find("speechBubble_1").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("speechBubble_1").GetComponent<BoxCollider2D>().enabled = true;
            }
            GameObject.Find("Batilda").GetComponent<SpriteRenderer>().sortingOrder = 10;
            GameObject.Find("bg_trans").GetComponent<SpriteRenderer>().enabled = true;
            if (count == 0 || count == 1 || count == 5 || count == 12)
                GameObject.Find("bg_trans").GetComponent<BoxCollider2D>().enabled = true;
        }
        else if (count == cap && count != 6)
        {
            if (count == 2)
                GameObject.Find("meat").GetComponent<SpriteRenderer>().sortingOrder = 10;
            else if (count == 3)
                GameObject.Find("grill 1").GetComponent<SpriteRenderer>().sortingOrder = 10;
            else if (count == 4)
                GameObject.Find("firewood").GetComponent<SpriteRenderer>().sortingOrder = 10;
            else if (count == 5)
                GameObject.Find("furnace1_cheap").GetComponent<SpriteRenderer>().sortingOrder = 10;
            //else if (count == 7)
                //GameObject.Find("finished meat(Clone)").GetComponent<SpriteRenderer>().sortingOrder = 10;
            else if (count == 9)
            {
                GameObject.Find("dish_1").GetComponent<SpriteRenderer>().sortingOrder = 10;
                GameObject.Find("roast meat(Clone)(Clone)").GetComponent<SpriteRenderer>().sortingOrder = 11;
            }
            if (count <= 11)
            {
                GameObject.Find("highlight").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("highlight").GetComponent<BoxCollider2D>().enabled = true;
            }
            else if (count > 11)
            {
                Destroy(GameObject.Find("highlight"));
            }
        }
    }

	// Update is called once per frame
	void Update () {
        if (GameObject.Find("highlight").GetComponent<SpriteRenderer>().enabled)
        {
            GameObject.Find("speechBubble").GetComponent<BoxCollider2D>().enabled = false;
            GameObject.Find("speechBubble_1").GetComponent<BoxCollider2D>().enabled = false;
            GameObject.Find("text_cursor").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("text_cursor (1)").GetComponent<SpriteRenderer>().enabled = false;
        }
        if ((GameObject.Find("speechBubble").GetComponent<BoxCollider2D>().enabled || GameObject.Find("speechBubble_1").GetComponent<BoxCollider2D>().enabled) && count != 0)
        {
            for (int i = 0; i < waitressTile.Length; i++)
            {
                waitressTile[i].GetComponent<BoxCollider2D>().enabled = false;
            }
        }

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
        if (count == 13)
        {
            Destroy(GameObject.Find("bg_trans"));
            Destroy(GameObject.Find("speechBubble"));
            Destroy(GameObject.Find("speechBubble_1"));
            Time.timeScale = 1.0f;
            GameObject.Find("Batilda").GetComponent<SpriteRenderer>().sortingOrder = 3;
            GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().Setup_Tile();
            //OpenSignAnim.confirm_tutorial_start = false;
            CircleHighLight.customerCame = false;
            GameObject.Find("Main Camera").GetComponent<Tutorial>().enabled = false;
            PlayerPrefs.SetString("tutorial", "no");
        }
    }
}
