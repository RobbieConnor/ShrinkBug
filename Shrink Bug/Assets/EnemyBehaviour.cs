using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int health;
    public int damage;

    public BugSpawnBehaviour bugSpawner;

    public TextControllerBehaviour textController;
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
        bugSpawner.checkForRemainingEnemies();
    }
}
