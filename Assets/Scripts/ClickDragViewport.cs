using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDragViewport : MonoBehaviour {


	public float dragSpeed = 2;
	private Vector3 dragOrigin;
	public bool cameraDragging = true;

	public float outerLeft = -35f;
	public float outerRight = 145f;

	void Start () {
		this.transform.position = new Vector3(outerLeft, this.transform.position.y, this.transform.position.z);
	}
	
	void Update () {

		Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

		float left = Screen.width * 0.2f;
		float right = Screen.width - (Screen.width * 0.2f);

		if(mousePosition.x < left)
		{
			cameraDragging = true;
		}
		else if(mousePosition.x > right)
		{
			cameraDragging = true;
		}

		if (cameraDragging) {

			if (Input.GetMouseButtonDown(0))
			{
				dragOrigin = Input.mousePosition;
				return;
			}

			if (!Input.GetMouseButton(0)) return;

			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
			Vector3 move = new Vector3(pos.x * dragSpeed, 0, 0);

			Debug.Log ("move x: " + move.x);

			if (move.x > 0f)
			{
				if(this.transform.position.x < outerRight)
				{
					transform.Translate(move, Space.World);
				}
			}
			else{
				if(this.transform.position.x > outerLeft)
				{
					transform.Translate(move, Space.World);
				}
			}
		}
	}
}
