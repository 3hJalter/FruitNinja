using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] fruitToSpawn;
    public GameObject bomb;
    public Transform[] spawnPlaces;
    public float minWait = 0.3f;
    public float maxWait = 1f;
    public float minForce = 10;
    public float maxForce = 20;
    public float bombSpawnPercentage = 20;

    void Start()
    {
        StartCoroutine(SpawnFruit());
    }

    IEnumerator SpawnFruit()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
            Transform t = spawnPlaces[Random.Range(0, spawnPlaces.Length)];
            GameObject gameObject = null;
            float random = Random.Range(0, 100);
            if (random <= bombSpawnPercentage)
            {
                gameObject = Instantiate(bomb, t.transform.position, t.transform.rotation);
            }
            else
            {
                gameObject = Instantiate(fruitToSpawn[Random.Range(0, fruitToSpawn.Length)], t.transform.position, t.transform.rotation);
            }     
            Rigidbody2D rbFruit = gameObject.GetComponent<Rigidbody2D>();
            rbFruit.AddForce(t.transform.up*Random.Range(minForce, maxForce), ForceMode2D.Impulse);
            Destroy(gameObject, 5f);
        }
        
    }

}
