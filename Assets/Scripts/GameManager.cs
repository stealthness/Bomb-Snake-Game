using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI debugPosText;
    public TextMeshProUGUI debugTileText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateDebugText(string name, string message)
    {
        Debug.Log(message + "\n" +Random.Range(0, 1));
        switch (name)
        {
            case "position":
                debugPosText.text = message;
                break;
            case "tile":
                debugTileText.text = message;
                break;
            default:
                Debug.Log("no UI of that name " +message);
                break;
        }
    }


}


public enum MoveDirection{
    up, down, left, right, none
}