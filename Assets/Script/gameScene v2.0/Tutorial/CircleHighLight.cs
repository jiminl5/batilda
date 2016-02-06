using UnityEngine;
using System.Collections;

public class CircleHighLight : MonoBehaviour
{
    public bool increase = true;

    bool next = false;

    void Start()
    {
        increase = true;
        next = false;
    }

    void OnMouseDown()
    {
        print("???????????");
        GameObject.Find("speechBubble").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("speechBubble").GetComponent<BoxCollider2D>().enabled = false;
        GameObject.Find("Batilda").GetComponent<SpriteRenderer>().sortingOrder = 3;
        GameObject.Find("bg_trans").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("bg_trans").GetComponent<BoxCollider2D>().enabled = false;
        
        //Disable Touch on Circle
        GameObject.Find("highlight").GetComponent<SpriteRenderer>().enabled = false;
        GameObject.Find("highlight").GetComponent<BoxCollider2D>().enabled = false;

        if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == GameObject.Find("Main Camera").GetComponent<Tutorial>().cap
            && GameObject.Find("Main Camera").GetComponent<Tutorial>().cap == 3)
        {
            initializeTile();
            TutorialMove(0, 6);
            GameObject.Find("meat").GetComponent<SpriteRenderer>().sortingOrder = 1;
            GameObject.Find("highlight").transform.position = new Vector2(3.2f, 4.0f); //Location of Highlight Circle
            GameObject.Find("Main Camera").GetComponent<Tutorial>().cap = 5;  // Increase the size of CAP
        }
        else if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == GameObject.Find("Main Camera").GetComponent<Tutorial>().cap
            && GameObject.Find("Main Camera").GetComponent<Tutorial>().cap == 5)
        {
            GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().Setup_Tile();
            TutorialMove(2, 4);
            GameObject.Find("grill").GetComponent<SpriteRenderer>().sortingOrder = 2;
            GameObject.Find("highlight").transform.position = new Vector2(14.9f, 3.8f);
            GameObject.Find("Main Camera").GetComponent<Tutorial>().cap = 7; // Increase the size of CAP
        }
        //Waitress
        else if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == GameObject.Find("Main Camera").GetComponent<Tutorial>().cap
            && GameObject.Find("Main Camera").GetComponent<Tutorial>().cap == 7)
        {
            GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().Setup_Tile();
            TutorialMove(10, 4);
            GameObject.Find("grill").GetComponent<SpriteRenderer>().sortingOrder = 5;
            GameObject.Find("highlight").transform.position = new Vector2(8.9f, 6.5f);
            GameObject.Find("Main Camera").GetComponent<Tutorial>().cap = 9; // Increase the size of CAP
        }
        else if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == GameObject.Find("Main Camera").GetComponent<Tutorial>().cap
            && GameObject.Find("Main Camera").GetComponent<Tutorial>().cap == 9)
        {
            GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().Setup_Tile();
            TutorialMove(6, 6);
            GameObject.Find("furnace1_cheap").GetComponent<SpriteRenderer>().sortingOrder = 2;
            GameObject.Find("highlight").transform.position = new Vector2(3.2f, 4.0f);
            GameObject.Find("Main Camera").GetComponent<Tutorial>().cap = 10; // Increase the size of CAP
        }
        else if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == GameObject.Find("Main Camera").GetComponent<Tutorial>().cap
            && GameObject.Find("Main Camera").GetComponent<Tutorial>().cap == 10)
        {
            GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().Setup_Tile();
            TutorialMove(2, 4);
            GameObject.Find("finished meat(Clone)").GetComponent<SpriteRenderer>().sortingOrder = 5;
            GameObject.Find("highlight").transform.position = new Vector2(7.4f, 6.0f);
            GameObject.Find("Main Camera").GetComponent<Tutorial>().cap = 11; // Increase the size of CAP
        }
        else if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == GameObject.Find("Main Camera").GetComponent<Tutorial>().cap
            && GameObject.Find("Main Camera").GetComponent<Tutorial>().cap == 11)
        {
            GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().Setup_Tile();
            TutorialMove(5, 6);
            GameObject.Find("highlight").transform.position = new Vector2(7.4f, 6.0f); //Stay at mid Tile
            GameObject.Find("Main Camera").GetComponent<Tutorial>().cap = 12; // Increase the size of CAP
        }
        else if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == GameObject.Find("Main Camera").GetComponent<Tutorial>().cap
        && GameObject.Find("Main Camera").GetComponent<Tutorial>().cap == 12)
        {
            GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().Setup_Tile();
            TutorialMove(5, 6);
            GameObject.Find("dish_1").GetComponent<SpriteRenderer>().sortingOrder = 5;
            GameObject.Find("highlight").transform.position = new Vector2(11.8f, 2.5f); //Stay at mid Tile
            GameObject.Find("Main Camera").GetComponent<Tutorial>().cap = 13; // Increase the size of CAP
        }
        //Last
        else if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == GameObject.Find("Main Camera").GetComponent<Tutorial>().cap
        && GameObject.Find("Main Camera").GetComponent<Tutorial>().cap == 13)
        {
            GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().Setup_Tile();
            TutorialMove(8, 2);
            GameObject.Find("highlight").transform.position = new Vector2(11.8f, 2.5f); //Stay at mid Tile
            GameObject.Find("Main Camera").GetComponent<Tutorial>().cap = 15;
        }
    }

    void initializeTile()
    {
        //CHEF - tile
        GameObject.Find("Map").GetComponent<TileMap>().GenerateMapData();
        GameObject.Find("Map").GetComponent<TileMap>().GeneratePathfindingGraph();
        GameObject.Find("Map").GetComponent<TileMap>().GenerateMapVisual();
        //WAITRESS - tile
        GameObject.Find("Map").GetComponent<TileMap1>().GenerateMapData();
        GameObject.Find("Map").GetComponent<TileMap1>().GeneratePathfindingGraph();
        GameObject.Find("Map").GetComponent<TileMap1>().GenerateMapVisual();
    }

    void TutorialMove(int mtx, int mty)
    {
        Time.timeScale = 1.0f;

        if (mtx == 0 && mty == 6) //Pick up MEAT
        {
            GameObject.Find("Map").GetComponent<TileMap>().GeneratePathTo(1, 5);
            GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().mtX = mtx;
            GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().mtY = mty;
            ChefQueueAction();
        }
        else if (mtx == 2 && mty == 4) // Drop Meat on GRILL
        {
            GameObject.Find("Map").GetComponent<TileMap>().GeneratePathTo(1, 4);
            GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().mtX = mtx;
            GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().mtY = mty;
            ChefQueueAction();
        }
        //Waitress
        else if (mtx == 10 && mty == 4) // Pick up FireWood
        {
            GameObject.Find("Map").GetComponent<TileMap1>().GeneratePathTo(9, 4);
            GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().mtX = mtx;
            GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().mtY = mty;
            WaitressQueueAction();
        }
        else if (mtx == 6 && mty == 6) // Drop FireWood
        {
            GameObject.Find("Map").GetComponent<TileMap1>().GeneratePathTo(6, 5);
            GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().mtX = mtx;
            GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().mtY = mty;
            //GameObject.Find("Main Camera").GetComponent<Tutorial>().count++;
            WaitressQueueAction();
        }
        else if (mtx == 8 && mty == 2) // Drop FireWood
        {
            GameObject.Find("Map").GetComponent<TileMap1>().GeneratePathTo(8, 3);
            GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().mtX = mtx;
            GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().mtY = mty;
            //GameObject.Find("Main Camera").GetComponent<Tutorial>().count++;
            WaitressQueueAction();
        }

        //Mid Tile
        else if (mtx == 5 && mty == 6) // Mid Chef
        {
            if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 11)
            {
                GameObject.Find("Map").GetComponent<TileMap>().GeneratePathTo(4, 5);
                GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().mtX = mtx;
                GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().mtY = mty;
                ChefQueueAction();
            }
            if (GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 12)
            {
                GameObject.Find("Map").GetComponent<TileMap1>().GeneratePathTo(6, 5);
                GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().mtX = mtx;
                GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().mtY = mty;
                WaitressQueueAction();
            }
        }
        next = true;
    }

    void ChefQueueAction()
    {
        //QUEUE ACTION
        if (GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().findGameObjectAtClickedPosition() != null
        || (GameObject.Find("Map").GetComponent<TileMap>().same_spot && GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().findGameObjectAtClickedPosition() != null))
        {
            Chef.obj_queue.Enqueue(GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().findGameObjectAtClickedPosition());
        }
        else if (GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().findGameObjectAtClickedPosition() == null
        || (GameObject.Find("Map").GetComponent<TileMap>().same_spot && GameObject.FindGameObjectWithTag("Chef").GetComponent<Chef>().findGameObjectAtClickedPosition() == null))
        {
            Chef.obj_queue.Enqueue(GameObject.Find("Null_Object"));
        }
    }

    void WaitressQueueAction()
    {
        //QUEUE ACTION
        if (GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition() != null
        || (GameObject.Find("Map").GetComponent<TileMap1>().same_spot && GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition() != null))
        {
            Waitress.obj_queue1.Enqueue(GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition());
        }
        else if (GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition() == null
        || (GameObject.Find("Map").GetComponent<TileMap1>().same_spot && GameObject.FindGameObjectWithTag("Waitress").GetComponent<Waitress>().findGameObjectAtClickedPosition() == null))
        {
            Waitress.obj_queue1.Enqueue(GameObject.Find("Null_Object"));
        }
    }

    void Update()
    {
        if (increase)
        {
            this.transform.localScale += new Vector3(0.005f, 0.005f, 0);
            if (this.transform.localScale.x >= 0.6f && this.transform.localScale.y >= 0.6f)
                increase = false;
        }
        if (!increase)
        {
            this.transform.localScale -= new Vector3(0.005f, 0.005f, 0);
            if (this.transform.localScale.x <= 0.4f && this.transform.localScale.y <= 0.4f)
                increase = true;
        }

        if (next)
        {
            if (GameObject.Find("Unit").transform.position.x == 1.5f && GameObject.Find("Unit").transform.position.y == 5.0f
            && GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 3)
            {
                GameObject.Find("Main Camera").GetComponent<Tutorial>().TutDialogue();
                GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().RemoveAllTileColliders();
                next = false;
            }
            else if (GameObject.Find("Unit").transform.position.x == 1.5f && GameObject.Find("Unit").transform.position.y == 4.0f
            && GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 5)
            {
                GameObject.Find("Main Camera").GetComponent<Tutorial>().TutDialogue();
                GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().RemoveAllTileColliders();
                next = false;
            }
            else if (GameObject.Find("Unit1").transform.position.x == 13.5f && GameObject.Find("Unit1").transform.position.y == 4.0f
            && GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 7)
            {
                GameObject.Find("Main Camera").GetComponent<Tutorial>().TutDialogue();
                GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().RemoveAllTileColliders();
                next = false;
            }
            else if (GameObject.Find("grill").GetComponent<cookingObject>().food_ready
            && GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 9)
            {
                GameObject.Find("Main Camera").GetComponent<Tutorial>().TutDialogue();
                GameObject.Find("Main Camera").GetComponent<Tutorial>().count++;
                GameObject.Find("Main Camera").GetComponent<Tutorial>().TutDialogue();
                GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().RemoveAllTileColliders();
                next = false;
            }
            else if (GameObject.Find("Chef").GetComponent<Chef>().one_h == "roast meat food"
            && GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 10)
            {
                GameObject.Find("Main Camera").GetComponent<Tutorial>().TutDialogue();
                GameObject.Find("Main Camera").GetComponent<Tutorial>().count++;
                GameObject.Find("Main Camera").GetComponent<Tutorial>().TutDialogue();
                GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().RemoveAllTileColliders();
                next = false;
            }
            else if (GameObject.Find("Unit").transform.position.x == 6.0f && GameObject.Find("Unit").transform.position.y == 5.0f
            && GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 11)
            {
                GameObject.Find("Main Camera").GetComponent<Tutorial>().TutDialogue();
                GameObject.Find("Main Camera").GetComponent<Tutorial>().count++;
                GameObject.Find("Main Camera").GetComponent<Tutorial>().TutDialogue();
                GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().RemoveAllTileColliders();
                next = false;
            }
            else if (GameObject.Find("Batilda").GetComponent<Waitress>().one_h == "roast meat food"
            && GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 12)
            {
                GameObject.Find("Main Camera").GetComponent<Tutorial>().TutDialogue();
                GameObject.Find("Main Camera").GetComponent<Tutorial>().count++;
                GameObject.Find("Main Camera").GetComponent<Tutorial>().TutDialogue();
                GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().RemoveAllTileColliders();
                next = false;
            }
            else if (GameObject.Find("Unit1").transform.position.x == 12.0f && GameObject.Find("Unit1").transform.position.y == 3.0f
            && GameObject.Find("Main Camera").GetComponent<Tutorial>().count == 13)
            {
                GameObject.Find("Main Camera").GetComponent<Tutorial>().TutDialogue();
                GameObject.Find("Main Camera").GetComponent<Tutorial>().count++;
                GameObject.Find("Main Camera").GetComponent<Tutorial>().TutDialogue();
                GameObject.Find("tmp_invisibleTile(Clone)").GetComponent<MoveableTile>().RemoveAllTileColliders();
                next = false;
            }
        }
    }
}
