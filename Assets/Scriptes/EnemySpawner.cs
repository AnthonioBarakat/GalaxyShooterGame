using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Enemies;

    [SerializeField]
    private Transform[] pos;

    private GameObject spawnedEnemy;
    private int randomIndex, randomSide;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnEnemy()
    {
        while (true)
        {

            yield return new WaitForSeconds(Random.Range(1, 4));

            randomIndex = Random.Range(0, Enemies.Length);
            randomSide = Random.Range(0, pos.Length);

            spawnedEnemy = Instantiate(Enemies[randomIndex]);

            spawnedEnemy.transform.position = pos[randomSide].position;

            //spawnedEnemy.GetComponent<Enemy>().speed = Random.Range(4, 10);
        }
            
    }


}
