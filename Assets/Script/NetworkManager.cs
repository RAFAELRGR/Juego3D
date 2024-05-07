using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;
using static System.Net.WebRequestMethods;

public class NetworkManager : MonoBehaviour
{
    public void CreateUser(string userName, string email, string password, int userRolId, Action<Response> response)
    {
        StartCoroutine(Co_CreateUser(userName, email, password, userRolId, response));
    }
    private IEnumerator Co_CreateUser(string userName, string email, string password, int userRolId, Action<Response> response)
    {
        string url = $"https://www.papalandia.somee.com/api/Users/Create?userName={userName}&email={email}&password={password}&userRolId={userRolId}";
        WWWForm form = new WWWForm();
        var download = UnityWebRequest.Post(url, form);
        yield return download.SendWebRequest();
    }
    public void LoginUser(string userName, string password, Action<Response> response)
    {
        StartCoroutine(Co_LoginUser(userName, password, response));
    }

    private IEnumerator Co_LoginUser(string userName, string password, Action<Response> response)
    {
        string url = $"https://www.papalandia.somee.com/api/Users";

        WWWForm form = new WWWForm();

        var download = UnityWebRequest.Get(url);

        yield return download.SendWebRequest();

        string respuesta = download.downloadHandler.text;

        Usuario user = JsonUtility.FromJson<Usuario>(respuesta);

    }

}

[Serializable]
public class Response
{
    public bool done = false;
    public string message = "";
}
[System.Serializable]
public class Usuario
{
    public string uname;
    public string upassword;
}