﻿using UnityEngine;
using System.Collections;

public class BlackBg : MonoBehaviour {
    
    void Update()
    {
        if (GameObject.Find("highlight").GetComponent<SpriteRenderer>().enabled ||
         GameObject.Find("highlight").GetComponent<BoxCollider2D>().enabled)
         {
            GameObject.Find("bg_trans").GetComponent<BoxCollider2D>().enabled = false;
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
            ////////////////////////////////////
            GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().RemoveAllTileColliders();
        }
    }
}
