using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text text;

    public PipeSpawner pipeSpawner;
    public Swipe swipe;

    public bool isStarted;
    public bool isFinished;

    public bool isSwipe;

    public GameObject gameOver;
    public GameObject playAgain;
    public GameObject playAgainButton;

    private void Awake()
    {
        pipeSpawner = FindObjectOfType<PipeSpawner>();
        swipe = FindObjectOfType<Swipe>();
        gameOver.SetActive(false);
        playAgain.SetActive(false);
        playAgainButton.SetActive(false);

        pipeSpawner.enabled = false;
        swipe.isDead = false;
        isStarted = false;
        isFinished = false;
    }

    private void Update()
    {
        if(swipe.isDead == true)
        {
            pipeSpawner.enabled = false;
            gameOver.SetActive(true);
            StartCoroutine(PlayAgain());
        }

        text.SetText(swipe.scoreCounter.ToString());
    }


    public void HandleStart()
    {
        isStarted = true;
        pipeSpawner.enabled = true;    
    }

    public void HandleRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator PlayAgain()
    {
        yield return new WaitForSeconds(1);

        playAgain.SetActive(true);

        yield return new WaitForSeconds(1);

        playAgainButton.SetActive(true);
        

        yield return null;
    }

}
