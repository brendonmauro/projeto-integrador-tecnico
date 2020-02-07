using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	bool grounded, interact; //Bool for checking if player is grounded so he can jump.
	public Transform jumpCheck, interactCheck;
	public float speed = 6f;
    public float JumpForce = 400f;
	public AudioClip AttackSound;
	float jumpTime, jumpDelay = 1f;
	private float attackTime;
	private bool jumped;
	public static bool dead;
	RaycastHit2D interacted;
	Animator anim;
	public static float damageTime;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		attackTime = Time.time;
		dead = false;
		damageTime = Time.time;
		jumpTime = 0;
	}
	
	// Update is called once per frame
	void Update() {
		if (Time.timeScale == 1 && !dead) {
			Movement ();
		}
		RaycastStuff();
	}

	void RaycastStuff() {
		//Debug.DrawLine (transform.position, jumpCheck.position, Color.magenta);
		//Debug.DrawLine (transform.position, interactCheck.position, Color.magenta);

		grounded = Physics2D.Linecast(transform.position, jumpCheck.position, 1 << LayerMask.NameToLayer ("Ground")) ||
			Physics2D.Linecast(transform.position, jumpCheck.position, 1 << LayerMask.NameToLayer ("Slope"));
		if (!grounded)
			anim.SetTrigger("Jump");
		if (Physics2D.Linecast(transform.position, interactCheck.position, 1 << LayerMask.NameToLayer("Guard"))) {
			interacted = Physics2D.Linecast(transform.position, interactCheck.position, 1 << LayerMask.NameToLayer("Guard"));
			interact = true;
		}
		else {
			interact = false;
		}
	}



	void Movement() {
		anim.SetFloat ("speed", Mathf.Abs (Input.GetAxis ("Horizontal"))); //Makes it record a value of speed between -1 and 1, so that the trigger of the animation can work.

		if (Input.GetAxisRaw ("Horizontal") > 0) {
				transform.Translate (Vector3.right * speed * Time.deltaTime);//speed * Time.deltaTime makes things smoother, it updates frame by frame, so that it does not jump all around 
				transform.eulerAngles = new Vector2 (0, 0);
		}
		if (Input.GetAxisRaw ("Horizontal") < 0) {
				transform.Translate (Vector3.right * speed * Time.deltaTime); 
				transform.eulerAngles = new Vector2 (0, 180);
		}

		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			rigidbody2D.AddForce(transform.up * JumpForce);
			anim.SetTrigger("Jump");
			jumped = true;

		}
		if (Input.GetKeyDown(KeyCode.F) && attackTime<=Time.time){
			anim.SetTrigger("Attack");
			AudioSource.PlayClipAtPoint(this.AttackSound, transform.position);
			attackTime = Time.time +0.5f;
			damageTime = Time.time +0.15f;

		}


		if (grounded) { //Ele retorna a 0 e o objeto volta pro chao
			anim.SetTrigger ("Land");
			jumped = false;
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag =="Enemy" && attackTime <=Time.time){
			StartCoroutine(WaitForIt());
			CameraController.following = false;
			anim.SetTrigger("Dead");
			dead =true;
		}
	}

	public IEnumerator WaitForIt(){
		yield return new WaitForSeconds (1f);
		GameMaster.deadGUI = true;
		Time.timeScale = 0;
	}

}
