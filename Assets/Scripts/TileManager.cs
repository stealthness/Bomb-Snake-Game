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
        Vector3Int playerpos = groundTilemap.WorldToCell(player.transform.position);
        TileBase tile = groundTilemap.GetTile(playerpos);
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
        string message = "Tiles:";
        Vector3Int playerpos = groundTilemap.WorldToCell(player.transform.position);
        TileBase tile = groundTilemap.GetTile(playerpos);
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
}
