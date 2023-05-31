using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;

    [SerializeField] Vector3 spawnPos = new Vector3(0, 1, 40);

    [SerializeField] float timeToSpawn = 1f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void Update() {
    }
    IEnumerator SpawnEnemy(){
        while(true){
            yield return new WaitForSeconds(timeToSpawn);
            int index = Random.Range(0, 8);
            Instantiate(enemy[index], spawnPos, Quaternion.identity);
        }
    }
}
