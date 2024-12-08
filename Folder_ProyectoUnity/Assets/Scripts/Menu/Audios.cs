using UnityEngine;
using UnityEngine.UI;

public class Audios : MonoBehaviour
{
    public AudioMixerSO general;
    public AudioMixerSO musica;
    public AudioMixerSO efectos;

    public Slider sliderGeneral;
    public Slider sliderMusica;
    public Slider sliderEfectos;

    private void Awake()
    {
        sliderEfectos.value= efectos.GetCurrentVolumeValue();
        sliderGeneral.value= general.GetCurrentVolumeValue();    
        sliderMusica.value= musica.GetCurrentVolumeValue(); 
    }

}
