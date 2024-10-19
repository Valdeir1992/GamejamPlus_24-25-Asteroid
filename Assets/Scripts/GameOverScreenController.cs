using UnityEngine;
using UnityEngine.UI;

public class GameOverScreenController : MonoBehaviour
{
    [SerializeField] private Button _btnReset;
    [SerializeField] private Button _btnMenu;
    [SerializeField] private Button _btnExit;

    private void OnEnable()
    {
        _btnExit.onClick.AddListener(Exit);
        _btnMenu.onClick.AddListener(Menu);
        _btnReset.onClick.AddListener(ResetLevel);
    }
    private void OnDisable()
    {
        _btnExit.onClick.RemoveAllListeners();
        _btnMenu.onClick.RemoveAllListeners();
        _btnReset.onClick.RemoveAllListeners();
    }
    private void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }
    private void ResetLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
    private void Exit()
    {
        Application.Quit();
    }
}
