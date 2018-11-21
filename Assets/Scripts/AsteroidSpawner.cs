using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

	public GameObject AsteroidPrefab;
	public Player Player;

	private float _startSpawn = 20;
	private float _spawnFromPlayerRange = 30;
	private float _spawnTargetRange = 10;
	private float _fireRate = 0.1f;
	private float _nextFire;
	

	// Use this for initialization
	void Start () {

		for (int i = 0; i < _startSpawn; i++) {
			CreateAsteriod();
		}
	}

	private void CreateAsteriod() {
		var go = Instantiate(AsteroidPrefab, GetRandomPosNotOnPlayer(), Quaternion.identity, transform);
		var a = go.GetComponent<Asteroid>();

		a.BombsAway(GetTargetNearPlayer());
	}

	private Vector3 GetTargetNearPlayer() {

		var pX = Player.transform.position.x;
		var pY = Player.transform.position.y;
		var randomPos = Random.insideUnitCircle * (_spawnTargetRange);
		return new Vector3(randomPos.x + pX, randomPos.y + pY, 0);	
	}

	private Vector3 GetRandomPosNotOnPlayer() {

		//var pX = Player.transform.position.x;
		//var pY = Player.transform.position.y;

		//return Random.insideUnitCircle* _spawnFromPlayerRange;

/*			float angle = Random.Range (0f, Mathf.PI * 2);
			float x = Mathf.Sin (angle) * _spawnFromPlayerRange;
			float y = Mathf.Cos (angle) * _spawnFromPlayerRange;

			return new Vector2 (x+pX, y+pY);*/
		
		var outsides = (Random.insideUnitCircle.normalized * _spawnFromPlayerRange);
		var randomPos = Player.transform.position + new Vector3(outsides.x, outsides.y, 0);
		return randomPos;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > _nextFire)
		{
			CreateAsteriod();
			_nextFire = Time.time + _fireRate;
	
		}
	}

	private void OnDrawGizmos() {
		if (Player == null) {
			return;
		}
		
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(Player.transform.position, _spawnFromPlayerRange);
		
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(Player.transform.position, _spawnTargetRange);
	}
}
