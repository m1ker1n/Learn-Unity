using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxLives;

    public int Lives { get; private set; }
    public bool IsDead { get; private set; } = false;

    public SpawnManager spawnManager;

    private void Start()
    {
        Lives = maxLives;
    }

    public void Decrement()
    {
        if (IsDead) return;
        Lives--;
        Debug.Log($"Player health: {Lives}/{maxLives}");
        if (Lives <= 0)
        {
            IsDead = true;
            Debug.Log("Game Over!!!");
            Debug.Log($"Your score: {gameObject.GetComponent<ScoreManager>().Score}");
            spawnManager.enableSpawn = false;
        }
    }
}
