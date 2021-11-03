using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugBehaviour : MonoBehaviour
{
    public float LRMovementSpeed;
    public float DownMovementSpeed;

    public EnemyBehaviour enemyBehaviour;
    
    public GameObject generalStats;
    
    public bool goingRight = false;
    

    // Start is called before the first frame update
    void Start()
    {
        generalStats = GameObject.Find("GeneralStats");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 oldPos = transform.position;
        Vector3 newPos = new Vector3(oldPos.x, oldPos.y, oldPos.z);
        if (goingRight) {
            newPos += new Vector3(LRMovementSpeed, 0, 0) * Time.deltaTime;
        } else {
            newPos += new Vector3(-LRMovementSpeed, 0, 0) * Time.deltaTime;
        }

        newPos += new Vector3(0, -DownMovementSpeed, 0) * Time.deltaTime;

        transform.position = newPos;
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Wall") {
            goingRight = !goingRight;
        }

        if (col.gameObject.tag == "DamageHitbox") {
            perishAndDealDamage();
        }
    }

    void perishAndDealDamage() {
        generalStats.GetComponent<GeneralStatsBehaviour>().playerHealth -= enemyBehaviour.damage;
        Destroy(this.gameObject);
    }
}
