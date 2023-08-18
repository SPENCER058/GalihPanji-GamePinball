using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[SerializeField]
	private AudioSource bgmAudioSource;
	[SerializeField]
	private GameObject sfxAudioSource;
	[SerializeField]
	private GameObject switchOnAudioSource;
	[SerializeField]
	private GameObject switchOffAudioSource;

	private void Start()
	{
		PlayBGM();
	}

	private void PlayBGM()
	{
		bgmAudioSource.Play();
	}

	public void PlaySFX(Vector3 spawnPosition)
	{
		GameObject.Instantiate(sfxAudioSource, spawnPosition, Quaternion.identity);
	}

	public void PlaySwitchSFX(Vector3 spawnPosition, float sfxChoice)
	{
		GameObject _switchAudioSource = null;

		switch (sfxChoice)
		{
			case 0:
				_switchAudioSource = switchOffAudioSource;
				break;
			case 1:
				_switchAudioSource = switchOnAudioSource;
				break;
		}

		GameObject.Instantiate(_switchAudioSource, spawnPosition, Quaternion.identity);
	}
}
