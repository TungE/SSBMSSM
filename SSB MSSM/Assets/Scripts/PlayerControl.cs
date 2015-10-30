using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player
{
	public Text playerText;
	public int numberID;
	public int percentage;
	public float speed;
	public int stocksLeft;
	public int maxJumps;
	public int jumpsLeft;
	public int moveX;

	public Rigidbody rigidBody;

	// constructor
	public Player (int numID, Rigidbody rb, Text plaTex)
	{
		numberID = numID;
		percentage = 0;
		speed = 25;
		stocksLeft = 4; 
		maxJumps = 2;
		jumpsLeft = 2;
		moveX = 0;
		rigidBody = rb;
		playerText = plaTex;
	}

	// update 'stocks left' text
	public void updateText()
	{
		// | P1 | Stocks: 4 | Percent: 0 % | //
		playerText.text = "| P" + numberID.ToString() + " | Stocks: " + stocksLeft.ToString () + " | Percent: " + 
			percentage.ToString () + " % | ";
	}

	public void handleMapCollision()
	{
		jumpsLeft = maxJumps;
	}
} 

public class PlayerControl : MonoBehaviour 
{
	public Player player1;
	public GameObject pauseMenuCanvas;
	public Text plaTex; 

	// Use this for initialization
	void Start () 
	{
		player1 = new Player (1, GetComponent<Rigidbody>(), plaTex);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// jumping
		if (Input.GetKeyDown (KeyCode.W) && player1.jumpsLeft > 0) 
		{
			player1.rigidBody.velocity = new Vector3 (0, 10, 0);
			player1.jumpsLeft--;
		}

		// horizontal movement
		if (Input.GetKeyDown (KeyCode.A)) {
			player1.moveX -= 1;
		} 
		else if (Input.GetKeyUp (KeyCode.A)) {
			player1.moveX += 1;
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			player1.moveX += 1;
		} 
		else if (Input.GetKeyUp (KeyCode.D)) {
			player1.moveX -= 1;
		}

		// float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector3 movement = new Vector3 (player1.moveX, 0.0f, 0.0f);
		player1.rigidBody.AddForce (movement * player1.speed);

		// pausing the game 
		if (Input.GetKeyDown (KeyCode.P)) {
			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0.0f;
		}

		// if you die
		if (player1.rigidBody.transform.position.y < -10)
		{
			player1.rigidBody.transform.position = new Vector3 (0,0,0);
			--player1.stocksLeft;
			player1.updateText();
			player1.rigidBody.velocity = new Vector3 (0,0,0);
		}
	}
	
	// upon hitting something
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag ("ground"))
		{
			player1.handleMapCollision();
		}
	}
}