using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTile : Tile {

	public FinalTile(GameObject tilePrefab, float x, float y, float z) {
		Instantiate(tilePrefab, new Vector3(x, y, z), Quaternion.identity);
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public override void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "Player(Clone)" && !visited) {
			Player playerScript = collision.gameObject.GetComponent<Player>();
			playerScript.Win();
			visited = true;
		}
	}
}
