using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropdown;

    public bool optionsOn = false;
    public GameObject pauseMenu;
    public GameObject optionMenu;
    public bool mayShowMenu = true;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> Options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string Option = resolutions[i].width + "x" + resolutions[i].height;
            Options.Add(Option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(Options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauzeMenu();
        }
    
    }

    public void ToggleOptionMenu()
    {
        if (optionMenu.activeInHierarchy)
        {
            optionMenu.SetActive(false);
            pauseMenu.SetActive(true);
            optionsOn = false;
        }
        else
        {
            optionMenu.SetActive(true);
            pauseMenu.SetActive(false);
            optionsOn = true;
        }
    }

    public void TogglePauzeMenu()
    {
        if (!optionsOn)
        {
            if (pauseMenu.activeInHierarchy)
            {
                pauseMenu.SetActive(false);
            }
            else
            {
                pauseMenu.SetActive(true);
            }
        }
    }
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetQuality (int qualityIndex)
    {
        PlayerPrefs.SetInt("Quality", qualityIndex);
        QualitySettings.SetQualityLevel(qualityIndex, true);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Debug.Log ("Fullscreen");
        Screen.fullScreen = isFullscreen;
    }

    void GetSettingsAtStartAndSetThem()
    {
        if (!PlayerPrefs.HasKey("Quality"))
        {
            PlayerPrefs.SetInt("Quality", 1);
        }
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
    }
}
