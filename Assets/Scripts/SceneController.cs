using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyPrefab;
    private GameObject enemy;
    private Vector3 spawnPoint = new Vector3(0, 0, 5);
    private int enemyCount = 3;
    private GameObject[] enemies;

    private void Start()
    {
        enemies = new GameObject[enemyCount];
    }

    // Update is called once per frame
    void Update() {


        for(int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null) {
                enemy = Instantiate(enemyPrefab) as GameObject;
                enemies[i] = enemy;
                enemy.transform.position = spawnPoint;
                float angle = Random.Range(0, 360);
                enemy.transform.Rotate(0, angle, 0);

            }
        }
    }
}
