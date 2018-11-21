using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private float _speed = 20;
	private Rigidbody2D _rb;

	void Start () {
		_rb = GetComponent<Rigidbody2D>();
		_rb.velocity = transform.up * _speed;
	}
}
