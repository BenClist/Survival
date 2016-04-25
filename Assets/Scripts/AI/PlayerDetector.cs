using UnityEngine;
using System.Collections;

public class PlayerDetector : MonoBehaviour {

    private Transform playerDetectorTransform;
    private AdvancedEnemyAI advancedEnemyAI;

    private void Start()
    {
        advancedEnemyAI = GetComponentInParent<AdvancedEnemyAI>();
    }

    private void OnTriggerEnter(Collider target)
    {
        if(target.tag == "Player")
        {
            playerDetectorTransform = target.GetComponent<Transform>();

            if(advancedEnemyAI.playerTransform == null)
            {
                advancedEnemyAI.playerTransform = playerDetectorTransform;
            }
        }
    }
}
