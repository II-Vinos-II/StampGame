using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public GameObject gameOver;
    public bool gameOvered;

    public GameObject pause;
    public bool paused;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        // GAME OVER
        if (gameOvered)
        {
            GameOver();
        }

        // PAUSE
        if (Input.GetKeyDown(KeyCode.Joystick1Button7)) // Start
        {
            paused = true;
        }

        
    }

    public void GameOver()
    {

        gameOver.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Joystick1Button7)) //Start
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button6)) // Options
        {
            Application.Quit();
        }
    }

    public void Pause()
    {
        if (paused)
        {
            pause.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                pause.SetActive(false);
                paused = false;
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button7))
            {
                SceneManager.LoadScene(0);
                paused = false;
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button6)) // Options
            {
                Application.Quit();
                paused = false;
            }
        }
    }

    public void OnApplicationPause(bool pauseStatus)
    {
        paused = pauseStatus;
    }   
}
