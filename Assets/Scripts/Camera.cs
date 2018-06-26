using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Trejar");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
	}
}
