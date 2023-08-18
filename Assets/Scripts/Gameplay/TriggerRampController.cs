using UnityEngine;

public class TriggerRampController : MonoBehaviour
{
	[SerializeField]
	private float score;

	[SerializeField]
	private Collider ball;
	[SerializeField]
	private ScoreManager scoreManager;

	private void OnTriggerEnter(Collider other)
	{
		if (other == ball)
		{
			scoreManager.AddScore(score);
		}
	}

}
