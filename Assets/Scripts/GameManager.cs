using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public int world { get; private set; }
    public int stage { get; private set; }
    public int lives { get; private set;  }

    public int coins { get; private set; }
    public void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }
    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        coins = 0;
        lives = 3;
        LoadLevel(1, 1);
    }
    private void LoadLevel(int world, int stage)
    {
        this.world = world;
        this.stage = stage;
        SceneManager.LoadScene($"{world}-{stage}");
    }
    public void ResetLevel(float delay)
    {
        Invoke(nameof(ResetLevel), delay);
    }
    public void ResetLevel()
    {
        lives--;
        if (lives > 0)
        {
            LoadLevel(world, stage);
        } else
        {
            GameOver();
        }
    }
    private void GameOver()
    {
        Invoke(nameof(NewGame), 3f);
    }
    public void AddCoin()
    {
        coins++;
        if (coins == 20)
        {
            AddLife();
            coins = 0;
        }
    }
    public void AddLife()
    {
        lives++;
    }
}
