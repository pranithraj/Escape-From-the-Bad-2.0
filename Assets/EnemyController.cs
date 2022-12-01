/**
 * Author: Pranith Raj Jajala
 **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public EnemyType enemyType;
    private PlayerController playerController;
    private float zTreshold =- 20.0f;
    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);

        if (Vector3.Distance(playerController.transform.position, transform.position) < 1.0f)
        {
            if(enemyType == EnemyType.Evader)
                playerController.OnCollision();
            Destroy(gameObject);
        }
        else if (playerController.transform.position.z - transform.position.z > 5.0f && enemyType == EnemyType.Catcher)
        {
            playerController.OnCollision();
            Destroy(gameObject);
        }
        else if(transform.position.z <= zTreshold)
        {
            Destroy(gameObject);
        }
    }
}

public enum EnemyType
{
    Catcher,
    Evader
}
