using System.Collections;
using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string line;
    public AudioClip voiceLine;
    public Sprite charSprite;
    private bool isCoroutineRunning = false;

    public void playVoiceLine(AudioSource audioSource, MonoBehaviour caller)
    {
        if (voiceLine)
        {
            if (isCoroutineRunning)
            {
                caller.StopCoroutine("ResetVolumeAfterVoiceLine");
                isCoroutineRunning = false;
            }

            AudioSource musicSrc = GameAudioManager.instance.musicSource;
            AudioSource playerSrc = GameAudioManager.instance.playerSource;
            AudioSource sfxSrc = GameAudioManager.instance.sfxSource;

            float currentMusicVol = GameAudioManager.instance.musicVol;
            float currentSFXVol = GameAudioManager.instance.sfxVol;
            float currentPlayerVol = GameAudioManager.instance.playerVol;
            Debug.Log($"Original volumes - Music: {currentMusicVol}, SFX: {currentSFXVol}, Player: {currentPlayerVol}");

            Debug.Log("Lowering voiceline volumes...");
            musicSrc.volume = 0.1f;
            playerSrc.volume = 0.05f;
            sfxSrc.volume = 0f;

            audioSource.Stop();
            audioSource.volume = 1.0f;
            audioSource.PlayOneShot(voiceLine);

            caller.StartCoroutine(ResetVolumeAfterVoiceLine(
                voiceLine.length, 
                currentMusicVol, musicSrc,
                currentSFXVol, sfxSrc,
                currentPlayerVol, playerSrc
                ));
        }
    }

    private IEnumerator ResetVolumeAfterVoiceLine(
        float delay, 
        float musicVol, AudioSource musicSrc, 
        float sfxVol, AudioSource sfxSrc, 
        float playerVol, AudioSource playerSrc
        )
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(delay);
        if (GameAudioManager.instance != null)
        {
            musicSrc.volume = musicVol;
            sfxSrc.volume = sfxVol;
            playerSrc.volume = playerVol;
            Debug.Log($"Volumes reset!: music: {musicVol}, sfx: {sfxVol}, player: {playerVol}");
        }
        isCoroutineRunning = false;
    }
}
