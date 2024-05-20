using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SocialPlatforms.Impl;

public class AchievementPost : MonoBehaviour
{
    public void CreateAchievemnt(string AchievementUnlocked, int AchievementId, int GameId, Action<Response> response)
    {
        StartCoroutine(Co_CreateAchievement(AchievementUnlocked, AchievementId, GameId, response));
    }
    private IEnumerator Co_CreateAchievement(string AchievementUnlocked, int AchievementId, int GameId, Action<Response> response)
    {
        string url = $"https://papalandiagame.somee.com/api/GamesAchievements?AchievementUnlocked={AchievementUnlocked}&AchievementId={AchievementId}&GameId={GameId}";
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

}