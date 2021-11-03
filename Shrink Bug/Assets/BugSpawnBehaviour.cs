using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawnBehaviour : MonoBehaviour
{

    public int waveNumber = 0;

    public GameObject basicBug;

    public float checkForEnemiesCountdown;
    public float checkForEnemiesMax = 2.0f;

    public int numberOfEnemiesToSpawn;

    public float enemySpawnTimer;
    public float enemySpawnTimerMax;


    // Start is called before the first frame update
    void Start()
    {
        checkForEnemiesCountdown = checkForEnemiesMax;
    }

    // Update is called once per frame
    void Update()
    {
        checkForEnemiesCountdown -= Time.deltaTime;
        enemySpawnTimer -= Time.deltaTime;

        if (numberOfEnemiesToSpawn > 0) {
            if (enemySpawnTimer <= 0.0f) {
                var rng = new System.Random();
                enemySpawnTimer = (float)rng.NextDouble();
                spawnEnemy(basicBug);
                numberOfEnemiesToSpawn--;
            }
        }

        if (checkForEnemiesCountdown <= 0.0f) {
            checkForEnemiesCountdown = checkForEnemiesMax;
            checkForRemainingEnemies();
        }
    }

    public void checkForRemainingEnemies() {
        GameObject[] remainingEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (remainingEnemies.Length <= 0) {
            if (numberOfEnemiesToSpawn <= 0) {
                waveNumber++;
                generateNewWave();
            }
        }
    }

    void spawnEnemy(GameObject enemyToSpawn) {
        var rng = new System.Random();

        Vector3 spawnerPos = transform.position;
        float xRandDiff = rng.Next(6) + (float)rng.NextDouble() - 2.5f;
        Vector3 newPos = new Vector3(spawnerPos.x + xRandDiff, spawnerPos.y, spawnerPos.z);
        GameObject newBug = Instantiate(basicBug, newPos, Quaternion.identity);

        if (enemyToSpawn == basicBug) {
            var leftOrRight = rng.Next(2);
            if (leftOrRight == 0) {
                newBug.GetComponent<BugBehaviour>().goingRight = false;
            } else {
                newBug.GetComponent<BugBehaviour>().goingRight = true;
            }
        }
    }

    void generateNewWave() {
        numberOfEnemiesToSpawn = waveNumber;
    }
}
