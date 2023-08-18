using UnityEngine;

public class VFXManager : MonoBehaviour
{
	[SerializeField]
	private GameObject vfxBumperParticle;
	[SerializeField]
	private GameObject vfxSwitchOnParticle;
	[SerializeField]
	private GameObject vfxSwitchOffParticle;

	public void PlayBumperVFX(Vector3 spawnPosition)
	{
		InstantiateVFX(vfxBumperParticle, spawnPosition);
	}

	public void PlaySwitchVFX(Vector3 spawnPosition, float fxChoice)
	{
		GameObject _switchFXParticle = null;

		switch (fxChoice)
		{
			case 0:
				_switchFXParticle = vfxSwitchOffParticle;
				break;
			case 1:
				_switchFXParticle = vfxSwitchOnParticle;
				break;
		}
		InstantiateVFX(_switchFXParticle, spawnPosition);
	}

	private void InstantiateVFX(GameObject gameObject, Vector3 spawnPosition)
	{
		GameObject.Instantiate(gameObject, spawnPosition, Quaternion.identity);
	}
}
