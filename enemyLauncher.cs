using UnityEngine;
using System.Collections;

public class enemyLauncher : MonoBehaviour {
	public GameObject[] enemyTypes;
	private GameObject enemy;
	private bool emitting = false;
	private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
		coroutine = Emit(6.0f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameController.gameOn && !emitting) {
        	StartCoroutine(coroutine);	
			emitting = true;
		}else if (!GameController.gameOn) {
			StopCoroutine(coroutine);
			emitting = false;
		}	
	}

	private IEnumerator Emit (float waitTime)
	{
		while (true) {
	    	int choice = Mathf.CeilToInt(enemyTypes.Length * Random.Range(0.0f, 1.0f)) - 1;
			enemy = enemyTypes[choice]; 
			GameObject thisproj = Instantiate (enemy, this.transform.position, this.transform.rotation) as GameObject;
			Object.Destroy(thisproj, 10.0f);
        	yield return new WaitForSeconds(waitTime * Random.Range(1.0f, 2.0f));
		}
    }
}
