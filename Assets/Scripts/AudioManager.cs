using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource[] hitSounds;
    [SerializeField] AudioSource[] brokeSounds;
    [SerializeField] AudioSource[] bombSounds;
    [SerializeField] AudioSource[] coinSounds;
    [SerializeField] AudioSource[] obtainedSounds;

    public void PlayHit()
    {
        hitSounds[Random.Range(0, 3)].Play();
    }

    public void PlayBroke()
    {
        brokeSounds[Random.Range(0, 3)].Play();
    }

    public void PlayBomb()
    {
        bombSounds[Random.Range(0, 3)].Play();
    }

    public void PlayCoins()
    {
        coinSounds[Random.Range(0, 3)].Play();
    }

    public void PlayObtained()
    {
        obtainedSounds[Random.Range(0, 3)].Play();
    }
}
