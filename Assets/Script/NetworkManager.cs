using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour
{
    public void CreateUser(string userName, string email, string password, int userRolId, Action<Response> response)
    {
        StartCoroutine(Co_CreateUser(userName, email, password, userRolId, response));
    }
    private IEnumerator Co_CreateUser(string userName, string email, string password, int userRolId, Action<Response> response)
    {
        string url = $"http://www.papalandiagame.somee.com/api/Users/Create?userName={userName}&email={email}&password={password}&userRolId={userRolId}";
        WWWForm form = new WWWForm();
        var download = UnityWebRequest.Post(url, form);
        yield return download.SendWebRequest();
        if (download.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error en la solicitud: " + download.error);
            response(new Response { done = false, message = "Error en la solicitud: " + download.error });
            yield break;
        }
    }
    public void LoginUser(string userName, string password, Action<Response> response)
    {
        StartCoroutine(Co_LoginUser(userName, password, response));
    }

    private IEnumerator Co_LoginUser(string userName, string password, Action<Response> response)
    {
        string url = $"http://www.papalandiagame.somee.com/api/Users/Login?userName={userName}&password={password}";
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


        if (respuesta.ToLower().Contains("true"))
        {
            response(new Response { done = true, message = "Login exitoso" });
        }
        else
        {
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