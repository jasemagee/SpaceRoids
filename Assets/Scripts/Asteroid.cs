using System.Linq;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	private LineRenderer _lr;
	private PolygonCollider2D _pc;
	private Rigidbody2D _rb;
	private float _size = 0.5f;
	private Vector3 _force = Vector3.zero;

	private float _minSpeed = 60;
	private float _maxSpeed = 120;
	private float _torqueMinMax = 20;
	
	public AsteroidType AsteroidType = AsteroidType.Large;
	
	void Start () {
		_lr = GetComponent<LineRenderer>();
		_pc = GetComponent<PolygonCollider2D>();
		_rb = GetComponent<Rigidbody2D>();

		if (AsteroidType == AsteroidType.Offshoot) {
			_size = 0.1f;
		}
		
		
		var positions = new Vector3[6];
		for (int i = 0; i < positions.Length; i++) {
			positions[i] = HexCorner(Vector3.zero, _size, i);
		}

		_lr.positionCount = positions.Length;
		_lr.SetPositions(positions);

		_pc.SetPath(0, positions.Select(p => new Vector2(p.x, p.y)).ToArray());
		
		
		_rb.AddForce(_force);
		_rb.AddTorque(Random.Range(-_torqueMinMax,_torqueMinMax));	
			
	}

	public void BombsAway(Vector3 target) {
		_force = (target - transform.position).normalized * Random.Range(_minSpeed, _maxSpeed);
	}

	private Vector3 HexCorner(Vector3 center, float size, int i) {
		var angleDeg = 60 * i - 30;
		var angleRad = Mathf.PI / 180 * angleDeg;
		return new Vector3(center.x + size * Mathf.Cos(angleRad), center.y + size * Mathf.Sin(angleRad), 0);
	}

}

public enum AsteroidType {
	Large,
	Offshoot
}
