using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public bool isPlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isPlayer)
        {
            Debug.Log("Game Over!!! Player died of Stampede");
            Destroy(other.gameObject);
        }
        else
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
