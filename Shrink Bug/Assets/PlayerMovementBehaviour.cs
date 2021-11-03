using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{

    public float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = transform.position;
        Vector3 newPos = new Vector3(currentPos.x, currentPos.y, currentPos.z);
        if (Input.GetKey(KeyCode.W)) {
            newPos += new Vector3(0, movementSpeed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) {
            newPos += new Vector3(0, -movementSpeed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) {
            newPos += new Vector3(-movementSpeed, 0, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) {
            newPos += new Vector3(movementSpeed, 0, 0) * Time.deltaTime;
        }

        transform.position = newPos;
    }
}
