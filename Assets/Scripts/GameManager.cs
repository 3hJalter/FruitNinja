using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header ("Score Elements")]
    public int score = 0, highscore;
    public Text scoreText, highscoreText;
    [Header("Restart Elements")]
    public GameObject restartPanel;
    [Header("Sounds")]
    public AudioClip[] sliceSounds;
    public AudioClip gameStartSound;
    public AudioClip gameOverSound;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        restartPanel.SetActive(false);
        GetHighscore();
    }

    private void GetHighscore()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        highscoreText.text = "Best: " + highscore.ToString();
    }

    public void IncreaseScore(int addedPoints)
    {
        score += addedPoints;
        scoreText.text = score.ToString();
        if (highscore < score)
        {
            PlayerPrefs.SetInt("Highscore", score);
            highscore = score;
            highscoreText.text = "Best: " + highscore.ToString();
        }
    }

    public void OnBombHit()
    {
        Debug.Log("Bomb");
        Time.timeScale = 0;
        restartPanel.SetActive(true);
        audioSource.PlayOneShot(gameOverSound);
    }

    public void ResetGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void PlayRandomSound()
    {
        AudioClip randomSound = sliceSounds[Random.Range(0, sliceSounds.Length)];
        audioSource.PlayOneShot(randomSound);
    }


}
