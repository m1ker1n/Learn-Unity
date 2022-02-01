using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int Score { get; private set; } = 0;

    public void Increment()
    {
        Score++;
        Debug.Log($"Current Score: {Score}");
    }


    public void Decrement()
    {
        Score--;
        Debug.Log($"Current Score: {Score}");
    }
}
