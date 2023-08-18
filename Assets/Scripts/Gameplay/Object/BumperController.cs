using UnityEngine;

public class BumperController : MonoBehaviour
{
	[SerializeField]
	private Collider ball;
	[SerializeField]
	private float multiplier, score;
	[SerializeField]
	private Color color;
	[SerializeField]
	private AudioManager audioManager;
	[SerializeField]
	private VFXManager vfxManager;
	[SerializeField]
	private ScoreManager scoreManager;

	//private Renderer renderer;
	private Animator animator;

	private void Start()
	{
		//renderer = GetComponent<Renderer>();
		animator = GetComponent<Animator>();

		GetComponent<Renderer>().material.color = color;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider == ball)
		{
			Rigidbody ballRig = ball.GetComponent<Rigidbody>();
			ballRig.velocity *= multiplier;

			animator.SetTrigger("hit");

			audioManager.PlaySFX(collision.transform.position);
			vfxManager.PlayBumperVFX(collision.transform.position);

			scoreManager.AddScore(score);
		}
	}
}
