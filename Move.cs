using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Move : MonoBehaviour {
	public int moveSpeed;
	public GameObject enemy;
	public int enemySpeed;
	public GameObject hair;
	public GameObject hairPos;
	public int score;
	public Text scoreText;

	IEnumerator Enemy(){
		yield return new WaitForSeconds(1.0f);
		GameObject newEnemy = (GameObject)Instantiate(enemy, new Vector2 (Random.Range (-8,8), 6), Quaternion.identity);

		StartCoroutine(Enemy ());

	}

	// Use this for initialization
	void Start () {
		score = 0;
		StartCoroutine(Enemy ());
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x<=8 && transform.position.x>=-8){
			if (Input.acceleration.x > .1)
			{	
				transform.Translate(-Vector3.left * (moveSpeed * Time.deltaTime * Input.acceleration.x), Space.World);
			}
			else if (Input.acceleration.x < -.1)
			{
				transform.Translate(-Vector3.left* (-moveSpeed * Time.deltaTime * -Input.acceleration.x), Space.World);
			}
		}
		else{
			if(transform.position.x<-8){
				Vector2 temp = new Vector2(-8, transform.position.y);
				transform.position = temp;
			}
			if(transform.position.x>8){
				Vector2 temp = new Vector2(8, transform.position.y);
				transform.position = temp;
			}
		}
		Ray ray = new Ray(this.transform.position, transform.up);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 100)) {
			Debug.DrawLine (ray.origin, hit.point, Color.red);
			for(var i = 0; i < Input.touchCount; i++){
					if(Input.GetTouch(i).phase == TouchPhase.Began){
								Destroy(hit.transform.gameObject);
					if(hit.collider.tag.Contains("Player")){
								score+=1;
					scoreText.text = score.ToString();
					}

							}
			}
		}
		for(var i = 0; i<Input.touchCount; i++){
			if(Input.GetTouch(i).phase == TouchPhase.Began){
				GameObject newHair = (GameObject)Instantiate(hair, hairPos.transform.position, Quaternion.identity);
				//newHair.transform.Translate(Vector2.up* 50*Time.deltaTime);
			}
		}
	}
}
