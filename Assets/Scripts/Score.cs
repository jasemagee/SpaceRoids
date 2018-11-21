using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour {

	public Player Player;
	private TextMeshProUGUI _text;
	private float _timer = 0;	
	
	// Use this for initialization
	void Start () {

		_text = GetComponent<TextMeshProUGUI>();
		_text.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.HasHitSomething()) {
			_timer = 0;
			Player.ResetHasHitSomething();
		}

		_timer += Time.deltaTime;
		var seconds = (int) (_timer);
		_text.text = seconds.ToString();
	}
}
