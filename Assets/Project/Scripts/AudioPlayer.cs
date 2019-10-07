using ScriptableObjectArchitecture;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip bgm;
    [Range(0.001f, 1.0f)] [SerializeField] private float bgmVolume = 1.0f;
    
    [SerializeField] private AudioClip hitSfx;
    [SerializeField] private AudioClip enemyDieSfx;

    private AudioSource source1;
    private AudioSource source2;
    private AudioMixer mixer;

    private void Awake()
    {
        source1 = GetComponents<AudioSource>()[0];
        source2 = GetComponents<AudioSource>()[1];
        mixer = source1.outputAudioMixerGroup.audioMixer;
        source1.clip = bgm;
        source1.Play();
    }

    private void Start()
    {
        mixer.SetFloat("BGM Volume", VolumeToDecibel(bgmVolume));
    }

    private float VolumeToDecibel(float linearVolume)
    {
        return Mathf.Log10(Mathf.Clamp(bgmVolume, 0.001f, 1.0f)) * 20;
    }

    public void PlayHit()
    {
        source2.PlayOneShot(hitSfx);
    }
    
    public void PlayEnemyDie()
    {
        source2.PlayOneShot(enemyDieSfx);
    }
}