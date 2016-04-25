using UnityEngine;
using System.Collections;

public class AdvancedEnemyAI : MonoBehaviour {

    private NavMeshAgent agent;
    private bool isChasing = false;
    private float thinkTimerMin = 5f;
    private float thinkTimeMax = 15f;
    private float thinkTimer;

    public Transform playerTransform;

    [SerializeField]
    float health = 100f;
    [SerializeField]
    float viewRange = 25f;
    [SerializeField]
    float attackRange = 5f;
    [SerializeField]
    float eyeHeight;
    [SerializeField]
    float randomUnitCircleRadius = 25f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        thinkTimer = Random.Range(thinkTimerMin, thinkTimeMax);
    }

    private void Update()
    {
        Vector3 eyePosition = new Vector3(transform.position.x, transform.position.y + eyeHeight, transform.position.z);

        CheckHealth();

        thinkTimer -= Time.deltaTime;
        if(thinkTimer <= 0)
        {
            Think();
            thinkTimer = Random.Range(thinkTimerMin, thinkTimeMax);
        }

        Ray ray = new Ray(eyePosition, transform.forward);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, viewRange))
        {
            if(hitInfo.collider.tag == "Player")
            {
                if (!isChasing)
                {
                    isChasing = true;

                    if(playerTransform == null)
                    {
                        playerTransform = hitInfo.collider.GetComponent<Transform>();
                    }

                }
            }
        }

        if(Physics.Raycast(ray, out hitInfo, attackRange))
        {

        }

        Debug.DrawRay(ray.origin, ray.direction * viewRange, Color.red);

        if (isChasing)
        {
            agent.SetDestination(playerTransform.position);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(playerTransform != null)
        {
            isChasing = true;
        }

        Debug.Log("Enemy took " + damage + " damage, and now has " + health + " health");
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Think()
    {
        if (!isChasing)
        {
            Vector3 newPos = transform.position + new Vector3(Random.insideUnitCircle.x * randomUnitCircleRadius, transform.position.y, Random.insideUnitCircle.y * randomUnitCircleRadius);
            agent.SetDestination(newPos);
        }
    }
}
