using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class PopupPanelController : Singleton<PopupPanelController>
{
    [SerializeField] private TMP_Text contentText;
    [SerializeField] private Button confirmButton;
    [SerializeField] private TMP_Text confirmButtonText;
    
    [SerializeField] private RectTransform panelRectTransform;

    private CanvasGroup _canvasGroup;
    
    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        Hide(false);
    }

    public void Show(string content, string confirmButtonText, bool animation, Action confirmAction)
    {
        gameObject.SetActive(true);
        
        // 애니메이션을 위한 초기화
        _canvasGroup.alpha = 0;
        panelRectTransform.localScale = Vector3.zero;

        if (animation)
        {
            panelRectTransform.DOScale(1f, 0.2f);
            _canvasGroup.DOFade(1f, 0.2f).SetEase(Ease.OutBack);
        }
        else
        {
            panelRectTransform.localScale = Vector3.one;
            _canvasGroup.alpha = 1f;
        }
        
        contentText.text = content;
        this.confirmButtonText.text = confirmButtonText;
        confirmButton.onClick.AddListener(() =>
        {
            confirmAction();
            Hide(true);
        });
    }

    public void Hide(bool animation)
    {
        if (animation)
        {
            panelRectTransform.DOScale(0f, 0.2f).OnComplete(() =>
            {
                contentText.text = "";
                this.confirmButtonText.text = "";
                confirmButton.onClick.RemoveAllListeners();
        
                gameObject.SetActive(false);
            });
            _canvasGroup.DOFade(0f, 0.2f).SetEase(Ease.InBack);
        }
        else
        {
            contentText.text = "";
            this.confirmButtonText.text = "";
            confirmButton.onClick.RemoveAllListeners();

            gameObject.SetActive(false);
        }
    }

    protected override void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
    }
}
