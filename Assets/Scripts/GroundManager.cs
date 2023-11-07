using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public float scrollSpeed = 2.43f;
    Renderer rend;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer> ();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameRunning)
        {
            float offset = Time.time * scrollSpeed;
            rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
        }
        
    }
}