using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CoinScript : MonoBehaviour {
	Animator anim;
	public Transform interact;
	public AudioClip CoinSound;
	public bool gotCoin, coinCounted;
	private static int count = 0;
	// Use this for initialization
	void Start () {
		GameObject.Find ("ScoreText").GetComponent<Text> ().text = count.ToString();
		anim = GetComponent<Animator> ();
		gotCoin = false;
		coinCounted = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Physics2D.Linecast (transform.position, interact.position, 1 << LayerMask.NameToLayer ("Player"))) {
			anim.SetTrigger ("Got");
			gotCoin = true;

		}
		if (gotCoin && !coinCounted) {
				AudioSource.PlayClipAtPoint (CoinSound, transform.position);
				count=count+1;
				GameObject.Find ("ScoreText").GetComponent<Text> ().text = count.ToString();
				gotCoin = false;
				coinCounted =true;
		}
	}
}

