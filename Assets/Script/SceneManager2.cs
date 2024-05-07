using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager2 : MonoBehaviour
{

    [SerializeField] private InputField m_loginPasswordInput = null;
    [SerializeField] private InputField m_loginUserNameInput = null;

    [SerializeField] private GameObject m_registerUI = null;
    [SerializeField] private GameObject m_loginUI = null;
    [SerializeField] private Text m_text = null;
    [SerializeField] private InputField m_userNameInput = null;
    [SerializeField] private InputField m_passwordInput = null;
    [SerializeField] private InputField m_emailInput = null;
    [SerializeField] private InputField m_reEnterPassword = null;
    [SerializeField] private int m_UserRolId = 1;

    private NetworkManager m_networkManager = null;

    private void Awake()
    {
        m_networkManager = GameObject.FindObjectOfType<NetworkManager>();
    }

    public void SubmitLogin()
    {
        if (m_loginUserNameInput.text == "" || m_loginPasswordInput.text == "" )
        {
            m_text.text = "Por favor llena todos los campos requeridos";
            return;
        }

        m_text.text = " Procesando";

        m_networkManager.LoginUser(m_loginUserNameInput.text, m_loginPasswordInput.text, delegate (Response response)
        {
            m_text.text = response.message;
        });
    }

    public void SubmitRegister()
    {
        if(m_userNameInput.text  == "" ||  m_passwordInput.text == "" || m_emailInput.text == "" || m_reEnterPassword.text == "")
        {
            m_text.text = "Por favor llena todos los campos requeridos";
            return;
        }

        if(m_passwordInput.text  == m_reEnterPassword.text)
        {
            m_text.text = " Procesando";

            m_networkManager.CreateUser(m_userNameInput.text, m_emailInput.text, m_passwordInput.text, m_UserRolId, delegate(Response response)
            {
                m_text.text = response.message;
            });
        }
        else
        {
            m_text.text = "Contraseñas no son iguales, Por favor verificar";
        }
    }

    public void ShowLogin()
    {
        m_registerUI.SetActive(false);
        m_loginUI.SetActive(true);
    }

    public void ShowRegister()
    {
        m_registerUI.SetActive(true);
        m_loginUI.SetActive(false);
    }

}
