using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    [SerializeField]private Button btnPlayGame;

    private void OnEnable() {
        btnPlayGame.onClick.AddListener(OnClickButtonPlayGame);
    }

    private void OnClickButtonPlayGame()
    {
        GameManager.instance.LoadScene("Game");
    }
}
