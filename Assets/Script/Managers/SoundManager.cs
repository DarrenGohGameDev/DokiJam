using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private List<AudioClip> iventoryOpenAudioSfx = new List<AudioClip>();

    [SerializeField] private List<AudioClip> iventoryCloseAudioSfx = new List<AudioClip>();

    [SerializeField] private List<AudioClip> addIngredientAudioSfx = new List<AudioClip>();

    [SerializeField] private List<AudioClip> popupAudioSfx = new List<AudioClip>();

    [SerializeField] private AudioSource sfxAudioSource;

    [SerializeField] private AudioSource bgmAudioSource;

    private void Awake()
    {
        if (instance != this)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSfxAudioVolume()
    {

    }

    public void SetBgmAudioVolume()
    {

    }

    public void PlayIventoryOpenSfx()
    {
        sfxAudioSource.PlayOneShot(iventoryOpenAudioSfx[Random.Range(0, iventoryOpenAudioSfx.Count)]);
    }

    public void PlayIventoryCloseSfx()
    {
        sfxAudioSource.PlayOneShot(iventoryCloseAudioSfx[Random.Range(0, iventoryCloseAudioSfx.Count)]);
    }

    public void PlayAddingIngredientSfx()
    {
        sfxAudioSource.PlayOneShot(addIngredientAudioSfx[Random.Range(0, addIngredientAudioSfx.Count)]);
    }

    public void PlayPopupSfx()
    {
        sfxAudioSource.PlayOneShot(popupAudioSfx[Random.Range(0, popupAudioSfx.Count)]);
    }
}
