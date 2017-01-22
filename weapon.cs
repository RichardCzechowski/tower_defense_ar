using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {

	private GameObject tower;

	public enum WeaponType{
		cucumber, bee, ant
 	}

 	public WeaponType type; 

	
	// Use this for initialization
	void Awake () {
		tower = GameObject.Find("Tower");	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "enemy") {
			var enemyType = collision.gameObject.GetComponent<EnemyForward>().type;
			if (type == WeaponType.cucumber && enemyType == EnemyForward.EnemyType.cat) {
				tower.GetComponent<tower_control>().score += 10;
				Destroy (collision.gameObject);
			} else if (type == WeaponType.bee && enemyType == EnemyForward.EnemyType.cage) {
				tower.GetComponent<tower_control>().score += 10;
				Destroy (collision.gameObject);
			} else if (enemyType == EnemyForward.EnemyType.anteater || enemyType == EnemyForward.EnemyType.cage || enemyType == EnemyForward.EnemyType.cat) {
				tower.GetComponent<tower_control>().score += 10;
				Destroy (gameObject);
			}

        }
	}

	void OnParticleCollision (GameObject other)
	{
		Debug.Log (other.tag);
		if (other.tag == "enemy") {
			var enemyType = other.GetComponent<EnemyForward> ().type;
			if (enemyType == EnemyForward.EnemyType.anteater) {
				tower.GetComponent<tower_control>().score += 10;
				Destroy (other);
			}
		}
	}
}
