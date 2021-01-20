using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public float music = 1f;
    public Slider musicSlider;
    //public Text Musicperc = null;

    public float sfx = 1f;
    public Slider sfxSlider;
    //public Text SFXperc = null; 
    
    public void ChangeMusic()
    {
        music = musicSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", music);
    }

    public void ChangeSfx()
    {
        sfx = sfxSlider.value;
        PlayerPrefs.SetFloat("SfxVolume", sfx);
    }
    
    //public void MusicText()
    //{
    //    music = 100 * music;
    //    Musicperc.text = Mathf.RoundToInt(music) + "%";
    //}
    //
    //public void SFXText()
    //{
    //    sfx = 100 * sfx;
    //    SFXperc.text = Mathf.RoundToInt(sfx) + "%";
    //}


    private void Awake()
    {
        music = PlayerPrefs.GetFloat("MusicVolume", 1f);
        musicSlider.value = music;

        sfx = PlayerPrefs.GetFloat("SfxVolume", 1f);
        sfxSlider.value = sfx;
    }

    void Update()
    {
        ChangeMusic();
        ChangeSfx();
        AudioManager.instance.ChangeVolume("temp", musicSlider);
    }
}