using UnityEngine;

public class ScoreUIController : MonoBehaviour
{
	[SerializeField]
	private TMPro.TextMeshProUGUI scoreText;
	[SerializeField]
	private ScoreManager scoreManager;

	private void Update ()
	{
		scoreText.text = scoreManager.GetScore().ToString();	
	}
}
