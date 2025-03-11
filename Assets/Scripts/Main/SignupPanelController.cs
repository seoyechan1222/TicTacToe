using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public struct SignupData
{
    public string username;
    public string nickname;
    public string password;
}

public class SignupPanelController : MonoBehaviour
{
    [SerializeField] private TMP_InputField _usernameInputField;
    [SerializeField] private TMP_InputField _nicknameInputField;
    [SerializeField] private TMP_InputField _passwordInputField;
    [SerializeField] private TMP_InputField _confirmPasswordInputField;
    
    public void OnClickConfirmButton()
    {
        var username = _usernameInputField.text;
        var nickname = _nicknameInputField.text;
        var password = _passwordInputField.text;
        var confirmPassword = _confirmPasswordInputField.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(nickname) ||
            string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
        {
            GameManager.Instance.OpenConfirmPanel("입력 내용이 누락되었습니다.", () =>
            {
                
            });
            return;
        }

        if (password.Equals(confirmPassword))
        {
            SignupData signupData = new SignupData();
            signupData.username = username;
            signupData.nickname = nickname;
            signupData.password = password;
            
            // 서버로 SignupData 전달하면서 회원가입 진행
            StartCoroutine(NetworkManage.Instance.Signup(signupData, () =>
            {
                Destroy(gameObject);
            }, () =>
            {
                _usernameInputField.text = "";
                _nicknameInputField.text = "";
                _passwordInputField.text = "";
                _confirmPasswordInputField.text = "";
            }));
        }
        else
        {
            GameManager.Instance.OpenConfirmPanel("비밀번호가 서로 다릅니다.", () =>
            {
                _passwordInputField.text = "";
                _confirmPasswordInputField.text = "";
            });
        }
    }

    public void OnClickCancelButton()
    {
        Debug.Log("OnClickCancelButton");
        Destroy(gameObject);
    }
}
