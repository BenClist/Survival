using UnityEngine;
using System.Collections;

public class MeleeSystem : MonoBehaviour {

    [SerializeField]
    int minDamage = 25;
    [SerializeField]
    int maxDamage = 50;
    [SerializeField]
    float weaponRange = 3.5f;
    [SerializeField]
    Camera FPSCamera;

    private TreeHealth treeHealth;
    private AdvancedEnemyAI enemyAI;

    private void Update()
    {
        Ray ray = FPSCamera.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
        RaycastHit hitInfo;

        Debug.DrawRay(ray.origin, ray.direction * weaponRange, Color.green);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(ray, out hitInfo, weaponRange))
            {
                if (hitInfo.collider.tag == "Tree")
                {
                    treeHealth = hitInfo.collider.GetComponentInParent<TreeHealth>();
                    AttackTree();
                } else if (hitInfo.collider.tag == "Enemy")
                {
                    enemyAI = hitInfo.collider.GetComponent<AdvancedEnemyAI>();
                    AttackEnemy();
                }
            }
        }
    }

    private void AttackTree()
    {
        Debug.Log("Original Tree health = " + treeHealth.health);
        int damage = Random.Range(minDamage, maxDamage);
        treeHealth.health -= damage;
        Debug.Log("Hit for " + damage + " - New tree health = " + treeHealth.health);
    }

    private void AttackEnemy()
    {
        int damage = Random.Range(minDamage, maxDamage);
        enemyAI.TakeDamage(damage);
    }
}
