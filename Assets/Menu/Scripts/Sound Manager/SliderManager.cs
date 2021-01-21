using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public float master = 1f;
    [SerializeField] Slider masterSlider;
    
    public float music = 1f;
    [SerializeField] Slider musicSlider;

    public float sfx = 1f;
    [SerializeField] Slider sfxSlider;

    public void ChangeMaster()
    {
        master = masterSlider.value;
        PlayerPrefs.SetFloat("MasterVolume", master);
    }

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
        master = PlayerPrefs.GetFloat("MasterVolume", 1f);
        masterSlider.value = master;

        music = PlayerPrefs.GetFloat("MusicVolume", 1f);
        musicSlider.value = music;

        sfx = PlayerPrefs.GetFloat("SfxVolume", 1f);
        sfxSlider.value = sfx;
    }

    void Update()
    {
        ChangeMaster();
        ChangeMusic();
        ChangeSfx();
        
        AudioManager.instance.ChangeVolume("temp", PlayerPrefs.GetFloat("MusicVolume"), PlayerPrefs.GetFloat("MasterVolume"));
    }
}