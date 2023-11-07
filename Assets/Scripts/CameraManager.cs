using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Vector3(0,20.4500008,44.2299995)
    // Vector3(0,14,35.6800003)

    public GameObject player;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }  

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameRunning) 
        {
            transform.position = new Vector3(player.gameObject.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
