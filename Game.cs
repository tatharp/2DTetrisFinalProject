using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public static int gridWidth = 10;
    public static int gridHeight = 20;

    // Start is called before the first frame update
    void Start()
    {
       SpawnNewPiece ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public bool CheckIsAboveGrid (Tetromino tetromino)
    {
        for (int x = 0; x < gridWidth; x++)
        {
            foreach (Transform mino in tetromino.transform)
            {
                Vector2 pos = Round(mino.position);

                if (pos.y > gridHeight - 1)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public bool IsFullRowAt (int y) // will check to see if a row is completely filled in
    {
        for (int x = 0; x < gridWidth; x++) // if there is no pieces at x++,y in any place, the row is not complete
        {
            if (grid[x,y] == null)
            {
                return false;
            }
        }
        return true; // otherwise, the row is complete
    }

    public void DeletePiece (int y) // will delete part of block that is connected to the line
    {
        for (int x = 0; x < gridWidth; x++)
        {
            Destroy(grid[x, y].gameObject); // delete the whole rows worth of pieces, resulting in a cleared line

            grid[x, y] = null; // the row will now be null
        }
    }

    public void moveRowDown (int y) // after the row has been deleted, the row above needs to move down
    {
        for (int x = 0; x < gridWidth; x++)
        {
            if (grid[x,y] != null)
            {
                grid[x, y - 1] = grid[x, y]; // move the piece down by one in each row

                grid[x, y] = null; // the place holder now is null

                grid[x, y - 1].position += new Vector3(0, -1, 0);
            }
        }
    }

    public void MoveAllRowsDown (int y)
    {
        for (int i = y; i < gridHeight; i++)
        {
            moveRowDown(i); // moves the rows down by the number of rows cleared (i)
        }
    }

    public void DeleteRow()
    {
        for (int y = 0; y < gridHeight; y++)
        {
            if (IsFullRowAt(y))
            {
                DeletePiece(y);

                MoveAllRowsDown(y + 1);

                y--;
            }
        }
    }

    public void UpdateGrid (Tetromino tetromino) // a sick 2d array
    {
        for (int y = 0; y < gridHeight; y++) // incrementing by y
        {
            for (int x = 0; x < gridWidth; x++) // incrementing by x
            {
                if (grid[x,y] != null) // if the x y coordinates are null
                {
                    if (grid[x,y].parent == tetromino.transform)
                    {
                        grid[x, y] = null;
                    }
                }
            }
        }
        foreach (Transform mino in tetromino.transform)
        {
            Vector2 pos = Round(mino.position);

            if (pos.y < gridHeight)
            {
                grid[(int)pos.x, (int)pos.y] = mino;
            }
        }
    }

    public Transform GetGridPosition (Vector2 pos)
    {
        if (pos.y > gridHeight -1)
        {
            return null;
        }
        else
        {
            return grid[(int)pos.x, (int)pos.y];
        }
    }
      public void SpawnNewPiece ()
    {
        GameObject nextPiece = (GameObject)Instantiate(Resources.Load(GetRandomPiece(), typeof(GameObject)), new Vector2(5.0f, 20.0f), Quaternion.identity);
    }

    public bool CheckIsInsideGrid (Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < gridWidth && (int)pos.y >= 0);
    }

    public Vector2 Round (Vector2 pos)
    {
        return new Vector2 (Mathf.Round(pos.x), Mathf.Round(pos.y));
    }
   string GetRandomPiece ()
    {
        int randomPiece = Random.Range(1, 8);

        string randomPieceName = "Prefab/Tetromino_T";

        switch (randomPiece)
        {
            case 1:
                randomPieceName = "Prefab/Tetromino_T";
                break;
            case 2:
                randomPieceName = "Prefab/Tetromino_Long";
                break;
            case 3:
                randomPieceName = "Prefab/Tetromino_Square";
                break;
            case 4:
                randomPieceName = "Prefab/Tetromino_J";
                break;
            case 5:
                randomPieceName = "Prefab/Tetromino_L";
                break;
            case 6:
                randomPieceName = "Prefab/Tetromino_S";
                break;
            case 7:
                randomPieceName = "Prefab/Tetromino_Z";
                break;
        }

        return randomPieceName;
    }
        public void GameOver ()
    {
        Application.LoadLevel("GameOver");
    }
}

