using UnityEngine;
using System.Collections;

public class InteractCheckScript : MonoBehaviour {

	public Transform jumpCheck;
	private bool grounded;
	private float attackTime;

	Animator anim;
	// Use this for initialization
	void Start () {
		attackTime = Time.time;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.Linecast(transform.position, jumpCheck.position, 1 << LayerMask.NameToLayer ("Ground"));

		if (Input.GetAxisRaw ("Horizontal") > 0) {
			if (!audio.isPlaying && grounded) {
				audio.Play();
			}
		} else if (Input.GetAxisRaw ("Horizontal") < 0) {
			if (!audio.isPlaying && grounded) {
				audio.Play();
			}
		} else {
			audio.Stop ();
		}

		if (Input.GetKeyDown (KeyCode.F) && attackTime<=Time.time && !PlayerControl.dead) {
			anim.SetTrigger("Attack");
			audio.Stop ();
			attackTime = Time.time + 0.5f;
		}

		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			audio.Stop ();
		}

	
	}
}
