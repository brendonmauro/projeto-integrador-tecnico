using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public Transform Player;
	private float positionY;
	public Vector2
		Margin,
		Smoothing;
	
	public BoxCollider2D Bounds;
	
	private Vector3
		_min,
		_max;
	public static bool following;
	
	public bool IsFollowing {
		get;
		set;
	}
	
	
	// Use this for initialization
	void Start () {
		_min = Bounds.bounds.min;
		_max = Bounds.bounds.max;
		IsFollowing = true;
		following = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (following)
		{ 
			positionY = Player.position.y + 2;
			var x = transform.position.x;
			var y = transform.position.y;
			
			if (IsFollowing) {
				if (Mathf.Abs (x - Player.position.x) > Margin.x)
					x = Mathf.Lerp (x, Player.position.x, Smoothing.x * Time.deltaTime);
				if (Mathf.Abs (y - Player.position.y) > Margin.y)
					y = Mathf.Lerp (y, positionY, Smoothing.y * Time.deltaTime);
				
			}
			var cameraHalfWidth = camera.orthographicSize * ((float)Screen.width / Screen.height);
			
			x = Mathf.Clamp(x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
			y = Mathf.Clamp (y, _min.y + camera.orthographicSize, _max.y - camera.orthographicSize);
			
			transform.position = new Vector3 (x, y, transform.position.z);
		}	 
	}
}
