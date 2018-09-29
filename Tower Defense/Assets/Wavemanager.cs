using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Wavemanager : MonoBehaviour
{

    public Transform enemyPref;
    public Transform enemy2Pref;

    public Transform spawnPoint;

    public float waveTime = 5f;
    private float countDownTime = 10f;

    public Text timerText;

    private int waveNumber = 0;
    public static int currentWave;

    private bool gameEnded = false;

    private void Start()
    {
        
    }

    private void Update()

    {

        if (gameEnded)
            return;


        if (countDownTime <= 0f)
        {
           StartCoroutine(SpawnWave());
            countDownTime = waveTime;
        }

        countDownTime -= Time.deltaTime;
        timerText.text = "Enemy Wave in " + Mathf.Round(countDownTime).ToString() + " Seconds";
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;

        if (waveNumber == 8)
            YouWinTheGame();

        currentWave = waveNumber;

        for (int i = 0; i < waveNumber; i++)
        {

            if ( waveNumber <= 3f)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }
          else
            {
                SpawnEnemy2();
                yield return new WaitForSeconds(0.5f);
            }
               
            
        } 
        

        
       


    }

    void SpawnEnemy ()
    {
        Instantiate(enemyPref, spawnPoint.position, spawnPoint.rotation);
    }

    void SpawnEnemy2()
    {
        Instantiate(enemy2Pref, spawnPoint.position, spawnPoint.rotation);
    }

    public void YouWinTheGame()
    {
        SceneManager.LoadScene("TD_Win");
    }

    }

