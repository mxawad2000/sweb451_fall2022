using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameMgr : MonoBehaviour
{
    public AudioClip explosionClip;
    public AudioClip failureClip;
    public Text EnergyText;
    public Text ScoreText;
    private int energy = 100;
    private int score = 0;
    [SerializeField] Text TimeText;
    //define delegate to clean...
    public delegate void OnGameOver();
    public static event OnGameOver cleanList;
    Button startButton;
    public  static GameMgr Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Debug.Log("energy:" + energy);
        startButton = GameObject.FindGameObjectWithTag("startButton").GetComponent<Button>();
        startButton.gameObject.SetActive(false);
        this.score = PlayerPrefs.GetInt("Score");
        ScoreText.text = "Score:" + this.score;
    }
    public void PlayClip(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
    public void PlayExplosion()
    {
        AudioSource.PlayClipAtPoint(explosionClip, transform.position);
    }
    public void SetEnergy(int amount)
    {
        this.energy += amount;
        if (this.EnergyText == null) Debug.Log("null energy text");
        this.EnergyText.text = "ENERGY:" + energy;
        if (energy < 0)
        {
            GetComponent<AudioSource>().Stop();
            PlayClip(failureClip);
            startButton.gameObject.SetActive(true);
            cleanList?.Invoke();
        }
    }
    public void SetScore(int amount)
    {
        this.score += amount;
        if (this.ScoreText == null) Debug.Log("null score text");
        this.ScoreText.text = "SCORE:" + this.score;
    }
    private void saveScore()
    {
        int s = PlayerPrefs.GetInt("Score");
        PlayerPrefs.SetInt("Score", score + s);
    }
    public void handleStartButton(Button b)
    {
        energy = 100;
        saveScore();
        //score = 0;
        this.EnergyText.text = "ENERGY:" + energy;
        this.ScoreText.text = "Score:" + score;
        GetComponent<AudioSource>().Play();
        startButton.gameObject.SetActive(false);
        cleanList = null;//clear the list;
        SceneManager.LoadSceneAsync("sweb451_project");        
    }
    void ResetList () => cleanList = delegate { };
    float time = 0;
    private void Update()
    {
        float t = time + Time.deltaTime;
        if (Math.Truncate(t) != time)
        {
            this.TimeText.text = "Time:" + Math.Truncate(time);

        }
        time = t;
    }
}
