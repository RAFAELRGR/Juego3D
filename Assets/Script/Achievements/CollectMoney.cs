using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectMoney : MonoBehaviour
{
    public string AchievementUnlocked = null;
    public int AchievementId = 3;
    public int GameId = 1;
    public GameObject AchivementManager;
    public Text TextAchievement = null;

    public AchievementPost AchievementPost;

    public void Update()
    {
        AchievementUnlocked = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }

    public void SendPost()
    {
        TextAchievement.text = "El tesoro de Tatooine";

        AchievementPost.CreateAchievemnt(AchievementUnlocked, AchievementId, GameId, delegate (Response response)
        {
        });

        AchivementManager.SetActive(true);
        StartCoroutine(ActivateAndDeactivate());
    }

    private IEnumerator ActivateAndDeactivate()
    {
        yield return new WaitForSeconds(10);

        AchivementManager.SetActive(false);
    }

}
