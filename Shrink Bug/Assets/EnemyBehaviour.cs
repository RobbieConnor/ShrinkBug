using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int health;
    public int damage;

    public BugSpawnBehaviour bugSpawner;
    // Start is called before the first frame update
    void Start()
    {
        bugSpawner = GameObject.Find("Bug Spawner").GetComponent<BugSpawnBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damageAmount) {
        health -= damageAmount;

        if (health <= 0) {
            perish();
        }
    }

    void perish() {
        Destroy(this.gameObject);
        bugSpawner.checkForRemainingEnemies();
    }
}
