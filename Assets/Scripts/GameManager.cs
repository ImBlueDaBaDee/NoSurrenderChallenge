using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject[] enemies;
    private int enemyCount;

    private static GameManager instance = null;

    public static GameManager Instance
    {
        get
        {
            if(instance==null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }

            return instance;
        }
    }
    private void OnEnable()
    {
        instance = this;
    }
    
    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;
    }
    public void Restart()
    {
        SceneManager.LoadScene("LevelOne");
    }
    public void SubtractEnemyCount()
    {
        enemyCount -= 1;
        if(enemyCount == 0)
        {
            Restart();
        }
    }
    public int GetEnemyCount()
    {
        return enemyCount;
    }
}
