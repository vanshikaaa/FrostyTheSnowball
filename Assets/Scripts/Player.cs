using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;

    public float horizontalInput;

    public float speed = 20f;
    public float speedReduceMultiplier = 1f;
    public float rotateSpeed = 500f;
    public float gameBarrier = 10;

    public float sizeScale = 0.05f;
    public float maxSize = 6.2f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameRunning) 
        {
            horizontalInput = Input.GetAxis("Horizontal");

            if (transform.position.x >= gameBarrier && horizontalInput > 0)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed * horizontalInput, Space.World);
            }
            
            if (transform.position.x <= -gameBarrier && horizontalInput < 0)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed * horizontalInput, Space.World);
            }
            
            if (transform.position.x >= -gameBarrier && transform.position.x <= gameBarrier)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed * horizontalInput, Space.World);
            }

            transform.Rotate(-rotateSpeed * Time.deltaTime, 0, 0);
            transform.eulerAngles = new Vector3(
                    transform.eulerAngles.x,
                    -Mathf.Atan2(horizontalInput, 1),
                    transform.eulerAngles.z);

            
            if (transform.localScale.x < maxSize)
            {
                transform.localScale += new Vector3(2 * Time.deltaTime * sizeScale, 
                                                2 * Time.deltaTime * sizeScale, 
                                                2 * Time.deltaTime * sizeScale);
                transform.Translate(Vector3.up * 2f * Time.deltaTime * sizeScale * Mathf.Sin(20 * Mathf.Deg2Rad), Space.World);
                speed -= speedReduceMultiplier * Time.deltaTime;
                Debug.Log(speed);
            }
            
            //transform.Translate(Vector3.back * 0.2f * Time.deltaTime * sizeScale * Mathf.Cos(20 * Mathf.Deg2Rad));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("tree"))
        {
            gameManager.gameRunning = false;
            gameManager.endGame();
            Destroy(gameObject);
        }
    }
}
