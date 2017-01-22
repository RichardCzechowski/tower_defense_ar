using UnityEngine;
using System.Collections;

public class EnemyForward : MonoBehaviour {
	public float movementSpeed = 10;
	public enum EnemyType{
 	  anteater, cat, cage 
 	}

 	public EnemyType type; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
 		GetComponent<Rigidbody>().velocity = (transform.right * movementSpeed);
	}
	void OnParticleCollision (GameObject other) {
		Debug.Log(other);
	}
}
