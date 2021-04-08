using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundEvents
{
    PlayerShoot,
    PlayerHurt,
    BombExplosion,
    DropSpawn
}

public class SoundManager : MonoBehaviour
{
    public SoundClip[] sounds;
    
    
    public void PlaySound(SoundEvents soundEvent)
    {
        GameObject soundObject = new GameObject("Sound");
        AudioSource soundAudioSource = soundObject.AddComponent<AudioSource>();
        soundAudioSource.PlayOneShot(GetAudioClip(soundEvent));
        
        Destroy(soundObject, 3f);
    }

    AudioClip GetAudioClip(SoundEvents soundEvent)
    {
        foreach (SoundClip soundClip in sounds)
        {
            if (soundClip.soundEvent == soundEvent)
            {
                return soundClip.audioClip;
            }
        }
        Debug.LogError("Sound" + soundEvent + "not found");
        return null;
    }

}

[System.Serializable]
public class SoundClip
{
    public SoundEvents soundEvent;
    public AudioClip audioClip;
}
