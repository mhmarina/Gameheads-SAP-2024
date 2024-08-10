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
                float currentVol = GameAudioManager.instance.musicSource.volume;
                Debug.Log(currentVol);
                Debug.Log("Voice line playing");
                GameAudioManager.instance.musicSource.volume = 0.1f;
                caller.StartCoroutine(ResetVolumeAfterVoiceLine(voiceLine.length, currentVol));
            }
        }
    }

    private IEnumerator ResetVolumeAfterVoiceLine(float delay, float currentVol)
    {
        yield return new WaitForSeconds(delay);
        if (GameAudioManager.instance != null)
        {
            GameAudioManager.instance.musicSource.volume = currentVol;
        }
    }
}
