using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TapController : MonoBehaviour {

	public delegate void PlayerDelegate();
	public static event PlayerDelegate OnPlayerDied;
	public static event PlayerDelegate OnPlayerScored;

	public float tapForce = 10;
	public float tiltSmooth = 5;
	public Vector3 startPos;
	public AudioSource tapSound;
	public AudioSource scoreSound;
	public AudioSource scoreSound2;
	public AudioSource scoreSound3;
	public AudioSource dieSound;
	int num;

	Rigidbody2D rigidBody;
	Quaternion downRotation;
	Quaternion forwardRotation;

	GameManager game;
	TrailRenderer trail;

	void Start() {
		rigidBody = GetComponent<Rigidbody2D>();
		downRotation = Quaternion.Euler(0, 0 ,-90);
		forwardRotation = Quaternion.Euler(0, 0, 35);
		game = GameManager.Instance;
		rigidBody.simulated = false;
		//trail = GetComponent<TrailRenderer>();
		//trail.sortingOrder = 20; 
	}

	void OnEnable() {
		GameManager.OnGameStarted += OnGameStarted;
		GameManager.OnGameOverConfirmed += OnGameOverConfirmed;
	}

	void OnDisable() {
		GameManager.OnGameStarted -= OnGameStarted;
		GameManager.OnGameOverConfirmed -= OnGameOverConfirmed;
	}

	void OnGameStarted() {
		rigidBody.velocity = Vector3.zero;
		rigidBody.simulated = true;
	}

	void OnGameOverConfirmed() {
		transform.localPosition = startPos;
		transform.rotation = Quaternion.identity;
	}

	void Update() {
		if (game.GameOver) return;

		if (Input.GetMouseButtonDown(0)) {
			rigidBody.velocity = Vector2.zero;
			transform.rotation = forwardRotation;
			rigidBody.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
			tapSound.Play();
		}

		transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "ScoreZone") {
			OnPlayerScored();
			num = Random.Range(0,3);
			Debug.Log(num);
			if(num == 0){
			scoreSound.Play();
			}
			if(num == 1){
			scoreSound2.Play();
			}
			if(num == 2){
			scoreSound3.Play();
			}
		}
		if (col.gameObject.tag == "DeadZone") {
			rigidBody.simulated = false;
			OnPlayerDied();
			dieSound.Play();
		}
	}

}
