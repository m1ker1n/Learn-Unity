using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerManager : MonoBehaviour
{
    private int currentHunger = 0;
    public int maxHunger;

    public void Feed()
    {
        currentHunger++;
        Debug.Log($"{gameObject}: {currentHunger}/{maxHunger}");
        if (currentHunger >= maxHunger) Destroy(gameObject);
    }
}
