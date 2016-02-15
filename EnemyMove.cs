using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {
	public int speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.down * speed * Time.deltaTime);
	}
}
