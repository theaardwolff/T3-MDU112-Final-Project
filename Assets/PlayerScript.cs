using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	float playerLevel = 0.0f;

	float xpNeeded = 0.0f;
	float xpCurrent = 0.0f;
	float xpGained = 0.0f;

	float agility = 10.0f;
	float stat2 = 10.0f;
	float stat3 = 10.0f;

	float currentSpeed = 0.0f;
	float maximumSpeed = 100.0f;

	bool speedBoost = false;

	// Use this for initialization
	void Start () {
	
		xpNeeded = playerLevel * 10.0f;
		
		Debug.Log ("You need " + xpNeeded + " XP!");

		xpCurrent = (xpCurrent + xpGained);
		
		if (xpNeeded = xpCurrent){

			LevelUp ();
			
		}


	}
	
	// Update is called once per frame
	void LevelUp () {
	
		float agilityValue = 1.0f;
		float stat2Value = 2.0f;
		float stat3Value = 3.0f;

		bool agilityBonus = false;
		bool stat2Bonus = false;
		bool stat3Bonus = false;
		bool noBonus = false;

		float randomRoll = 0.0f;
		float randomAgility = 0.0f;
		float randomStat2 = 0.0f;
		float randomStat3 = 0.0f;


		playerLevel = (playerLevel + 1.0f);

		randomRoll = (Random.Range (1, 10));	// This runs 1, 2, 3… 9 & 10. Floats are inclusive. Integers are exclusive. 

		if (randomRoll = 1 || 2 || 3) {

			if (randomAgility = Random.Range ((100.0f - agilityValue), agilityValue))
				agilityBonus = true;
		}
		
		else if (randomRoll = 4 || 5 || 6) {
			if (randomAgility = Random.Range ((100.0f - agilityValue), agilityValue))
				agilityBonus = true;
		}

		else if (randomRoll = 7 || 8 || 9) {
			if (randomAgility = Random.Range ((100.0f - agilityValue), agilityValue))
					agilityBonus = true;
		}
		
		else if (randomRoll == 10){
			noBonus = true;
		}


		if (agilityBonus == true) {
			Debug.Log (agility);
		}

		else if (stat2Bonus == true) {
			Debug.Log (stat2);
		}

		else if (stat3Bonus == true) {
			Debug.Log (stat3);
		}

		else {
			Debug.Log ("0");
		}

	}
}
