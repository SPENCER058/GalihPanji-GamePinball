using UnityEngine;

public class BallController : MonoBehaviour
{
	[SerializeField]
	private float maxSpeed;

	private Rigidbody rig;

	private void Start()
	{
		rig = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (rig.velocity.magnitude > maxSpeed)
		{
			rig.velocity = rig.velocity.normalized * maxSpeed;
		}
	}
}
