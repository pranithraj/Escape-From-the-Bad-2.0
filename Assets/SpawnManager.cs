/**
 * Author: Pranith Raj Jajala
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to spawn new catchers(green) and evaders(red)
public class SpawnManager : MonoBehaviour
{
    private float timeInterval = 2.0f;
    // Catcher
    public GameObject enemyPrefab;
    // Evader
    public GameObject enemy2Prefab;

    public Vector2 spawnRangeX;

    void Start()
    {
        // Invokes the evaders starting at 0 seconds every once every 2 seconds
        InvokeRepeating(nameof(generateEvader), 0, timeInterval);

        // Invokes the catchers starting at 1 second every once every 2 seconds
        InvokeRepeating(nameof(generateCatcher), 1.0f, timeInterval);
    }

   private void GenerateObject(EnemyType objectClass)
    {
        Vector3 generatingPoint = new Vector3(
            Random.Range(spawnRangeX[0], spawnRangeX[1]),
            enemyPrefab.transform.position.y,
            enemyPrefab.transform.position.z
            );

        if (objectClass == EnemyType.Catcher)
            Instantiate(enemy2Prefab, generatingPoint, enemy2Prefab.transform.rotation);            
        else
            Instantiate(enemyPrefab, generatingPoint, enemyPrefab.transform.rotation);        
    }
    private void generateEvader()
    {
        GenerateObject(EnemyType.Evader);
    }

    private void generateCatcher()
    {
        GenerateObject(EnemyType.Catcher);
    }
}
