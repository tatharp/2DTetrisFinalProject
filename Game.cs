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
}

