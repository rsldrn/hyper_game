using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("SFX Clips")]
    public AudioClip shootClip;

    [Header("Settings")]
    [SerializeField] private AudioSource sfxSource;

    private void Awake()
    {
        // Singleton design pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    
    public void PlayShoot(float volume = 1f)
    {
        if (shootClip == null) return;
        sfxSource.PlayOneShot(shootClip, volume);
    }
}












// public class AudioManager : MonoBehaviour
// {
//     public static AudioManager Instance { get; private set; }
//
//     [Header("SFX Clips")]
//     public AudioClip shootClip; 
//
//     [Header("Settings")]
//     [SerializeField] private int poolSize = 5; // Aynı anda calabilecek kaynak sayisi
//     [SerializeField] private float shootCooldown = 0.05f; // Saniye cinsinden cooldown
//     [SerializeField] private float defaultVolume = 1f;
//
//     private AudioSource[] sfxPool;
//     private int currentIndex = 0;
//     private float lastShootTime;
//
//     private void Awake()
//     {
//         // Singleton kurulumu
//         if (Instance != null && Instance != this)
//         {
//             Destroy(gameObject);
//             return;
//         }
//         Instance = this;
//         DontDestroyOnLoad(gameObject);
//
//         // AudioSource pool olusturma
//         sfxPool = new AudioSource[poolSize];
//         for (int i = 0; i < poolSize; i++)
//         {
//             AudioSource src = gameObject.AddComponent<AudioSource>();
//             src.playOnAwake = false;
//             src.loop = false;
//             src.spatialBlend = 0f; // 0 = 2D ses
//             sfxPool[i] = src;
//         }
//     }
//     public void PlayShoot(float volume = -1f)
//     {
//         if (shootClip == null) return;
//
//         // Cooldown kontrolu
//         if (Time.time - lastShootTime < shootCooldown) return;
//         lastShootTime = Time.time;
//
//         // Ses calma (pool sistemi)
//         if (volume < 0) volume = defaultVolume;
//         sfxPool[currentIndex].PlayOneShot(shootClip, volume);
//         currentIndex = (currentIndex + 1) % poolSize;
//     }
// }
