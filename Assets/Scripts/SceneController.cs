using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject iguanaPrefab;
    [SerializeField] private Transform iguanaSpawnPt;
    [SerializeField] private UIController ui;

    private int score = 0;

    private GameObject enemy;
    private GameObject iguana;
    private Vector3 spawnPoint = new Vector3(0, 0, 5);
    private int enemyCount = 3;
    private int iguanaCount = 3;
    private GameObject[] enemies;
    private GameObject[] iguanas;

 

    private void Start()
    {
        ui.UpdateScore(score);
        enemies = new GameObject[enemyCount];
        iguanas = new GameObject[iguanaCount];

        for (int i = 0; i < iguanas.Length; i++)
        {
            if (iguanas[i] == null)
            {
                iguana = Instantiate(iguanaPrefab) as GameObject;
                iguanas[i] = iguana;
                iguana.transform.position = iguanaSpawnPt.position;
                float angle = Random.Range(0, 360);
                iguana.transform.Rotate(0, angle, 0);
            }

        }

    }

    // Update is called once per frame
    void Update() {


        for(int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null) {
                enemy = Instantiate(enemyPrefab) as GameObject;

                WanderingAI ai = enemy.GetComponent<WanderingAI>();
                ai.SetDifficulty(GetDifficulty());

                enemies[i] = enemy;
                enemy.transform.position = spawnPoint;

                float angle = Random.Range(0, 360);
                enemy.transform.Rotate(0, angle, 0);

            }
        }
    }

    private void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
        Messenger<int>.AddListener(GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
        Messenger<int>.RemoveListener(GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
    }

    private void OnEnemyDead()
    {
        score++;
        ui.UpdateScore(score);
    }

    private void OnDifficultyChanged(int newDifficulty) {
        Debug.Log("scene.OnDifficultyChanged(" + newDifficulty + ")");

        for(int i = 0; i < enemies.Length; i++)
        {
            WanderingAI ai = enemies[i].GetComponent<WanderingAI>();
            ai.SetDifficulty(newDifficulty);    
        }
    }

    public int GetDifficulty()
    {
        return PlayerPrefs.GetInt("difficulty", 1);
    }
}
