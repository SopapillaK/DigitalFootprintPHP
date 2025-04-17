using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Web : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject itemBoughtIcon;

    public IEnumerator GetItemIcon(string itemID, System.Action<byte[]> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("itemID", itemID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/DigitalFootprint/GetItemIcon.php", form))
        {
            yield return www.Send();

            //Check for errors
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("www.error");
            }
            else
            {
                Debug.Log("DOWNLOADING ICON: " + itemID);
                byte[] bytes = www.downloadHandler.data;
                callback(bytes);
            }
        }
    }

    public IEnumerator GetPostImg(string postID, System.Action<byte[]> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("postID", postID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/DigitalFootprint/GetPostImg.php", form))
        {
            yield return www.Send();

            //Check for errors
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("www.error");
            }
            else
            {
                Debug.Log("DOWNLOADING POST: " + postID);
                byte[] bytes = www.downloadHandler.data;
                callback(bytes);
            }
        }
    }

    public IEnumerator GetUsers(string userID, System.Action<string> callback)
    {
        Debug.Log(userID);
        WWWForm form = new WWWForm();
        form.AddField("userID", "1");

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/DigitalFootprint/GetUsers.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("www.error");
            }
            else
            {
                //Show results as text
                Debug.Log(www.downloadHandler.text);

                //or retrieve results as binary data
                byte[] results = www.downloadHandler.data;

                string jsonArray = www.downloadHandler.text;
                //Call callback function to pass results
                callback(jsonArray);
            }
        }
    }

    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/DigitalFootprint/Login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                Main.Instance.UserInfo.SetCredentials(username, password);
                Main.Instance.UserInfo.SetID(www.downloadHandler.text);

                if(www.downloadHandler.text.Contains("Wrong Credentials.")|| www.downloadHandler.text.Contains("Username does not exist"))
                    {
                    Debug.Log("Try Again");
                }
                else
                {
                    //If we logged in correctly
                    Main.Instance.UserProfile.SetActive(true);
                    Main.Instance.Login.gameObject.SetActive(false);
                }
            }
        }
    }

    public IEnumerator RegisterUser(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/DigitalFootprint/RegisterUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }

    public IEnumerator GetItemsIDs(string userID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", userID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/DigitalFootprint/GetItemsID.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("www.error");
            }
            else
            {
                //Show results as text
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;

                //Call callback function to pass results
                callback(jsonArray);
            }
        }
    }

    public IEnumerator GetItem(string itemID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("itemID", itemID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/DigitalFootprint/GetItem.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("www.error");
            }
            else
            {
                //Show results as text
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;

                //Call callback function to pass results
                callback(jsonArray);
            }
        }
    }

    public IEnumerator GetPost(string postID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("itemID", postID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/DigitalFootprint/GetPost.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("www.error");
            }
            else
            {
                //Show results as text
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;

                //Call callback function to pass results
                callback(jsonArray);
            }
        }
    }

    public IEnumerator BuyItem(string ID, string itemID, string userID)
    {
        WWWForm form = new WWWForm();
        form.AddField("ID", ID);
        form.AddField("itemID", itemID);
        form.AddField("userID", userID);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/digitalfootprint/BuyItem.php", form))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("www.error");
            }
            else
            {
                //Show results as text
                Debug.Log(www.downloadHandler.text);
                //Put here a txt that shows that the item was bought
                itemBoughtIcon.SetActive(true);

            }
        }
    }
}

