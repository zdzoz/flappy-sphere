using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float jumpHeight;
	private Rigidbody2D rb;
	public float maxSpeed;
	private int points = 0;
	public Text score;
	public static bool isGameOver = false;
	public GameObject gameOver;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update(){
		if (isGameOver) EndGame ();
	}

	void FixedUpdate () {
		if (Input.GetButtonDown("Jump") && rb.velocity.y < maxSpeed){
			rb.velocity = new Vector2(0, 0);
			rb.AddForce (new Vector2 (0, jumpHeight));
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("wall")) {
			isGameOver = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("pointTrigger")) {
			score.text = "Score: " + (++points);

		}
	}

	void EndGame(){
		gameObject.SetActive (false);
		gameOver.SetActive (true);
		foreach (GameObject i in WallSpawner.walls) {
			WallController.wallSpeed = 0.0f;
		}
	}

	public void ResetGame(){
		gameObject.transform.position = new Vector3 (-2, 0, 0);
		gameObject.SetActive (true);
		gameOver.SetActive (false);
		isGameOver = false;
		WallController.wallSpeed = 2.0f;
		points = 0;
		score.text = "Score " + (points);
		foreach (GameObject i in WallSpawner.walls) {
			Destroy (i);
		}
	}
}
