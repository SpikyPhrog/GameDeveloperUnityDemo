using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Enum for the events that might occur and cause a sound to be played. If there are more sounds to be added a new event should be created as well, else you wont be able to play that sound
/// </summary>
public enum SoundEvents
{
    PlayerShoot,
    PlayerHurt,
    BombExplosion,
    DropSpawn
}

/// <summary>
/// Class responsible for the sounds
/// </summary>
public class SoundManager : MonoBehaviour
{
    //array of the sounds, settable in the inspector
    public SoundClip[] sounds;
    
    /// <summary>
    /// Public method that plays the sound effect corresponding to the event that has been passed as parameter and destorys the newly created object to free memory
    /// </summary>
    /// <param name="soundEvent"></param>
    public void PlaySound(SoundEvents soundEvent)
    {
        GameObject soundObject = new GameObject("Sound");
        AudioSource soundAudioSource = soundObject.AddComponent<AudioSource>();
        soundAudioSource.PlayOneShot(GetAudioClip(soundEvent));
        
        Destroy(soundObject, 3f);
    }
    
    /// <summary>
    /// Helper function that gets the event passed as parameter and maps a sound clip to it
    /// </summary>
    /// <param name="soundEvent"></param>
    /// <returns></returns>
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

/// <summary>
/// Custom class that helps associating audio clips with what event to be fired
/// </summary>
[System.Serializable]
public class SoundClip
{
    public SoundEvents soundEvent;
    public AudioClip audioClip;
}
