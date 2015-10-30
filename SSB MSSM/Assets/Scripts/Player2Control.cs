using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player2Control : MonoBehaviour 
{	
	public int playerNumber;
	public Text stocksText;
	public Text percentText;
	public float speed;
	public int maxJumps;
	public int maxStocks;
	private int jumpsLeft;
	private int stocksLeft;
	private int percent;
	private Rigidbody rb;
	private int moveX;
	
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		jumpsLeft = maxJumps;
		stocksLeft = maxStocks;
		updateStocksText();
		moveX = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.I) && jumpsLeft > 0) 
		{
			rb.velocity = new Vector3 (0, 10, 0);
			jumpsLeft--;
		}

		if (Input.GetKeyDown (KeyCode.J)) {
			moveX -= 1;
		} 
		else if (Input.GetKeyUp (KeyCode.J)) {
			moveX += 1;
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			moveX += 1;
		} 
		else if (Input.GetKeyUp (KeyCode.L)) {
			moveX -= 1;
		}
		
		// float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector3 movement = new Vector3 (moveX, 0.0f, 0.0f);
		rb.AddForce (movement * speed);

		// if you die
		if (rb.transform.position.y < -10)
		{
			rb.transform.position = new Vector3 (0,0,0);
			--stocksLeft;
			updateStocksText();
			rb.velocity = new Vector3 (0,0,0);
		}
	}
	
	// upon hitting something
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Map")
		{
			jumpsLeft = maxJumps;
		}
	}
	
	// update 'stocks left' text
	void updateStocksText()
	{
		stocksText.text = "P" + playerNumber.ToString() + " Stocks: " + stocksLeft.ToString ();
	}
}