using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject[] treePrefabs = new GameObject[2];

    public float treeSpawnDelay = 0.8f;
    public Vector3 startPos = new Vector3(0,-7,-135);
    public float spawnRange = 10;

    public bool gameRunning = false;

    public GameObject gameOverScreen;
    public GameObject gameStartScreen;
    public GameObject controlsMenu;
    public TextMeshProUGUI timerDisplay;
    private float timer = 0.0f;
    private int score = 0;

    public ParticleSystem explosion;
    public ParticleSystem trail;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnTrees());
    }

    // Update is called once per frame
    void Update()
    {
        if(gameRunning)
        {
            timer += Time.deltaTime;

            //timerDisplay.text = string.Format("{0:00}:{1:00}:{2:000}", Mathf.FloorToInt(timer / 60), Mathf.FloorToInt(timer % 60), (timer % 1) * 1000);
            timerDisplay.text = "Score: " + score;
        }

        if(Input.GetKeyDown(KeyCode.Escape) ||
            Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.D))
        {
            controlsMenu.SetActive(false);
        }

    }

    public void incrementScore()
    {
        if (score < 100 && score >= 0)
        {
            score += 10;
        }
        else if (score < 250 && score >= 100)
        {
            score += 15;
        }
        else if (score < 450 && score >= 250)
        {
            score += 20;
        }
        else
        {
            score += 25;
        }
    }
    
    IEnumerator spawnTrees()
    {
        while (true) {
            yield return new WaitForSeconds(treeSpawnDelay);

            if(gameRunning)
            {
                int treeModel = Random.Range(0, 2);
                Instantiate(treePrefabs[treeModel], startPos + new Vector3(Random.Range(-spawnRange, spawnRange), 0, 0), treePrefabs[treeModel].transform.rotation);

            }
        }
    }

    public void startGame()
    {
        gameStartScreen.SetActive(false);
        controlsMenu.SetActive(true);
        timerDisplay.gameObject.SetActive(true);
        gameRunning = true;
    }

    public void endGame()
    {
        gameOverScreen.SetActive(true);
        Instantiate(explosion, player.gameObject.transform.position + new Vector3(0, 2, 0), player.gameObject.transform.rotation);
        Destroy(trail.gameObject);
    }

    public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    //TODO: faster trees, slower snowball
}
