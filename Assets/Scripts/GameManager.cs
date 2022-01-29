using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI debugPosText;

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
        switch (name)
        {
            case "position":
                debugPosText.text = message;
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