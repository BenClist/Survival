using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    [SerializeField]
    GameObject deathcanvas;

    [SerializeField]
    float health = 100f;
	[SerializeField]
	float hunger = 100f;
	[SerializeField]
	float thirst = 100f;

	[SerializeField]
	Image healthBar;
	[SerializeField]
	Image hungerBar;
	[SerializeField]
	Image thirstBar;

	[SerializeField]
	float healthSpeed = 0.25f;
	[SerializeField]
	float hungerSpeed = 0.1f;
	[SerializeField]
	float thirstSpeed = 0.25f;

    private Vector3 spawnPoint;
	private bool isDying;

    private void Start()
    {
        deathcanvas.SetActive(false);
        spawnPoint = transform.position;
    }

    private void Update()
    {
        CheckDeath();

		if (hunger > 0) 
		{
			hunger -= Time.deltaTime * hungerSpeed;           
		}
		if (thirst > 0) 
		{
			thirst -= Time.deltaTime * thirstSpeed;           
		}
		if (hunger <= 0 || thirst <= 0) {
			isDying = true;
		} else 
		{
			isDying = false;
		}
		if (isDying) 
		{
			health -= Time.deltaTime * healthSpeed;
		}
			


		healthBar.fillAmount = health / 100;
		hungerBar.fillAmount = hunger / 100;
		thirstBar.fillAmount = thirst / 100;
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
        health = 100f;
		hunger = 100f;
		thirst = 100f;
    }
}
