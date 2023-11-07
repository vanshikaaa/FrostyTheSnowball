using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private GameManager gameManager;

    //public GameObject treeKiller;

    public float groundAngle = 0; // degrees
 
    public float treeSpeed = 30;

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
            transform.Translate(Vector3.forward * Time.deltaTime * treeSpeed * Mathf.Cos(groundAngle * Mathf.Deg2Rad), Space.World);
            transform.Translate(Vector3.up * Time.deltaTime * treeSpeed * Mathf.Sin(groundAngle * Mathf.Deg2Rad), Space.World);
        }
        
    }

    void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag == "dieTreeLol") 
        {
            gameManager.incrementScore();
            Destroy(gameObject);
        }

        /*

        ContactPoint contact = collision.contacts[0];
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 position = contact.point;
        Instantiate(explosionPrefab, position, rotation);
        Destroy(gameObject);
        */
    }
}
