using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int health;
    public int damage;

    public BugSpawnBehaviour bugSpawner;

    public TextControllerBehaviour textController;

    public GameObject basicDrop;
    // Start is called before the first frame update
    void Start()
    {
        textController = GameObject.Find("Text Controller").GetComponent<TextControllerBehaviour>();
        bugSpawner = GameObject.Find("Bug Spawner").GetComponent<BugSpawnBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damageAmount) {
        health -= damageAmount;

        if (health <= 0) {
            textController.increaseBugsBeat();
            perish();
        }
    }

    void perish() {
        Destroy(this.gameObject);

        var rng = new System.Random();

        var spawnItem = rng.Next(100);
        if (spawnItem >= 90) {

            var itemDropType = rng.Next(4);

            GameObject drop = Instantiate(basicDrop, transform.position, Quaternion.identity);

            if (itemDropType == 1) {
                drop.GetComponent<PowerUpBehaviour>().effectToApply = "atkSpeedUp";
            } else if (itemDropType == 2) {
                drop.GetComponent<PowerUpBehaviour>().effectToApply = "bulletSpeedUp";
            } else {
                drop.GetComponent<PowerUpBehaviour>().effectToApply = "moveUp";
            }
        }
        bugSpawner.checkForRemainingEnemies();
    }
}
