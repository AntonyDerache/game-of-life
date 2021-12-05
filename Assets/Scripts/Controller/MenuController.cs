using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GridManager _gameData;
    [SerializeField] private TMP_InputField _widthInput;
    [SerializeField] private TMP_InputField _heightInput;
    [SerializeField] private GameObject _errorMessage;

    public void Start() {
        _widthInput.text = _gameData.width.ToString();
        _heightInput.text = _gameData.height.ToString();
    }

    public void Play()
    {
        int width;
        int height;

        if (!int.TryParse(_widthInput.text, out width) || !int.TryParse(_heightInput.text, out height)) {
            _errorMessage.SetActive(true);
            return;
        }
        if (width < 10 || height < 10 || width > 300 || height > 300) {
            _errorMessage.SetActive(true);
            return;
        }
        if (_errorMessage.activeSelf) {
            _errorMessage.SetActive(false);
        }
        _gameData.width = width;
        _gameData.height = height;
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
