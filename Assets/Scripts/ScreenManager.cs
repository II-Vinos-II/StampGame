using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public Movements playerController;

    public GameObject gameOver;
    public bool gameOvered;

    public GameObject pause;




    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            Pause();
        }

        if (gameOvered)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        playerController.canMove = false;
        gameOver.SetActive(true);
    }

    public void Pause()
    {
        pause.SetActive(true);
        playerController.canMove = false;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Resume()
    {
        pause.SetActive(false);
        StartCoroutine(WaitToResume());
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public IEnumerator WaitForTimeScaleZeroForPause()
    {
        pause.SetActive(true);
        yield return new WaitForSeconds(2.1f);
        playerController.canMove = false;
    }
    public IEnumerator WaitForTimeScaleOneFromPause()
    {
        pause.SetActive(false);
        yield return new WaitForSeconds(2.1f); 
        playerController.canMove = true;
    }
    public IEnumerator WaitForTimeScaleZeroForGameOver()
    {
        gameOver.SetActive(true);
        yield return new WaitForSeconds(2.1f);
        playerController.canMove = false;
    }
    public IEnumerator WaitToResume()
    {
        yield return new WaitForSeconds(3f);
        playerController.canMove = true;
    }
}
