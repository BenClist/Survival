using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField]
    GameObject deathcanvas;
    [SerializeField]
    float health = 100f;

    private Vector3 spawnPoint;

    private void Start()
    {
        deathcanvas.SetActive(false);
        spawnPoint = transform.position;
    }

    private void Update()
    {
        CheckDeath();
    }

    private void CheckDeath()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        deathcanvas.SetActive(true);
    }

    public void Respawn()
    {
        deathcanvas.SetActive(false);
        transform.position = spawnPoint;
        health = 100;
    }
}
