using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{

    public static bool GameIsPaused = false;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private Spawner sp;
   
    public void Resume()
    {
       pauseMenuUI.SetActive(false);
       Time.timeScale =1f;
       GameIsPaused =false;
    }
    public void Pause()
    {
       sp.enabled = false;
       pauseMenuUI.SetActive(true);
       Time.timeScale =0f;
       GameIsPaused =true;
    }
}
