using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroupA;
    [SerializeField] private CanvasGroup canvasGroupB;
    [SerializeField] private Button gameOverButton;

    public enum GameUIMode
    {
        Init,
        TurnA,
        TurnB,
        GameOver
    }
    
    private const float DisableAlpha = 0.5f;
    private const float EnableAlpha = 1f;

    public void SetGameUIMode(GameUIMode mode)
    {
        switch (mode)
        {
            case GameUIMode.Init:
                canvasGroupA.gameObject.SetActive(true);
                canvasGroupB.gameObject.SetActive(true);
                gameOverButton.gameObject.SetActive(false);
                
                canvasGroupA.alpha = DisableAlpha;
                canvasGroupB.alpha = DisableAlpha;
                break;
            case GameUIMode.TurnA:
                canvasGroupA.gameObject.SetActive(true);
                canvasGroupB.gameObject.SetActive(true);
                gameOverButton.gameObject.SetActive(false);
                
                canvasGroupA.alpha = EnableAlpha;
                canvasGroupB.alpha = DisableAlpha;
                break;
            case GameUIMode.TurnB:
                canvasGroupA.gameObject.SetActive(true);
                canvasGroupB.gameObject.SetActive(true);
                gameOverButton.gameObject.SetActive(false);
                
                canvasGroupA.alpha = DisableAlpha;
                canvasGroupB.alpha = EnableAlpha;
                break;
            case GameUIMode.GameOver:
                canvasGroupA.gameObject.SetActive(false);
                canvasGroupB.gameObject.SetActive(false);
                gameOverButton.gameObject.SetActive(true);
                break;
        }
    }

    public void OnClickGameOverButton()
    {
        GameManager.Instance.OpenConfirmPanel("게임을 종료하시겠습니까?", () =>
        {
            GameManager.Instance.ChangeToMainScene();
        });
    }

    public void OnClickSettingsButton() 
    {
        GameManager.Instance.OpenSettingsPanel();
    }

    public void OnClickBackButton()
    {
        GameManager.Instance.OpenConfirmPanel("게임을 종료하시겠습니까?", () =>
        {
            GameManager.Instance.ChangeToMainScene();
        });
    }
}
