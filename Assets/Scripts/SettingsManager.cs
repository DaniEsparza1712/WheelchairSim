using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Audio")]
    public AudioSource audioMixer;
    private float audioVolume;
    public Slider audioSlider;
    [Header("Texture")]
    public Slider textureSlider;
    [Header("Anti Aliasing")]
    public Slider aaSlider;
    private Camera mainCam;

    public void SetAudioVolume(){
        audioVolume = audioSlider.value;
        audioMixer.volume = audioVolume;
    }
    public void SetTextureQuality(){
        var textureQuality = textureSlider.value;
        QualitySettings.globalTextureMipmapLimit = (int)textureQuality;
    }
    public void SetAntiAlias(){
        var aaQuality = aaSlider.value;
        QualitySettings.antiAliasing = (int)aaQuality;
    }
}
