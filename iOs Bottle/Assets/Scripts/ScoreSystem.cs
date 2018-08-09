using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class ScoreSystem : MonoBehaviour 
{
	private int scorePoint = 0; 
	public Text scoreText;
	public Text bestScore; 

	// Use this for initialization
	void Start () 
	{
		//..Int converstion into a string
		scoreText.text = scorePoint.ToString (); 
		bestScore.text = "Best:" +  bestScore.ToString (); 

		//Next we restart the game these will apply.
		bestScore.text = "Best:" + PlayerPrefs.GetInt("BestScore", 0).ToString();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void savingScore()
	{
		scorePoint = scorePoint + 1;
		scoreText.text = scorePoint.ToString ();
		if (scorePoint > PlayerPrefs.GetInt ("BestScore", 0))
		{
			PlayerPrefs.SetInt ("BestScore", scorePoint);

			//Setting score to BestScore
			bestScore.text = "Best: " + scorePoint.ToString();
		}
	}
	public void resettingScore()
	{
		PlayerPrefs.DeleteKey("BestScore");

		//Back to zero.. 
		bestScore.text = "Best: " + scorePoint.ToString();
	}
}
