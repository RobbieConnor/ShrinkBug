using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehaviour : MonoBehaviour
{

    public GameObject player;

    public string effectToApply;

    public GameObject spriteGameObject;

    public Sprite moveUpSprite;
    public Sprite bulletSpeedUpSprite;
    public Sprite atkSpeedUpSprite;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerHitbox");

        switch(effectToApply) {
            case "atkSpeedUp":
                spriteGameObject.GetComponent<SpriteRenderer>().sprite = atkSpeedUpSprite;
            break;
            case "bulletSpeedUp":
                spriteGameObject.GetComponent<SpriteRenderer>().sprite = bulletSpeedUpSprite;
            break;
            case "moveUp":
                spriteGameObject.GetComponent<SpriteRenderer>().sprite = moveUpSprite;
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col) {
        Debug.Log("COLLISION");
        if (col.gameObject == player) {
            applyEffect();
            Destroy(this.gameObject);
        }
    }

    void applyEffect() {
        switch (effectToApply) {
            case "atkSpeedUp":
                player.GetComponent<PlayerShootBehaviour>().gunCooldownMax -= (player.GetComponent<PlayerShootBehaviour>().gunCooldownMax * 0.1f);
            break;
            case "bulletSpeedUp":
                player.GetComponent<PlayerShootBehaviour>().bulletSpeed += (player.GetComponent<PlayerShootBehaviour>().bulletSpeed * 0.1f);
            break;
            case "moveUp":
                player.GetComponent<PlayerMovementBehaviour>().movementSpeed += (player.GetComponent<PlayerMovementBehaviour>().movementSpeed * 0.1f);
            break;
        }
    }
}
