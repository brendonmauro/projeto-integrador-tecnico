using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

	public Transform interactCheck;
	Animator anim;
	private bool dead, interacted;
	public AudioClip HitSound;
	private  float timeHit;
	// Use this for initialization
	void Start () {
		interactCheck = GameObject.FindWithTag ("Interact").transform;
		anim = GetComponent<Animator>();
		dead = false;
		interacted = false;
		timeHit = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.F) && Physics2D.Linecast (transform.position, transform.position,
		                                                   1 << LayerMask.NameToLayer ("Player")) && !dead ){
			anim.SetTrigger ("Interacted");
			dead = true;
			interacted =true;
		}
		if (interacted && !PlayerControl.dead && timeHit<=Time.time ){
			AudioSource.PlayClipAtPoint(HitSound, transform.position);
			interacted =false;
			timeHit = Time.time + 0.3f;
		}
	}


}
