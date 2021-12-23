using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Bounds
{
    public float lower;
    public float upper;
}

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;

    public float speed = 20.0f;
    public Bounds xBounds = new Bounds { lower = -23.0f, upper = 23.0f };
    public Bounds zBounds = new Bounds { lower = -1.5f, upper = 16.0f };

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchProjectile();
        }

        Move();
    }

    private void LaunchProjectile()
    {
        //launch a projectile from the player
        Debug.Log("Space pressed");
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
    }

    private void Move()
    {
        //bad code???
        if (transform.position.x > xBounds.upper)
        {
            transform.position = new Vector3(xBounds.upper, transform.position.y, transform.position.z);
        }
        if (transform.position.x < xBounds.lower)
        {
            transform.position = new Vector3(xBounds.lower, transform.position.y, transform.position.z);
        }
        if (transform.position.z > zBounds.upper)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBounds.upper);
        }
        if (transform.position.z < zBounds.lower)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBounds.lower);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
    }
}
