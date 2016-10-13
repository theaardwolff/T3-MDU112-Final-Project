using UnityEngine;
using System.Collections.Generic;

public class PlayerScript : MonoBehaviour {

	public float playerLevel = 5.0f;

	public float xpNeeded = 10.0f;
	public float xpCurrent = 10.0f;
	public float xpGained = 100.0f;

	public float agility = 10.0f;
	public float stat2 = 10.0f;
	public float stat3 = 10.0f;

	public float currentSpeed = 0.0f;
	public float maximumSpeed = 100.0f;

	public bool speedBoost = false;

	bool agilityBonus = false;
	bool stat2Bonus = false;
	bool stat3Bonus = false;
	bool noBonus = false;

	float randomRoll = 0.0f;
	float randomAgility = 0.0f;
	float randomStat2 = 0.0f;
	float randomStat3 = 0.0f;


	void Start () {
	
		currentSpeed = (agility * 10.0f);

			if (speedBoost == true) {
				currentSpeed = (currentSpeed * 10 );
			}

			if (currentSpeed > maximumSpeed) {
				currentSpeed = maximumSpeed;
			}

			else if (currentSpeed < maximumSpeed) {
				currentSpeed = maximumSpeed;
			}

		Debug.Log (currentSpeed);

		xpCurrent = (xpCurrent + xpGained);
		xpNeeded = (Mathf.Round (((playerLevel / 15.0f) * 250) - xpCurrent));
		
		if (xpNeeded <= xpCurrent) {
			LevelUp ();
			
		}

		else if (xpNeeded > xpCurrent) {
		Debug.Log ("You need " + xpNeeded + " XP!");
		}
	}
	

	void LevelUp () {

		Debug.Log ("Level Up!");




		playerLevel = (playerLevel + 1.0f);

		randomRoll = (Random.Range (1, 10));	// This runs 1, 2, 3… 9 & 10. Floats are inclusive. Integers are exclusive. 
		randomAgility = (Random.Range ((100.0f - agility), agility));
		randomStat2 = (Random.Range ((100.0f - stat2), stat2));
		randomStat3 = (Random.Range ((100.0f - stat3), stat3));

		if (randomRoll == 1 || randomRoll == 2 || randomRoll == 3) {	// If the random roll is 1, 2 or 3...
			if (randomAgility == 0) {	//... then ask is randomAgility is _______
				agilityBonus = true;	//If so, then the bonus is attributed to Agility.
			}
		} 
		else if (randomRoll == 4 || randomRoll == 5 || randomRoll == 6) {	// If the random roll is 4, 5 or 6...
			if (randomStat2 == 0) {
				stat2Bonus = true;
			}
		} 
		else if (randomRoll == 7 || randomRoll == 8 || randomRoll == 9) {	// If the random roll is 7, 8 or 9...
			if (randomStat3 == 0) {
				stat3Bonus = true;
			}
		}
		else if (randomRoll == 10){	// If the random roll is 10...
			noBonus = true;	// ...Then there is no bonus.
		}


		if (agilityBonus == true) {
			Debug.Log ("agility");
		}

		else if (stat2Bonus == true) {
			Debug.Log ("stat2");
		}

		else if (stat3Bonus == true) {
			Debug.Log ("stat3");
		}

		else if (noBonus == true) {
			Debug.Log ("no bonus");
		}

	}
}
