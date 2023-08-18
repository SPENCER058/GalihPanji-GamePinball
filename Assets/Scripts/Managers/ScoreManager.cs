using UnityEngine;

public class ScoreManager : MonoBehaviour
{
	[SerializeField]
	private float score = 0;

	private void Start ()
	{
		ResetScore();	
	}

	public void AddScore (float addition)
	{
		score += addition;
	}

	public void ResetScore ()
	{
		score = 0;
	}

	public float GetScore ()
	{
		return score;
	}
}
