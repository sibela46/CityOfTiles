using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {
	public Player player;
	public GameObject playerPrefab;
	private string previousObjectHit;

    private List<Tile> tiles;
	public GameObject averageEnemyTilePrefab, strongEnemyTilePrefab, fountainTilePrefab, shopPrefab, finalTilePrefab, shopPanelPrefab, powerButtonPrefab, healthButtonPrefab, lifeButtonPrefab;
	private GameObject shopPanel;
	public GameObject canvas;

	// Use this for initialization
	void Start () {
		Camera.main.gameObject.AddComponent<CameraFollow>();

		player = new Player(playerPrefab);
		tiles = new List<Tile>();

		InitialiseButtons();

		// Initialise rows
		// Row 1
		tiles.Add(new AverageEnemyTile(averageEnemyTilePrefab, 7.5f, 0.0f, 15.0f));
		tiles.Add(new StrongEnemyTile(strongEnemyTilePrefab, -7.5f, 0.0f, 15.0f));
		// Row 2
		tiles.Add(new AverageEnemyTile(averageEnemyTilePrefab, 15.0f, 0.0f, 15.0f*2));
		tiles.Add(new FountainTile(fountainTilePrefab, 0.0f, 0.0f, 15.0f*2));
		tiles.Add(new StrongEnemyTile(strongEnemyTilePrefab, -15.0f, 0.0f, 15.0f*2));
		// Row 3
		tiles.Add(new StrongEnemyTile(strongEnemyTilePrefab, 7.5f, 0.0f, 15.0f*3));
		tiles.Add(new AverageEnemyTile(averageEnemyTilePrefab, -7.5f, 0.0f, 15.0f*3));
		// Row 4
		tiles.Add(new ShopTile(shopPrefab, 0.0f, 0.0f, 15.0f*4));
		tiles.Add(new StrongEnemyTile(strongEnemyTilePrefab, -15.0f, 0.0f, 15.0f*4));
		tiles.Add(new AverageEnemyTile(averageEnemyTilePrefab, 15.0f, 0.0f, 15.0f*4));
		// Row 5
		tiles.Add(new StrongEnemyTile(strongEnemyTilePrefab, 7.5f, 0.0f, 15.0f*5));
		tiles.Add(new AverageEnemyTile(averageEnemyTilePrefab, -7.5f, 0.0f, 15.0f*5));
		// Row 6
		tiles.Add(new StrongEnemyTile(strongEnemyTilePrefab, 0.0f, 0.0f, 15.0f*6));
		tiles.Add(new ShopTile(shopPrefab, -15.0f, 0.0f, 15.0f*6));
		tiles.Add(new AverageEnemyTile(averageEnemyTilePrefab, 15.0f, 0.0f, 15.0f*6));
		// Row 7
		tiles.Add(new StrongEnemyTile(strongEnemyTilePrefab, 7.5f, 0.0f, 15.0f*7));
		tiles.Add(new AverageEnemyTile(averageEnemyTilePrefab, -7.5f, 0.0f, 15.0f*7));
		// Row 8
		tiles.Add(new StrongEnemyTile(strongEnemyTilePrefab, 0.0f, 0.0f, 15.0f*8));
		tiles.Add(new ShopTile(shopPrefab, 15.0f, 0.0f, 15.0f*8));
		tiles.Add(new AverageEnemyTile(averageEnemyTilePrefab, 0.0f, 0.0f, 15.0f*8));
		// Row 9
		tiles.Add(new StrongEnemyTile(strongEnemyTilePrefab, 7.5f, 0.0f, 15.0f*9));
		tiles.Add(new AverageEnemyTile(strongEnemyTilePrefab, -7.5f, 0.0f, 15.0f*9));
		// Row 10
		tiles.Add(new FinalTile(finalTilePrefab, 0.0f, 0.0f, 15.0f*10));
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void InitialiseButtons() {
		shopPanel = (GameObject)Instantiate(shopPanelPrefab, GameObject.Find("Canvas").GetComponent<RectTransform>(), false);
		GameObject healthButton = (GameObject)Instantiate(healthButtonPrefab, shopPanel.GetComponent<RectTransform>(), false);
        healthButton.transform.SetParent(shopPanel.transform);
        healthButton.GetComponent<Button>().onClick.AddListener(IncreaseHealthClick);
        healthButton.transform.GetChild(0).GetComponent<Text>().text = "Increase Health";

		GameObject powerButton = (GameObject)Instantiate(powerButtonPrefab, shopPanel.GetComponent<RectTransform>(), false);
        powerButton.transform.SetParent(shopPanel.transform);
        powerButton.GetComponent<Button>().onClick.AddListener(IncreasePowerClick);
        powerButton.transform.GetChild(0).GetComponent<Text>().text = "Increase Power";

		GameObject lifeButton = (GameObject)Instantiate(lifeButtonPrefab, shopPanel.GetComponent<RectTransform>(), false);
        lifeButton.transform.SetParent(shopPanel.transform);
        lifeButton.GetComponent<Button>().onClick.AddListener(IncreasePowerClick);
        lifeButton.transform.GetChild(0).GetComponent<Text>().text = "Gain Life";
		
		shopPanel.SetActive(false);
	}

	public void GameOver() {
		if (player.health <= 100) {
			Destroy(player);
		}
	}

	public void IncreaseHealthClick() {
		Player playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		playerScript.IncreaseHealthFromShop();
		shopPanel.SetActive(false);
	}

	public void IncreasePowerClick() {
		Player playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		playerScript.IncreasePower();
		shopPanel.SetActive(false);
	}

	public void GainLifeClick() {
		Player playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		playerScript.GainLife();
		shopPanel.SetActive(false);
	}

	public void Shop() {
		Player playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		playerScript.Freeze();
		shopPanel.SetActive(true);
	}
	
}
