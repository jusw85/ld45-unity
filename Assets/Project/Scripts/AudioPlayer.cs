using MyBox;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip bgm;
    [Range(0.001f, 1.0f)][SerializeField] private float bgmVolume = 1.0f;

    private AudioSource source;
    private AudioMixer mixer;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        mixer = source.outputAudioMixerGroup.audioMixer;
        source.clip = bgm;
        source.Play();
    }

    private void Start()
    {
        mixer.SetFloat("BGM Volume", VolumeToDecibel(bgmVolume));
    }

    private float VolumeToDecibel(float linearVolume)
    {
        return Mathf.Log10(Mathf.Clamp(bgmVolume, 0.001f, 1.0f)) * 20;
    }
}