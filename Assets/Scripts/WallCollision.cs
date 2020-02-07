using UnityEngine;
using System.Collections;

public class WallCollision : MonoBehaviour {
	private float nextTime = 0;

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag =="Enemy" ){
			Vector3 contactPoint = coll.contacts [0].point;
			Vector3 center = coll.collider.bounds.center;
			
			bool right = contactPoint.x > center.x;
			bool left = contactPoint.x < center.x;
			if (left && nextTime<= Time.time) {
				coll.transform.eulerAngles = new Vector2 (0, 0);
			} else if (right && nextTime<= Time.time) {
				coll.transform.eulerAngles = new Vector2 (0, 180);
			} 

		}		
	}
}
