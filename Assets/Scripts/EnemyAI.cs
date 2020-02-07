using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	private float speed;
	public float Speed;
	public Transform interactCheck,interactCheck2;

	private Animator anim;
	private bool  dead;
	private GameObject cameraScreen;
	private float attackTime;
	private float climbingTime;

	// Use this for initialization
	void Start () {
		Speed = 2f;
		this.speed = Speed;
		attackTime = Time.time;
		anim = GetComponent<Animator>();
		cameraScreen = GameObject.FindWithTag ("MainCamera");
		dead = false;
		climbingTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if ((transform.position.x - cameraScreen.transform.position.x) < 13 &&
		    (transform.position.x - cameraScreen.transform.position.x) > -13 &&
		    (transform.position.y - cameraScreen.transform.position.y) < 7 &&
		    (transform.position.y - cameraScreen.transform.position.y) > -7)
		{
			if (!dead) {
				Movement ();
			}
		}else {
			rigidbody2D.Sleep();
		}
	}
	void Movement(){

		transform.Translate (Vector3.right * speed * Time.deltaTime);

		if((Physics2D.Linecast(transform.position, interactCheck.position, 1 << LayerMask.NameToLayer ("Player")) ||
		    Physics2D.Linecast(transform.position, interactCheck2.position, 1 << LayerMask.NameToLayer ("Player")))
		    && PlayerControl.damageTime> Time.time
		   && !PlayerControl.dead){
			anim.SetTrigger("Dead") ;
			dead = true;
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		bool isBelow = transform.position.y - coll.transform.position.y < 0;
		if (coll.gameObject.layer == 17 && (isBelow || this.climbingTime >= Time.time) ){
			speed = 4.5f;
			climbingTime = Time.time + 0.8f;
		} else {
			speed = Speed;
		}
	}


}
