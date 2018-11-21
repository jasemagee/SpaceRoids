using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillWhenAwayFromPlayer : MonoBehaviour {

	private Player _player;
	private float _killDistance = 40;

	void Start () {
		_player = FindObjectOfType<Player>();
	}
	
	void Update () {
		if (Vector3.Distance(_player.transform.position, transform.position) > _killDistance) {
			Destroy(gameObject);
		}
	}
}
