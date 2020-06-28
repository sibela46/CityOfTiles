using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
	public Player player;
	public bool visited;
	public int strength;

	// Use this for initialization
	void Start () {
		visited = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void OnCollisionEnter(Collision collision)
    {
		print(collision);
    }
}
