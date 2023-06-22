using UnityEngine;

public class MainSoundCon : MonoBehaviour
{
    AudioSource _heroSound;
    AudioClip _heroEffectClip;
    AudioClip _minianEffectClip;
    void Init()
    {
        if (_heroSound != null) return;
        _heroEffectClip = Resources.Load<AudioClip>("Sounde/SwordSoundPack/SWORD_01");
        _minianEffectClip = Resources.Load<AudioClip>("Sounde/SwordSoundPack/SWORD_10");
        _heroSound = GameObject.Find("HeroSound").AddComponent<AudioSource>() ;
    }
    public void HeroEffectSound()
    {
        Init();
        _heroSound.clip = _heroEffectClip;
        _heroSound .Play();
    }
    public void MinianEffectSound(AudioSource test)
    {
        Init();
        test.clip = _minianEffectClip;
        test.Play();
    }
}
