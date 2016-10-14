using UnityEngine;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {


	public float playerLevel = 1.0f;	// The player's current level.

	public float xpNeeded = 0.0f;		// The amount of xp needed to level up.
	public float xpCurrent = 0.0f;		// The player's current amount of xp.
	public float xpGained = 0.0f;		// The amount of xp gained by the player.

	public float agility = 0.0f;		// The current Agility stat.
	public float speedboost = 0.0f;	// The current Speed Boost stat.
	public float stat3 = 0.0f;			// The current *stat3* stat.

	public float currentSpeed = 0.0f;	// The player's current speed. This will vary greatly.
	public float maximumSpeed = 100.0f;	// The maximum speed the player can move at.

	public bool activeBoost = false;	// Binary function determining if a speed boost is active or not. This will be activated in-game.
	public bool activeXP = false;		// Binary function determining if the player is gaining XP. This will be activated in-game.

	float randomRoll = 0.0f;			// Stores the value of the random 1-10 roll.
	float randomAgility = 0.0f;			// Stores the value of the random Agility roll.
	float randomSpeedboost = 0.0f;		// Stores the value of the random Speed Boost roll.
	float randomStat3 = 0.0f;			// Stores the value of the random *stat3* roll.


	void Start () {

		CurrentSpeed ();		// In full version, this will be affected by gravity and movement controls. This will run constantly in the background.
		if (activeXP == true) {	// In full version, this will be activated whenever XP gain is detected at the end of a level.
			XPGaining ();	
		}
		XPRequired ();			// In full version, this (or a section of this code) will be run every frame and displayed on a GUI.
	}


	void CurrentSpeed () {	// Managing the current speed of the player. This will be tweaked when movement is implimented.

		currentSpeed = (agility * 2.0f );	// The current speed is determined by the player's agility.

		if (activeBoost == true) {	// If the speed boost is activated (by reaching a certain speed in full version)...
			currentSpeed = (currentSpeed * (speedboost + 1));	// ...then the current speed is multiplied by the boost stat. Speed boost cannot go over "maximum speed". 
		}

		if (currentSpeed > maximumSpeed) {	// If the player's current speed value is over the maximum speed...
			currentSpeed = maximumSpeed;	// ...then make the player's speed the maximum speed.
		}

		else {
			currentSpeed = (currentSpeed + 0.0f);	// If none of these variables meet, then the current speed is unaffected.
		}

		Debug.Log ("Your current speed is: " + currentSpeed);	// This will output the player's current speed.
	}


	void XPGaining () {	// The function that activates whenever XP is gained.

		xpCurrent = (xpCurrent + xpGained);

		if (xpNeeded <= xpCurrent) {
			LevelUp ();
		}
	}


	void XPRequired () {	// Managing the amount of XP required to level up.

		xpNeeded = (Mathf.Round (((playerLevel / 15.0f) * 250) - xpCurrent));	// xpNeeded is a sum, with the current xp subtracted from it, and rounded.

		if (xpNeeded > xpCurrent) {	// If you need more xp than you have...
			Debug.Log ("You need " + xpNeeded + " XP.");	// The console will tell you how much you need.
		} 
	}
		

	void LevelUp () { //The function for leveling up.

		Debug.Log ("Level Up!");

		playerLevel = (playerLevel + 1.0f);

		randomRoll = (Random.Range (1, 11));	// This runs 1, 2, 3… 9 & 10. Floats are inclusive. Integers are exclusive. 
		randomAgility = (Random.Range ((15.0f - agility), 1.0f));
		randomSpeedboost = (Random.Range ((15.0f - speedboost), 1.0f));
		randomStat3 = (Random.Range ((15.0f - stat3), 1.0f));

		if (randomRoll == 10) {	// If the random roll is anything else...
			Debug.Log ("No Bonus");
		}
		
		else if (randomRoll == 1 || randomRoll == 2 || randomRoll == 3) {	// If the random roll is 1, 2 or 3...
			if (randomAgility < 5) {	//... then ask is randomAgility is _______
				agility = (agility + 1);	//If so, then the bonus is attributed to Agility.
				Debug.Log ("Speed Bonus");
			}
		} 
		else if (randomRoll == 2) {	// If the random roll is 4, 5 or 6...
			if (randomSpeedboost < 5) {
				speedboost = (speedboost + 1);	//If so, then the bonus is attributed to Agility.
				Debug.Log ("Boost Bonus");
			}
		} 
		else if (randomRoll == 3) {	// If the random roll is 7, 8 or 9...
			if (randomStat3 < 5) {
				stat3 = (stat3 + 1);	//If so, then the bonus is attributed to Agility.
				Debug.Log ("stat3 Bonus");
			}
		}
	}
}
	