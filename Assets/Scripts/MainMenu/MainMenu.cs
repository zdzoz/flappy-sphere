using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Button btn_start;
	public Button btn_controls;
	public Button btn_about;
	public Button btn_back;
	private GameObject menuPanel;
	private GameObject controlPanel;

	// Use this for initialization
	void Start () {
		btn_start.onClick.AddListener (startGame);
		btn_controls.onClick.AddListener (controls);
		btn_about.onClick.AddListener (about);
		btn_back.onClick.AddListener (back);

		menuPanel = GameObject.Find ("MenuPanel");
		controlPanel = GameObject.Find ("ControlPanel");

		controlPanel.SetActive (false);
	}

	private void startGame () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	private void controls(){
		menuPanel.SetActive (false);
		controlPanel.SetActive (true);
	}

	private void about(){
		
	}

	private void back(){
		menuPanel.SetActive (true);
		controlPanel.SetActive (false);
	}
}
