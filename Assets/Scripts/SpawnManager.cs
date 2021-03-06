using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnManager : MonoBehaviour
{
    enum SpawnPosType
    {
        Left,
        Top,
        Right
    }

    SpawnPosType fromWhere;
    public float spawnPosLeft = -23.0f;
    public float spawnPosTop = 15.0f;
    public float spawnPosRight = 23.0f;

    public Bounds leftBounds = new Bounds { lower = -1.5f, upper = 16.0f };
    public Bounds topBounds = new Bounds { lower = -23.0f, upper = 23.0f };
    public Bounds rightBounds = new Bounds { lower = -1.5f, upper = 16.0f };

    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    public GameObject[] animalPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    private void SpawnRandomAnimal()
    {
        SpawnPosType type = (SpawnPosType)Random.Range(0, 3);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawnPos = CreateSpawnPos(type);
        SpawnAnimal(animalPrefabs[animalIndex], spawnPos, type);
    }

    private void SpawnAnimal(GameObject prefab, Vector3 spawnPos, SpawnPosType type)
    {
        Vector3 newEulerAngle;
        switch (type)
        {
            case SpawnPosType.Left:
                newEulerAngle = new Vector3(0, 90, 0);
                break;
            case SpawnPosType.Top:
                newEulerAngle = new Vector3(0, 180, 0);
                break;
            case SpawnPosType.Right:
                newEulerAngle = new Vector3(0, -90, 0);
                break;
            default:
                newEulerAngle = new Vector3(0, 0, 0);
                Debug.Log("Wrong SpawnPosType");
                break;
        }
        prefab.transform.eulerAngles = newEulerAngle;
        Instantiate(prefab, spawnPos, prefab.transform.rotation);
    }

    private Vector3 CreateSpawnPos(SpawnPosType type)
    {
        switch (type)
        {
            case SpawnPosType.Left:
                return new Vector3(spawnPosLeft, 0, Random.Range(leftBounds.lower, leftBounds.upper));
            case SpawnPosType.Top:
                return new Vector3(Random.Range(topBounds.lower, topBounds.upper), 0, spawnPosTop);
            case SpawnPosType.Right:
                return new Vector3(spawnPosRight, 0, Random.Range(rightBounds.lower, rightBounds.upper));
            default:
                Debug.Log("Undefined SpawnPosType");
                return new Vector3(0,0,0);
        }
    }
}
