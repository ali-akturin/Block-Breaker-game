using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    [SerializeField]float ScreenWidthinUnits=16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    //cached reference
    Ball theball;
    GameSession thegamesession;
	void Start () {
        theball = FindObjectOfType<Ball>();
        thegamesession = FindObjectOfType<GameSession>();
    }
	
	// Update is called once per frame
	void Update () {
        
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
	}
    private float GetXPos()
    {
      
        if (thegamesession.IsAutoPlayEnabled())
        {
            return theball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / ScreenWidthinUnits;
        }
    }
}
