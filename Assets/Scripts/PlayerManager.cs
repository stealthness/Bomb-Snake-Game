using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerManager : MonoBehaviour
{
    private readonly float actionDelay = 0.5f;
    private readonly float inputTol = 0.1f;
    private readonly int MAX_X = 7;
    private readonly int MIN_X = -8;
    private readonly int MAX_Y = 3;
    private readonly int MIN_Y = -4;


    private float elapsedTime = 0f;

    public GameManager gameManager;
    public GameObject player;
    public Tilemap objectTilemap;
    public Tilemap groundTilemap;
    public TileManager tileManager;

    Vector3Int playerTilePos;

    // Start is called before the first frame update
    void Start()
    {

        player.transform.position = groundTilemap.CellToLocal(Vector3Int.zero)+ new Vector3(0.5f, 0.5f, 0f);
        playerTilePos = Vector3Int.zero;
        gameManager.debugPosText.text = string.Format("({0}, {1})", playerTilePos.x, playerTilePos.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime > actionDelay)
        {
            MoveDirection direction = GetInputDirection();

            if (CheckMoveIsValid(direction)) // check valid move
            {
                TranslatePlayer(direction);
                elapsedTime = 0f;
            }
            
        }
        elapsedTime += Time.deltaTime;
    }

    private void TranslatePlayer(MoveDirection direction)
    {
        Vector3Int vectorDirection = Vector3Int.zero;
        switch (direction)
        {
            case MoveDirection.up:
                vectorDirection = Vector3Int.up;
                break;
            case MoveDirection.down:
                vectorDirection = Vector3Int.down;
                break;
            case MoveDirection.left:
                vectorDirection = Vector3Int.left;
                break;
            case MoveDirection.right:
                vectorDirection = Vector3Int.right;
                break;
            default:
                return;
                //vectorDirection = Vector3Int.zero;
                //break;
        }
        playerTilePos = playerTilePos + vectorDirection;
        player.transform.Translate(vectorDirection);
        gameManager.debugPosText.text = string.Format("({0}, {1})", playerTilePos.x, playerTilePos.y);
        tileManager.UpdateTileManager();
    }

    private MoveDirection GetInputDirection()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if (Mathf.Abs(x) > inputTol && Mathf.Abs(x) > Mathf.Abs(y))
        {         
            return Mathf.Sign(x) < 0 ? MoveDirection.left: MoveDirection.right;
        }
        if (Mathf.Abs(y) > inputTol && Mathf.Abs(y) > Mathf.Abs(x))
        {         
            return Mathf.Sign(y) > 0 ? MoveDirection.up: MoveDirection.down;
        }
        return MoveDirection.none;
       
    }

    private bool CheckMoveIsValid(MoveDirection direction)
    {
        bool inBounds = true;
        string message = "Invalid -> ";
        switch (direction)
        {        
           case MoveDirection.up:
                message += "UP";
                inBounds = playerTilePos.y < MAX_Y;
                break;
            case MoveDirection.down:
                inBounds = playerTilePos.y > MIN_Y;
                message += "Down";
                break;
            case MoveDirection.left:
                inBounds = playerTilePos.x > MIN_X;
                message += "LEFT";
                break;
            case MoveDirection.right:
                message += "RIGHT";
                inBounds = playerTilePos.x < MAX_X;
                break;
            default:
                message += "None";
                return false;
        }
        if (!inBounds)
        {
            Debug.Log(string.Format("{0}, y:{1}, MAX_Y:{2}", message, playerTilePos.y, MAX_Y));
            
        }
        return inBounds;
        
    }


    public Vector3Int GetPlayCellPosition()
    {
        return playerTilePos;
    }
}
