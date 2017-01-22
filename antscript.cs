using UnityEngine;
using System.Collections;

public class antscript : MonoBehaviour {
	// Use this for initialization

	void Start () {
		ParticleSystem ps = GetComponent<ParticleSystem>();
		var em = ps.emission;
        em.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartParticles() {
		ParticleSystem ps = GetComponent<ParticleSystem>();
		var em = ps.emission;
        em.enabled = true;

	}
	public void StopParticles() {
		ParticleSystem ps = GetComponent<ParticleSystem>();
		var em = ps.emission;
        em.enabled = false;

	}
}
