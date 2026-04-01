using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isMenuOpen = false;
        menu.SetActive(false);

        isAugmentListOpen = false;
        augmentList.SetActive(false);

        isSettingOpen = false;
        setting.SetActive(false);
        menuObject.SetActive(true);
    }

    bool isAugmentListOpen = false;
    bool isMenuOpen = false;
    bool isSettingOpen = false;
    public GameObject menu;
    public GameObject augmentList;

    public GameObject setting;
    public GameObject menuObject;

    void Update()
    {
        if (!isMenuOpen && Input.GetButtonDown("Cancel"))
        {
            isMenuOpen = true;
            menu.SetActive(true);
            Time.timeScale = 0;
        }

        if (!isAugmentListOpen && Input.GetButtonDown("AugmentList"))
        {
            isAugmentListOpen = true;
            augmentList.SetActive(true);
            Time.timeScale = 0;
        }
        else if(isAugmentListOpen && Input.GetButtonDown("AugmentList"))
        {
            isAugmentListOpen = false;
            augmentList.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ContinueGame()
    {
        isMenuOpen = false;
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Setting()
    {
        if(isSettingOpen)
        {
            isSettingOpen = false;
            setting.SetActive(false);
            menuObject.SetActive(true);
        }
        else
        {
            isSettingOpen = true;
            setting.SetActive(true);
            menuObject.SetActive(false);
        }
    }
    public void ExitGame()
    {
        Debug.Log("게임 종료가 성공적으로 실행됨.");
        Application.Quit();
    }
}
