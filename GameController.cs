using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int round = 1;
	public static bool gameOn = false; // this starts game on because it gets flipped immediately
	public static IEnumerator coroutine;
	public static GameController instance;

	// Use this for initialization
	void Awake () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static IEnumerator CheckRoundStatus(float waitTime) {
        while (true) {
        	gameOn = !gameOn;
            yield return new WaitForSeconds(waitTime);
        }
    }
    public static void StartEnemies ()
	{
		coroutine = CheckRoundStatus (4.0f);
		instance.StartCoroutine (coroutine);	
	}
    public void StopEnemies ()
	{
		instance.StopCoroutine (coroutine);	
	}
}
