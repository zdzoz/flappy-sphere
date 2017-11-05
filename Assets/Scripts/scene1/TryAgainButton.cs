using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TryAgainButton : MonoBehaviour {

	public Button btn_gameOver;
	public Button btn_quit;
	public PlayerController p;

	void Start(){
		btn_gameOver.onClick.AddListener (gameOver);
		btn_quit.onClick.AddListener (quit);
	}

	private void gameOver(){
		p.ResetGame ();
		//Debug.Log("HELLO");
	}

	private void quit(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		p.ResetGame ();
	}

}
