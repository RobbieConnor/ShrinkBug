using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootBehaviour : MonoBehaviour
{

    public float gunCooldown;
    public float gunCooldownMax;

    public float bulletSpeed;

    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gunCooldown > 0.0f) {
            gunCooldown -= Time.deltaTime;
        }
        
        if (Input.GetMouseButton(0)) {
            if (gunCooldown <= 0.0f) {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 playerPos = new Vector2 (transform.position.x, transform.position.y);
                Vector2 direction = mousePos - playerPos;
                direction.Normalize();
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
                gunCooldown = gunCooldownMax;
            }
            
        }
    }
}
