using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float RotForce = 3;
	public float AccelForce = 10;
	
	private Rigidbody2D _rb;
	private float _accel = 0;
	private float _rot = 0;
	
	public GameObject Shot;
	public Transform ShotSpawn;
	private float _fireRate = 0.4f;

	private float _nextFire;
	private bool _hasHitSomething = false;

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		_accel = Input.GetAxis("Vertical");
		_rot = -Input.GetAxis("Horizontal");
		
		if (Input.GetButton("Fire1") && Time.time > _nextFire)
		{
			_nextFire = Time.time + _fireRate;
			Instantiate(Shot, ShotSpawn.position, ShotSpawn.rotation);
		}
	}

	private void FixedUpdate() {
		_rb.AddTorque(_rot * RotForce);
		_rb.AddForce(transform.up * _accel * AccelForce);	
	}

	private void OnCollisionEnter2D(Collision2D other) {
		_hasHitSomething = true;
	}

	public bool HasHitSomethig() {
		return _hasHitSomething;
	}

	public void ResetHasHitSomething() {
		_hasHitSomething = false;
	}
}
