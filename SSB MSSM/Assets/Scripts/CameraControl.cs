using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class CameraControl : MonoBehaviour {

	private IList<Vector2> screenCorners;

	void Start ()
	{
		screenCorners = new List<Vector2>();
	}

	void LateUpdate ()
	{
		screenCorners = getScreenCorners (PlayerControl.players);

		transform.position = ((screenCorners[0] + screenCorners[1])/2.0F);
		transform.position = new Vector3 (transform.position.x, 
		                                  Math.Max(0, transform.position.y*2),
		                                  -(screenCorners[0] - screenCorners[1]).magnitude); 
	}

	// algorithm could be more efficient, but doesn't really need to be given there are at most 4 players
	IList<Vector2> getScreenCorners (IList<Player> players)
	{
		float minX = getPos (players [0]).x;
		float maxX = getPos (players [0]).x;
		float minY = getPos (players [0]).y;
		float maxY = getPos (players [0]).y;

		for (int i = 0; i < players.Count; i++)
		{
			if (getPos(players[i]).x < minX)
			{
				minX = getPos(players[i]).x;
			}
			else if (getPos(players[i]).x > maxX)
			{
				maxX = getPos(players[i]).x;
			}
			if (getPos(players[i]).y < minY)
			{
				minY = getPos(players[i]).y;
			}
			else if (getPos(players[i]).y > maxY)
			{
				maxY = getPos(players[i]).y;
			}
		}


		IList<Vector2> corners = new List<Vector2>();
		corners.Add (new Vector2 (minX,minY));
		corners.Add (new Vector2 (maxX,maxY));

		return corners;
	}

	Vector3 getPos(Player player)
	{
		return player.rigidBody.transform.position;
	}
}