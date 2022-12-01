/**
 * Author: Pranith Raj Jajala
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private int pointsToUpdate = 10;
    private Stats gameStatus;
    public float speed;
    public HudManager hudManager;
    public Transform leftWall;
    public Transform rightWall;

    private void Awake()
    {
        gameStatus = GetComponent<Stats>();
        hudManager.UpdateLifeBanner(gameStatus.health);
    }
    private void Update()
    {
        if(gameStatus.health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        float horizontalInput = Input.GetAxis("Horizontal");

            //Add touch support
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Touch touch = Input.touches[0];
            horizontalInput = touch.deltaPosition.x;
            // v = touch.deltaPosition.y;
        }

        float horizontalPosition = transform.position.x + horizontalInput * speed * Time.deltaTime;
        float playerSizeX = transform.localScale.x / 2;
        float leftWallSizeX = leftWall.localScale.x / 2;
        float rightWallSizeX = rightWall.localScale.x / 2;

        if (horizontalPosition - playerSizeX <= leftWall.position.x + leftWallSizeX)
        {
            return;
        }
        if (horizontalPosition + playerSizeX >= rightWall.position.x - rightWallSizeX)
        {
            return;
        }
        transform.position = new Vector3(
            horizontalPosition,
            1,
            transform.position.z);

        if (Input.GetKeyDown(KeyCode.Escape))
            ExitGame();
    }
    public void OnCollision()
    {
        gameStatus.UpdateLife(pointsToUpdate);
        hudManager.UpdateLifeBanner(gameStatus.health);
    }
    
    public void ExitGame()
    {
            Application.Quit();
    }
}

