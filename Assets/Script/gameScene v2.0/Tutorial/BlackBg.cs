using UnityEngine;
using System.Collections;

public class BlackBg : MonoBehaviour {

    void OnMouseDown()
    {
        if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count < GameObject.Find("Main Camera").GetComponent<Tutorial>().cap)
            GameObject.Find("Main Camera").GetComponent<Tutorial>().count++;
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
            //print("Triggered HEReeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
            GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().RemoveAllTileColliders();
        }
    }
}
