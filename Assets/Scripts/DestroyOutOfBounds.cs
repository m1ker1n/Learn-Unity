using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Bounds
{
    public float lower;
    public float upper;

    public bool IsInBounds(float x)
    {
        return (x >= lower && x <= upper);
    }
}

public class DestroyOutOfBounds : MonoBehaviour
{
    private Bounds xBounds = new Bounds { lower = -30.0f, upper = 30.0f };
    private Bounds zBounds = new Bounds { lower = -20.0f, upper = 25.0f };

    // Update is called once per frame
    void Update()
    {
        if (!(xBounds.IsInBounds(transform.position.x) && zBounds.IsInBounds(transform.position.z)))
        {
            if (transform.position.z < zBounds.lower) Debug.Log("Game Over!!! Animal Escaped");
            Destroy(gameObject);
        }
    }
}
