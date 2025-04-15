using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using SimpleJSON;

public class UserInfoManager : MonoBehaviour
{
    Action<string> _getInfoCallback;
    void Start()
    {
        _getInfoCallback = (jsonArrayString) => {
            StartCoroutine(GetInfoRoutine(jsonArrayString));
        };

        GetInformation();
    }

    public void GetInformation()
    {
        string userId = Main.Instance.UserInfo.UserID;
        //Debug.Log("UserID: " + userId);
        StartCoroutine(Main.Instance.Web.GetUsers(userId, _getInfoCallback));
    }

    IEnumerator GetInfoRoutine(string jsonArrayString)
    {
        //parsing json array string as an array
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;

        for (int i = 0; i < jsonArray.Count; i++)
        {
            //Create local variables
            bool isDone = false; //are we done downloading
            string userId = jsonArray[i].AsObject["userID"];
            string id = jsonArray[i].AsObject["ID"];

            JSONObject userInfoJson = new JSONObject();

            //Create a callback to get the information from Web.cs
            Action<string> getUsersInfoCallback = (userInfo) => {
                isDone = true;
                JSONArray tempArray = JSON.Parse(userInfo) as JSONArray;
                userInfoJson = tempArray[0].AsObject;
            };
            Debug.Log("UserID: " + userId);
            StartCoroutine(Main.Instance.Web.GetUsers(userId, getUsersInfoCallback));

            //Wait until the callback is called from WEB (info finsihed downloading)
            yield return new WaitUntil(() => isDone == true);

            //Instantiate Gameobject item prefab
            GameObject userGo = Instantiate(Resources.Load("Prefabs/UserInfo") as GameObject);
            UsersInformation user = userGo.AddComponent<UsersInformation>();

            user.ID = id;
            user.UserID = userId;

            userGo.transform.SetParent(this.transform);
            userGo.transform.localScale = Vector3.one;
            userGo.transform.localPosition = Vector3.zero;

            //Fill Information
            userGo.transform.Find("Username").GetComponent<Text>().text = userInfoJson["username"];
            userGo.transform.Find("Money").GetComponent<Text>().text = userInfoJson["money"];
            //continue to the next item

        }
    }
}
