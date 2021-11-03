using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("COLLISION");
        if (col.gameObject.tag == "Enemy") {
            Debug.Log("ENEMY");
            perishAndDealDamage(col.gameObject);
        }

        if (col.gameObject.tag == "Wall") {
            Debug.Log("WALL");
            Destroy(this.gameObject);
        }
    }

    void perishAndDealDamage(GameObject enemy) {
        enemy.GetComponent<EnemyBehaviour>().takeDamage(1);
        Destroy(this.gameObject);
    }
}
