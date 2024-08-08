using System.Collections;
using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string line;
    public AudioClip voiceLine;
    public Sprite charSprite;

    public void playVoiceLine(AudioSource audioSource, MonoBehaviour caller)
    {
        if (voiceLine)
        {
            audioSource.Stop();
            audioSource.PlayOneShot(voiceLine);
            if (GameAudioManager.instance != null)
            {
                Debug.Log("Voice line playing");
                GameAudioManager.instance.musicSource.volume = 0.25f;
                caller.StartCoroutine(ResetVolumeAfterVoiceLine(voiceLine.length));
            }
        }
    }

    private IEnumerator ResetVolumeAfterVoiceLine(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (GameAudioManager.instance != null)
        {
            GameAudioManager.instance.musicSource.volume = 1f;
        }
    }
}
