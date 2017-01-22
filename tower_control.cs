using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tower_control : MonoBehaviour {

	private bool shouldRotateClockwise = false;
	private bool shouldRotateCounterClockwise = false;
	private int health = 100;
	public int score = 0;
	private Text healthbar;
	private Text finalScore;
	public EnemyForward.EnemyType killedBy;
	public Sprite anteater;
	public Sprite cat;
	public Sprite cage;
 
	// Use this for initialization
	void Start () {
		healthbar = GameObject.Find("health").GetComponent<Text>();
		finalScore = GameObject.Find("finalScore").GetComponent<Text>();
		GameObject.Find("Start").GetComponent<Image>().enabled = true;		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (shouldRotateClockwise) {
			float angle = -5;
			transform.RotateAround(transform.position, transform.up, angle);
		}
		if (shouldRotateCounterClockwise) {
			float angle = 5;
			transform.RotateAround(transform.position, transform.up, angle);
		}

	}

	public void Clockwise () {
		shouldRotateClockwise = true;
	}

	public void ClockwiseStop () {
		shouldRotateClockwise = false;
	}
	public void CounterClockwise () {
		shouldRotateCounterClockwise = true;
	}

	public void CounterClockwiseStop () {
		shouldRotateCounterClockwise = false;
	}

	bool alive = true;

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "enemy") {
			health -= 10;
			Destroy (collision.gameObject);
			if (health < 1 && alive) {
				alive = false;
				killedBy = collision.gameObject.GetComponent<EnemyForward> ().type;
				if (killedBy == EnemyForward.EnemyType.anteater) {
					GameObject.Find("End").GetComponent<Image>().sprite = anteater;
				}
				else if (killedBy == EnemyForward.EnemyType.cat) {
					GameObject.Find("End").GetComponent<Image>().sprite = cat;
				}
				else if (killedBy == EnemyForward.EnemyType.cage) {
					GameObject.Find("End").GetComponent<Image>().sprite = cage;
				}
				finalScore.text = "Score " + score;
				finalScore.enabled = true;
				GameOver();
			}
			healthbar.text = "Life " + health + "  Score " + score;
        }
	}
	public void GameOver (){
		GameObject.Find("End").GetComponent<Image>().enabled = true;
	}
	public void RestartGame (){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void StartGame() {
		GameObject.Find("Start").GetComponent<Image>().enabled = false;		
		GameController.StartEnemies();
	}
}
