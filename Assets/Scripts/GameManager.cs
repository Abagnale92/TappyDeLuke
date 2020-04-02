using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public delegate void GameDelegate();
	public static event GameDelegate OnGameStarted;
	public static event GameDelegate OnGameOverConfirmed;

	public static GameManager Instance;

	public GameObject startPage;
	public GameObject gameOverPage;
	public GameObject countdownPage;
	public Text scoreText;

	enum PageState {
		None,
		Start,
		Countdown,
		GameOver
	}

	int score = 0;
	bool gameOver = true;

	public Image randomImage;
public Sprite s1;
public Sprite s2;
public Sprite s3;
private Sprite[] images;
int num;

	public bool GameOver { get { return gameOver; } }

	void Awake() {
		if (Instance != null) {
			Destroy(gameObject);
		}
		else {
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}

		images = new Sprite[3];
    images[0] = s1;
    images[1] = s2;
    images[2] = s3;
	}

	void OnEnable() {
		TapController.OnPlayerDied += OnPlayerDied;
		TapController.OnPlayerScored += OnPlayerScored;
		CountdownText.OnCountdownFinished += OnCountdownFinished;
	}

	void OnDisable() {
		TapController.OnPlayerDied -= OnPlayerDied;
		TapController.OnPlayerScored -= OnPlayerScored;
		CountdownText.OnCountdownFinished -= OnCountdownFinished;
	}

	void OnCountdownFinished() {
		SetPageState(PageState.None);
		OnGameStarted();
		score = 0;
		gameOver = false;
	}

	void OnPlayerScored() {
		score++;
		scoreText.text = score.ToString();
	}

	void OnPlayerDied() {
		gameOver = true;
		int savedScore = PlayerPrefs.GetInt("HighScore");
		if (score > savedScore) {
			PlayerPrefs.SetInt("HighScore", score);
		}
		SetPageState(PageState.GameOver);
		//random image
		num = UnityEngine.Random.Range(0,3);
		Debug.Log(num);
    	randomImage.sprite = images[num];
	}

	void SetPageState(PageState state) {
		switch (state) {
			case PageState.None:
				Debug.Log("Sono Qui");
				startPage.SetActive(false);
				gameOverPage.SetActive(false);
				countdownPage.SetActive(false);
				break;
			case PageState.Start:
				startPage.SetActive(true);
				gameOverPage.SetActive(false);
				countdownPage.SetActive(false);
				break;
			case PageState.Countdown:
				startPage.SetActive(false);
				gameOverPage.SetActive(false);
				countdownPage.SetActive(true);
				break;
			case PageState.GameOver:
				startPage.SetActive(false);
				gameOverPage.SetActive(true);
				countdownPage.SetActive(false);
				break;
		}
	}
	
	public void ConfirmGameOver() {
		SetPageState(PageState.Countdown);
		scoreText.text = "0";
		OnGameOverConfirmed();
	}

	public void Start() {
		Debug.Log("Start Premuto!");
		SetPageState(PageState.Countdown);
	}

		public void Exit() {
		UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
		if (Instance != null) {
			DestroyImmediate(gameObject);
		}
		
	}

}
