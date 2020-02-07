using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Player")) {
			StartCoroutine(WaitForIt());
			CameraController.following = false;
		}
	}	
	
	public IEnumerator WaitForIt(){
		yield return new WaitForSeconds (0.2f);
		GameMaster.winGUI = true;
		Time.timeScale = 0;
	}
}