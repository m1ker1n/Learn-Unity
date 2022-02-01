using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public bool isPlayer = false;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (isPlayer)
        {
            gameObject.GetComponent<ScoreManager>().Decrement();
            gameObject.GetComponent<HealthManager>().Decrement();
            Destroy(other.gameObject);
        }
        else //gameObject is projectile
        {
            Destroy(gameObject);
            //Destroy(other.gameObject);
            Debug.Log("You fed a pet");
            other.gameObject.GetComponent<HungerManager>().Feed();
            player.GetComponent<ScoreManager>().Increment();
        }
    }
}
