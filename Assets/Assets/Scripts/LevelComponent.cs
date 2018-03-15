using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComponent : MonoBehaviour {

    public List<Rigidbody> enemiesToSpawn;
    public float spawnRate;
    public int numberOfEnemies;
    public long scorePenalty;

    public static int enemiesKilled;

    private float lastSpawnTime;
    private int enemiesSpawned;
    private float lastScorePenalty;
    
    private float spawnX;
    private float spawnZ;

    private Text scoreText;
    private Image goodImg;
    private Image badImg;

    private void Awake()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        lastScorePenalty = lastSpawnTime = Time.time;
    }

    private void Start()
    {
        goodImg = GameObject.FindGameObjectWithTag("LevelGoodImg").GetComponent<Image>();
        badImg = GameObject.FindGameObjectWithTag("LevelBadImg").GetComponent<Image>();
        goodImg.gameObject.SetActive(false);
        badImg.gameObject.SetActive(false);
    }

    void Update () {

        if (GameState.gameOver)
        {
            badImg.gameObject.SetActive(true);

            if (Input.GetButtonDown("Fire1"))
            {
                GameState.ResetGame();
            }
        }

        // if all enemies are dead, level complete
        if (enemiesKilled == numberOfEnemies)
        {
            // display level complete screen
            goodImg.gameObject.SetActive(true);

            // detect keypress to go to next scene
            if (Input.GetButtonDown("Fire1"))
            {
                enemiesKilled = 0;
                GameState.NextLevel();
            }
        }

        if (!goodImg.IsActive() &&
            !badImg.IsActive())
        {
            // spawn enemies if appriopriate
            if (enemiesSpawned < numberOfEnemies &&
                lastSpawnTime + spawnRate <= Time.time)
            {
                var enemyToSpawn = enemiesToSpawn[Random.Range(0, enemiesToSpawn.Count)];
                spawnX = Random.Range(-4.7f, 4.7f);
                spawnZ = Random.Range(2.8f, 4.7f);

                Instantiate(enemyToSpawn, new Vector3(spawnX, 0f, spawnZ), Quaternion.identity);

                enemiesSpawned++;
                lastSpawnTime = Time.time;
            }

            // reduce score over-time
            if (lastScorePenalty + 0.3f <= Time.time)
            {
                GameState.Score -= scorePenalty;
                lastScorePenalty = Time.time;
            }
        }

        // hack - complete level by pressing `
        if (Input.GetKeyDown("`"))
        {
            GameState.NextLevel();
        }

        scoreText.text = GameState.Score.ToString();
	}
}
