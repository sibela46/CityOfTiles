using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	private Rigidbody rb;
	
	public float speed = 10.0f;
	public int health = 100;
	public int lives = 3;
	public int power = 1;

	public Text infoText, healthText, powerText, livesText;

	public Player(GameObject playerPrefab) {
		Instantiate(playerPrefab, new Vector3(0.0f, 9.0f, 0.0f), Quaternion.identity);
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();

		infoText = GameObject.FindGameObjectWithTag("InfoText").GetComponent<Text>();
		healthText = GameObject.FindGameObjectWithTag("HealthText").GetComponent<Text>();
		powerText = GameObject.FindGameObjectWithTag("PowerText").GetComponent<Text>();
		livesText = GameObject.FindGameObjectWithTag("LivesText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);
		if (moveVertical > 0) {
			movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		} else {
			movement = new Vector3 (moveHorizontal, 0.0f, 0.0f);
		}

		rb.AddForce(movement * speed);

		healthText.text = "Health: " + health.ToString();
		livesText.text = "Lives: " + lives.ToString();
		powerText.text = "Power: " + power.ToString();

		CapHealth();
	}

	public void FightAverage() {
		infoText.text = "You have encountered an enemy! You managed to win but took some damage.";

		if (health > 50) {
			health -= 100 / (health - 50) * power;
		} else {
			RoundOver();
		}
	}

	public void FightStrong() {
		infoText.text = "You have encountered a BIG enemy! You managed to win but took some damage.";

		if (health > 80) {
			health -= 100 / (health - 80) * power;
		} else {
			RoundOver();
		}
	}

	public void IncreaseHealth() {
		infoText.text = "You reached a fountain! Your health is increased by 10.";
		health += 10;
		CapHealth();
	}

	public void IncreaseHealthFromShop() {
		infoText.text = "Your health is increased by 5.";
		health += 5;
		CapHealth();
	}

	public void IncreasePower() {
		infoText.text = "Your power was increased by 1.";
		power++;
	}

	public void GainLife() {
		infoText.text = "Your gained one life.";
		lives++;
	}

	private void CapHealth() {
		if (health > 100) {
			health = 100;
		}
	}
	
	private void RoundOver() {
		infoText.text = "You lost a life. Do you want to try again?";
		lives--;
		Freeze();
	}

	public void Win() {
		infoText.text = "You won!";
	}

	public void Freeze() {
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}
}
