using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private List<AudioClip> inventoryOpenAudioSfx = new List<AudioClip>();

    [SerializeField] private List<AudioClip> inventoryCloseAudioSfx = new List<AudioClip>();

    [SerializeField] private List<AudioClip> addIngredientAudioSfx = new List<AudioClip>();

    [SerializeField] private List<AudioClip> popupAudioSfx = new List<AudioClip>();

    [SerializeField] private List<AudioClip> wrongPoionAudioSfx = new List<AudioClip>();

    [SerializeField] private List<AudioClip> correctPotionAudioSfx = new List<AudioClip>();

    [SerializeField] private AudioSource sfxAudioSource;

    [SerializeField] private AudioSource bgmAudioSource;

    [SerializeField] private Slider sfxSlider;

    [SerializeField] private Slider bgmSlider;

    private void Awake()
    {
        if (instance != this)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        sfxSlider.value = sfxAudioSource.volume;
        bgmSlider.value = bgmAudioSource.volume;
    }

    private void OnEnable()
    {
        sfxSlider.onValueChanged.AddListener(SetSfxAudioVolume);
        bgmSlider.onValueChanged.AddListener(SetBgmAudioVolume);
    }

    private void OnDisable()
    {
        sfxSlider.onValueChanged.RemoveListener(SetSfxAudioVolume);
        bgmSlider.onValueChanged.RemoveListener(SetBgmAudioVolume);
    }

    public void SetSfxAudioVolume(float value)
    {
        sfxAudioSource.volume = value;
    }

    public void SetBgmAudioVolume(float value)
    {
        bgmAudioSource.volume = value;
    }

    public void PlayInventoryOpenSfx()
    {
        sfxAudioSource.PlayOneShot(inventoryOpenAudioSfx[Random.Range(0, inventoryOpenAudioSfx.Count)]);
    }

    public void PlayInventoryCloseSfx()
    {
        sfxAudioSource.PlayOneShot(inventoryCloseAudioSfx[Random.Range(0, inventoryCloseAudioSfx.Count)]);
    }

    public void PlayAddingIngredientSfx()
    {
        sfxAudioSource.PlayOneShot(addIngredientAudioSfx[Random.Range(0, addIngredientAudioSfx.Count)]);
    }

    public void PlayPopupSfx()
    {
        sfxAudioSource.PlayOneShot(popupAudioSfx[Random.Range(0, popupAudioSfx.Count)]);
    }

    public void PlayCorrectPotionSfx()
    {
        sfxAudioSource.PlayOneShot(correctPotionAudioSfx[Random.Range(0, correctPotionAudioSfx.Count)]);
    }

    public void PlayWrongPotionSfx()
    {
        sfxAudioSource.PlayOneShot(wrongPoionAudioSfx[Random.Range(0, wrongPoionAudioSfx.Count)]);
    }
}
