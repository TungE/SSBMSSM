using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

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
	public Dictionary<string, KeyCode> moveSet; 

	public Rigidbody rigidBody;

	// constructor
	public Player (int numID, Rigidbody rb, Text plaTex, Dictionary<string, KeyCode> movSet)
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
		moveSet = movSet;
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

	public void onDeath()
	{
		--stocksLeft;
		updateText();

		if (stocksLeft < 1)
		{
			// end the game
		}
	}

	public void reSpawn()
	{
		rigidBody.transform.position = new Vector3 (0,10,0);
		rigidBody.velocity = new Vector3 (0, 0, 0);
	}

	public bool isDead()
	{
		int lowerYBound = -10; 
		int upperYBound = 30;
		int lowerXBound = -40;
		int upperXBound = 40;
		return rigidBody.transform.position.y < lowerYBound || 
			   rigidBody.transform.position.y > upperYBound ||
			   rigidBody.transform.position.x < lowerXBound ||
			   rigidBody.transform.position.x > upperXBound;
	}

	public void jump()
	{
		rigidBody.velocity = new Vector3 (0, 10, 0);
		--jumpsLeft;
	}

	public bool canJump()
	{
		return jumpsLeft > 0;
	}

	public void normalizeZpos ()
	{
		rigidBody.transform.position = new Vector3(rigidBody.transform.position.x, rigidBody.transform.position.y, 0);
	}

	public void moveLeft()
	{
		moveX -= 1;
	}

	public void moveRight()
	{
		moveX += 1;
	}

	public void moveHorizontal()
	{
		Vector3 movement = new Vector3 (moveX, 0.0f, 0.0f);
		rigidBody.AddForce (movement * speed);
	}
} 

public class PlayerControl : MonoBehaviour 
{
	public GameObject pauseMenuCanvas;

	public Player player1;
	public GameObject p1go;
	public Dictionary<string, KeyCode> p1moveSet;
	public Text pla1Tex;

	public Player player2;
	public GameObject p2go;
	public Dictionary<string, KeyCode> p2moveSet;
	public Text pla2Tex;

	public Player player3;
	public GameObject p3go;
	public Dictionary<string, KeyCode> p3moveSet;
	public Text pla3Tex;

	/*
	public Player player4;
	public GameObject p4go;
	public Dictionary<string, KeyCode> p4moveSet;
	public Text pla4Tex;
	*/

	static public IList<Player> players; 

	// Use this for initialization
	void Start () 
	{
		// put all of this in a init function // TODO
		p1moveSet = new Dictionary<string, KeyCode> (){{"jump", KeyCode.W},{"left", KeyCode.A},{"right", KeyCode.D},{"pause", KeyCode.P}};
		p2moveSet = new Dictionary<string, KeyCode> (){{"jump", KeyCode.T},{"left", KeyCode.F},{"right", KeyCode.H},{"pause", KeyCode.P}};
		p3moveSet = new Dictionary<string, KeyCode> (){{"jump", KeyCode.I},{"left", KeyCode.J},{"right", KeyCode.L},{"pause", KeyCode.P}};

		p1go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		p1go.AddComponent<Rigidbody> ();
		p1go.transform.position = new Vector3 (-8,6,0);

		p2go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		p2go.AddComponent<Rigidbody> ();
		p2go.transform.position = new Vector3 (0,6,0);

		p3go = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		p3go.AddComponent<Rigidbody> ();
		p3go.transform.position = new Vector3 (8,6,0);

		player1 = new Player (1, p1go.GetComponent<Rigidbody>(), pla1Tex, p1moveSet);
		player1.updateText ();

		player2 = new Player (2, p2go.GetComponent<Rigidbody>(), pla2Tex, p2moveSet);
		player2.updateText ();

		player3 = new Player (3, p3go.GetComponent<Rigidbody>(), pla3Tex, p3moveSet);
		player3.updateText();

		players = new List<Player>();
		players.Add (player1);
		players.Add (player2);
		players.Add (player3);
	}
	
	// Update is called once per frame
	void Update () 
	{
		for (int i = 0; i < players.Count; ++i)
		{
			// jumping
			if (Input.GetKeyDown (players[i].moveSet["jump"]) && players[i].canJump()) 
			{
				players[i].jump();
			}

			// horizontal movement
			if (Input.GetKeyDown (players[i].moveSet["left"])) 
			{
				players[i].moveLeft();
			} 
			else if (Input.GetKeyUp (players[i].moveSet["left"])) 
			{
				players[i].moveRight();
			}
			if (Input.GetKeyDown (players[i].moveSet["right"])) 
			{
				players[i].moveRight();
			}
			else if (Input.GetKeyUp (players[i].moveSet["right"])) {
				players[i].moveLeft();
			}

			// float moveHorizontal = Input.GetAxis ("Horizontal");
			players[i].moveHorizontal();

			// pausing the game 
			if (Input.GetKeyDown (players[i].moveSet["pause"])) {
				pauseMenuCanvas.SetActive (true);
				Time.timeScale = 0.0f;
			}

			// if you die
			if (players[i].isDead())
			{
				players[i].onDeath();
				players[i].reSpawn();
			}

			// keep players from sliding off in the z axis
			players[i].normalizeZpos ();
		}
	}

	// handling collisions with map, including players colliding with map
	void OnCollisionEnter(Collision col) 
	{
		for (int i = 0; i < players.Count; i++)
		{
			if (col.rigidbody == players[i].rigidBody)
			{
				players[i].handleMapCollision();
			}
		}
	}

}
