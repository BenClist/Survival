using UnityEngine;
using System.Collections;

public class ShootingSystem : MonoBehaviour {

	private AdvancedEnemyAI enemy;

	[SerializeField]
	float weaponRange = 100f;
	[SerializeField]
	int minDamage = 15;
	[SerializeField]
	int maxDamage = 30;
	[SerializeField]
	Camera FPSCamera;

	private void Update () {
		Ray ray = FPSCamera.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
		RaycastHit hitInfo;

		Debug.DrawRay (ray.origin, ray.direction * weaponRange, Color.green);

		if(Input.GetKeyDown(KeyCode.Mouse0)){

			if(Physics.Raycast(ray, out hitInfo, weaponRange)){
				if(hitInfo.collider.tag=="Enemy"){
					enemy = hitInfo.collider.GetComponent<AdvancedEnemyAI> ();
					enemy.TakeDamage (Damage());
					Debug.Log ("We attacked an enemy!");
				}
			}
		}
	}

	private int Damage(){
		return Random.Range (minDamage, maxDamage);
	}
}
			