using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	private Vector3 offset;

	void Start ()
	{
		offset = transform.position - ((player1.transform.position + player2.transform.position)/2.0F);
	}

	void LateUpdate ()
	{
		transform.position = ((player1.transform.position + player2.transform.position)/2.0F) + offset;
		transform.position = new Vector3 (transform.position.x, 
		                                  transform.position.y,
		                                  -(player1.transform.position - player2.transform.position).magnitude/2.0F - 7);
	}
}