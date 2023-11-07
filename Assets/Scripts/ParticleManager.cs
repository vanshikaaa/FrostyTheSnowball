using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public GameObject player;
    private GameManager gameManager;
    private float horizontalInput;

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
            horizontalInput = Input.GetAxis("Horizontal");

            transform.position = new Vector3(player.gameObject.transform.position.x, transform.position.y, transform.position.z);
        
            transform.eulerAngles = new Vector3(
                    transform.eulerAngles.x,
                    (Mathf.Atan2(horizontalInput, 1) * Mathf.Rad2Deg),
                    transform.eulerAngles.z);
        }
    }
}
