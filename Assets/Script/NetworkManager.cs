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
        string url = $"https://www.papalandia.somee.com/api/Users/Login?userName={userName}&password={password}";
        WWWForm form = new WWWForm();

        var download = UnityWebRequest.Post(url, form);

        yield return download.SendWebRequest();

        if (download.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error en la solicitud: " + download.error);
            response(new Response { done = false, message = "Error en la solicitud: " + download.error });
            yield break;
        }

        string respuesta = download.downloadHandler.text;

        // Verifica la respuesta del servidor
        if (respuesta.ToLower().Contains("true"))
        {
            // Login exitoso
            response(new Response { done = true, message = "Login exitoso" });
        }
        else
        {
            // Login fallido
            response(new Response { done = false, message = "Credenciales incorrectas" });
        }
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