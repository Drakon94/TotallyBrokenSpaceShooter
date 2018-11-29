using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawningSystem : MonoBehaviour {

    public Transform[] enemiesSpawningPoints;
    public GameObject[] enemiesLvl1;
    public GameObject[] enemiesLvl3;
    public GameObject[] enemiesLvl6;


    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if(FindObjectOfType<LevelScript>().getCurrentLevel() < 3)
            {
                if(FindObjectOfType<LevelScript>().getCurrentLevel() == 1)
                {
                    Instantiate(enemiesLvl1[Random.Range(0, enemiesLvl1.Length)], enemiesSpawningPoints[Random.Range(0, enemiesSpawningPoints.Length)].position, Quaternion.identity);
                    yield return new WaitForSeconds(Random.Range(4, 9));
                }
                if (FindObjectOfType<LevelScript>().getCurrentLevel() == 2)
                {
                    Instantiate(enemiesLvl1[Random.Range(0, enemiesLvl1.Length)], enemiesSpawningPoints[Random.Range(0, enemiesSpawningPoints.Length)].position, Quaternion.identity);
                    yield return new WaitForSeconds(Random.Range(2, 4));
                }
            }
            if(FindObjectOfType<LevelScript>().getCurrentLevel() >= 3 && FindObjectOfType<LevelScript>().getCurrentLevel() < 6)
            {
                if (FindObjectOfType<LevelScript>().getCurrentLevel() == 3)
                {
                    Instantiate(enemiesLvl3[Random.Range(0, enemiesLvl3.Length)], enemiesSpawningPoints[Random.Range(0, enemiesSpawningPoints.Length)].position, Quaternion.identity);
                    yield return new WaitForSeconds(Random.Range(4, 9));
                }
                if (FindObjectOfType<LevelScript>().getCurrentLevel() == 4)
                {
                    Instantiate(enemiesLvl3[Random.Range(0, enemiesLvl3.Length)], enemiesSpawningPoints[Random.Range(0, enemiesSpawningPoints.Length)].position, Quaternion.identity);
                    yield return new WaitForSeconds(Random.Range(2, 6));
                }
                if (FindObjectOfType<LevelScript>().getCurrentLevel() == 5)
                {
                    Instantiate(enemiesLvl3[Random.Range(0, enemiesLvl3.Length)], enemiesSpawningPoints[Random.Range(0, enemiesSpawningPoints.Length)].position, Quaternion.identity);
                    yield return new WaitForSeconds(Random.Range(2, 4));
                }
            }
            if (FindObjectOfType<LevelScript>().getCurrentLevel() >= 6)
            {
                if (FindObjectOfType<LevelScript>().getCurrentLevel() == 6)
                {
                    Instantiate(enemiesLvl6[Random.Range(0, enemiesLvl6.Length)], enemiesSpawningPoints[Random.Range(0, enemiesSpawningPoints.Length)].position, Quaternion.identity);
                    yield return new WaitForSeconds(Random.Range(4, 9));
                }
                if (FindObjectOfType<LevelScript>().getCurrentLevel() == 7)
                {
                    Instantiate(enemiesLvl6[Random.Range(0, enemiesLvl6.Length)], enemiesSpawningPoints[Random.Range(0, enemiesSpawningPoints.Length)].position, Quaternion.identity);
                    yield return new WaitForSeconds(Random.Range(2, 6));
                }
                if (FindObjectOfType<LevelScript>().getCurrentLevel() == 8)
                {
                    Instantiate(enemiesLvl6[Random.Range(0, enemiesLvl6.Length)], enemiesSpawningPoints[Random.Range(0, enemiesSpawningPoints.Length)].position, Quaternion.identity);
                    yield return new WaitForSeconds(Random.Range(2, 4));
                }
                if (FindObjectOfType<LevelScript>().getCurrentLevel() == 9)
                {
                    Instantiate(enemiesLvl6[Random.Range(0, enemiesLvl6.Length)], enemiesSpawningPoints[Random.Range(0, enemiesSpawningPoints.Length)].position, Quaternion.identity);
                    yield return new WaitForSeconds(Random.Range(1, 4));
                }
                if (FindObjectOfType<LevelScript>().getCurrentLevel() == 10)
                {
                    Instantiate(enemiesLvl1[Random.Range(0, enemiesLvl6.Length)], enemiesSpawningPoints[Random.Range(0, enemiesSpawningPoints.Length)].position, Quaternion.identity);
                    yield return new WaitForSeconds(Random.Range(1, 3));
                }
            }
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

}
