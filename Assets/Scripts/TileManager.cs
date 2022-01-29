using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{

    public TextMeshProUGUI tileText;
    public GameObject player;
    public GameManager gameManager;
    public Tilemap groundTilemap;
    public Tilemap objectTilemap;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string message = "Tiles:";
        Vector3Int playerPos = groundTilemap.WorldToCell(player.transform.position);
        //Vector3Int playerpos = groundTilemap.WorldToCell(player.transform.position);
        message = playerPos + " " + message + "\n";
        TileBase tile = groundTilemap.GetTile(playerPos);
        if (tile == null)
        {
            message += "null";
        }
        else
        {
            message += " " + tile.name;
        }
        tileText.text = message;
    }

    public void UpdateTileManager()
    {
        string message = "ground tiles: ";
        Vector3Int playerpos = groundTilemap.WorldToCell(player.transform.position);
        TileBase groundTile = groundTilemap.GetTile(playerpos);
        TileBase objectTile = objectTilemap.GetTile(playerpos);
        if (groundTile == null)
        {
            message += "none";
        }
        else
        {
            message += " " + groundTile.name;
        }
        message += " \n object tile: ";
        if (objectTile == null)
        {
            message += "none";
        }
        else
        {
            message += " " + objectTile.name;
        }
        Debug.Log("UpdateTileManager -> \nplayer pos: " + player.transform.position
            +"\n(1)");
        gameManager.UpdateDebugText("tile", message.ToString());
    }
}
