using UnityEngine;
using System.Collections;

public class FlyAI : MonoBehaviour {
	private float limit;
	public float speed = 4;
	public float upForce = 1000;
	public Transform interactCheck,interactCheck2;
	public Transform player;
	private Animator anim;
	public Vector2 Smoothing;
	private bool dead = false;
	private GameObject cameraScreen;
	private float attackTime;
	
	void Start(){
		anim = GetComponent<Animator>();
		player = GameObject.FindWithTag("Player").transform;
		cameraScreen = GameObject.FindWithTag ("MainCamera");
		attackTime = Time.time;
	}
	void Update(){
		limit = player.position.y + 1;
		if ((transform.position.x - cameraScreen.transform.position.x) < 13 &&
		    (transform.position.x - cameraScreen.transform.position.x) > -13 &&
		    (transform.position.y - cameraScreen.transform.position.y) < 7 &&
		    (transform.position.y - cameraScreen.transform.position.y) > -7) {
			if (!dead) {
				Movement ();
			} else {
				rigidbody2D.gravityScale = 2;
			}

		} 
	}
	
	
	void Movement(){		
		Following ();
		
		if((Physics2D.Linecast(transform.position, interactCheck.position, 1 << LayerMask.NameToLayer ("Player")) ||
		   Physics2D.Linecast(transform.position, interactCheck2.position, 1 << LayerMask.NameToLayer ("Player")))
		   && PlayerControl.damageTime> Time.time
		   && !PlayerControl.dead){
			anim.SetTrigger("Target");
			dead = true;
		}
		
	}
	
	void Following(){
		var xAngle = Mathf.LerpAngle (transform.eulerAngles.y, player.eulerAngles.y, Time.deltaTime);

		if (transform.position.x - player.position.x >= 0)
		{

			transform.eulerAngles = new Vector2(0, 180);
		}
		else if (transform.position.x - player.position.x < -0.4)
		{
			transform.eulerAngles = new Vector2(0, 0);
		}
		else if (transform.position.y - player.position.y >= 0)
		{
			transform.Translate(Vector3.down * speed * Time.deltaTime);
			return;
		} 
		else 
		{ 
			transform.Translate(Vector3.up * speed * Time.deltaTime);
			return;
		}

		if (transform.position.y - player.position.y >= 0)
			transform.Translate(Vector3.down * speed/3 * Time.deltaTime);
		else
			transform.Translate(Vector3.up * speed/3 * Time.deltaTime);

		transform.Translate(Vector3.right * speed * Time.deltaTime);
	
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.CompareTag ("Interact") && Input.GetKeyUp (KeyCode.F)) {
			anim.SetTrigger("Dead");
			dead = true;
		}
	}
}