using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Slider audioSlider;

    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;

    public bool optionsOn = false;
    public GameObject pauseMenu;
    public GameObject optionMenu;
    public bool mayShowMenu = true;
    public int sceneIndex;

    public bool toggleMouse;

    Resolution[] resolutions;

    public GameObject playerCam;

    private void Start()
    {
        GetAndSetResolution();
        GetVolume();
        GetSettingsAtStartAndSetThem();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauzeMenu();
            MouseLock();
        }
    
    }
    public void MouseLock()
    {
        if (toggleMouse == false)
        {
            Cursor.lockState = CursorLockMode.None;
            playerCam.GetComponent<Cams>().inMenu = false;
            toggleMouse = true;
            return;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            playerCam.GetComponent<Cams>().inMenu = true;
            toggleMouse = false;
            return;
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

            MouseLock();
        }
    }

#region Resolutionstuff

    public void GetAndSetResolution()
    {
        int currentResolutionIndex = 0;
        if (PlayerPrefs.HasKey("ResolutionIndex"))
        {
            currentResolutionIndex = PlayerPrefs.GetInt("ResolutionIndex");
        }
        else
        {
            currentResolutionIndex = 2;
        }
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();


        List<string> Options = new List<string>();


        for (int i = 0; i < resolutions.Length; i++)
        {
            string Option = resolutions[i].width + "x" + resolutions[i].height;
            Options.Add(Option);
        }

        resolutionDropdown.AddOptions(Options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        Screen.SetResolution(resolutions[currentResolutionIndex].width, resolutions[currentResolutionIndex].height, true);
    }
    public void SetResolution (int resolutionIndex)
    {
        print(resolutionIndex);
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
        Screen.SetResolution(resolutions[resolutionIndex].width,
                             resolutions[resolutionIndex].height,
                             Screen.fullScreen);
        resolutionDropdown.value = resolutionIndex;
    }

    public void GetResolution()
    {
        if (PlayerPrefs.HasKey("ResolutionIndex"))
        {
            SetResolution(PlayerPrefs.GetInt("ResolutionIndex"));
        }
        else
        {
            SetResolution(0);
        }
    }

    #endregion

    #region Audio settings
    public void SetVolume (float volume)
    {
        PlayerPrefs.SetFloat("MasterVolume", volume);
        audioMixer.SetFloat("MasterVolume", volume);
        audioSlider.value = volume;
    }

    public void GetVolume()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            SetVolume(PlayerPrefs.GetFloat("MasterVolume"));
        }
        else
        {
            SetVolume(0.5f);
        }
    }
    #endregion

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
        qualityDropdown.value = PlayerPrefs.GetInt("Quality");

    }

    public void SceneSwitch()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void Quit()
    {
        Application.Quit();
        print("Quit");
    }
}
