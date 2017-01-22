using UnityEngine;
using System.Collections;

public class gunscript : MonoBehaviour {

	public GameObject projectile;
	public float projectileSpeed;
	public Vector3 direction;
	private float lastShot = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Shoot () {
		if (Time.time > lastShot + 0.5) {
			GameObject thisproj = Instantiate (projectile, this.transform.position, this.transform.rotation) as GameObject;
	  		thisproj.GetComponent<Rigidbody>().AddForce (direction * projectileSpeed);
			lastShot = Time.time;
			Object.Destroy(thisproj, 10.0f);
		}
     }
}
