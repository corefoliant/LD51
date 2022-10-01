using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public int _effectsAudioSourcesAmount = 3;
    [Space]
    public float _globalVolume = 1f;
    public float _musicVolume = 0.2f;
    public float _effectsVolume = 0.5f;
    [Space]
    // Music swapping time, in sec.
    public float _musicTrackChangeSpeed = 0.5f;

    private List<AudioSource> _audioSources_effects = new List<AudioSource>();

    private AudioSource _audioSource_music_1;
    private AudioSource _audioSource_music_2;
    private AudioClip _currentMusicTrack;

    private IEnumerator _swappingCoroutine;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject);

        InitPlayerPrefs();
        InitMusicSources();
        InitEffectsSources();
    }

    private void InitPlayerPrefs()
    {
        _globalVolume = (PlayerPrefs.HasKey("GLOBAL_VOLUME"))
            ? PlayerPrefs.GetFloat("GLOBAL_VOLUME") : _globalVolume;
        _effectsVolume = (PlayerPrefs.HasKey("EFFECTS_VOLUME"))
            ? PlayerPrefs.GetFloat("EFFECTS_VOLUME") : _effectsVolume;
        _musicVolume = (PlayerPrefs.HasKey("MUSIC_VOLUME"))
            ? PlayerPrefs.GetFloat("MUSIC_VOLUME") : _effectsVolume;
    }

    private void InitMusicSources()
    {
        _audioSource_music_1 = gameObject.AddComponent<AudioSource>();
        _audioSource_music_1.playOnAwake = false;
        _audioSource_music_1.volume = _globalVolume;
        _audioSource_music_1.loop = true;

        _audioSource_music_2 = gameObject.AddComponent<AudioSource>();
        _audioSource_music_2.playOnAwake = false;
        _audioSource_music_2.volume = _globalVolume;
        _audioSource_music_2.loop = true;

        _audioSource_music_1.volume = 0f;
        _audioSource_music_2.volume = 0f;
    }

    private void InitEffectsSources()
    {
        for (int i = 0; i < _effectsAudioSourcesAmount; i++)
        {
            _audioSources_effects.Add(gameObject.AddComponent<AudioSource>());
        }
        ChangeEffectsVolume(_effectsVolume);
    }

    public static void GetVolume(out float Global, out float Music, out float Effects)
    {
        Global = instance._globalVolume;
        Music = instance._musicVolume;
        Effects = instance._effectsVolume;
    }

    public static void ChangeGlobalVolume(float newVolume)
    {
        instance._globalVolume = newVolume;
        
        PlayerPrefs.SetFloat("GLOBAL_VOLUME", newVolume);
        PlayerPrefs.Save();
    }

    public static void ChangeMusicVolume(float newVolume)
    {
        instance._musicVolume = newVolume;
        instance._audioSource_music_1.volume = instance._musicVolume * instance._globalVolume;
        instance._audioSource_music_2.volume = instance._musicVolume * instance._globalVolume;
        
        PlayerPrefs.SetFloat("MUSIC_VOLUME", newVolume);
        PlayerPrefs.Save();
    }

    public static void ChangeEffectsVolume(float newVolume)
    {
        instance._effectsVolume = newVolume;
        foreach (AudioSource aso in instance._audioSources_effects)
        {
            aso.volume = instance._effectsVolume * instance._globalVolume;
        }

        PlayerPrefs.SetFloat("EFFECTS_VOLUME", newVolume);
        PlayerPrefs.Save();
    }

    public static void StopMusic()
    {
        instance.StopAllCoroutines();
        instance._audioSource_music_1.Stop();
        instance._audioSource_music_2.Stop();
        instance._currentMusicTrack = null;
    }

    public static void ChangeMusic(AudioClip clip, float speed = 1f, bool forced = false)
    {
        if (instance._currentMusicTrack != clip || forced)
        {
            if (instance._swappingCoroutine != null)
                instance.StopCoroutine(instance._swappingCoroutine);
            instance.StartCoroutine(instance._swappingCoroutine = instance.SwapTrack(clip, (speed == 1f) ? instance._musicTrackChangeSpeed : speed));
        }
    }
    public static void PlaySound(AudioClip clip)
    {
        PlayLocal(clip);
    }

    private static void PlayLocal(AudioClip clip)
    {
        for (int i = 0; i < instance._audioSources_effects.Count; i++)
        {
            if (instance._audioSources_effects[i].isPlaying)
                continue;
            instance._audioSources_effects[i].clip = clip;
            instance._audioSources_effects[i].Play();
            return;
        }

        int rand = Random.Range(0, instance._audioSources_effects.Count);
        instance._audioSources_effects[rand].clip = clip;
        instance._audioSources_effects[rand].Play();
    }

    private IEnumerator SwapTrack(AudioClip toClip, float timeToFade = 0.25f)
    {
        if (toClip)
        {
            float elapsedTime = 0;
            instance._currentMusicTrack = toClip;

            if (_audioSource_music_1.isPlaying)
            {
                _audioSource_music_2.clip = toClip;
                _audioSource_music_2.volume = 0;
                _audioSource_music_2.Play();

                while (elapsedTime < timeToFade)
                {
                    _audioSource_music_2.volume = Mathf.Lerp(0, _globalVolume, elapsedTime / timeToFade);
                    _audioSource_music_1.volume = Mathf.Lerp(_globalVolume, 0, elapsedTime / timeToFade);
                    elapsedTime += Time.fixedUnscaledDeltaTime;
                    yield return new WaitForEndOfFrame();
                }

                _audioSource_music_1.Stop();
            }
            else
            {
                _audioSource_music_1.clip = toClip;
                _audioSource_music_1.volume = 0;
                _audioSource_music_1.Play();

                while (elapsedTime < timeToFade)
                {
                    _audioSource_music_1.volume = Mathf.Lerp(0, _globalVolume, elapsedTime / timeToFade);
                    _audioSource_music_2.volume = Mathf.Lerp(_globalVolume, 0, elapsedTime / timeToFade);
                    elapsedTime += Time.fixedUnscaledDeltaTime;
                    yield return new WaitForEndOfFrame();
                }

                _audioSource_music_2.Stop();
            }
        }
        else
        {
            yield return null;
        }
    }
}
