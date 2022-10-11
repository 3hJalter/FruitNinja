using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject sliceFruit;
    public float explosionRadius = 5f;
    public int addedPoints = 10;
    private GameManager gameManager;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void CreateSliceFruit()
    {
        GameObject inst = Instantiate(sliceFruit, transform.position, transform.rotation);
        Rigidbody[] rbOnSliced = inst.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rbOnSliced)
        {
            rigidbody.transform.rotation = Random.rotation; 
            rigidbody.AddExplosionForce(Random.Range(500,1000), transform.position, explosionRadius);
        }
        gameManager.IncreaseScore(addedPoints);
        gameManager.PlayRandomSound();
        Destroy(gameObject);
        Destroy(inst, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();
        if (!b)
        {
            return;
        }
        CreateSliceFruit();
    }
}
