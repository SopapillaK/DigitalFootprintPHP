using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using SimpleJSON;

public class PostManager : MonoBehaviour
{
    //public Text itemText;
    Action<string> _createPostsCallback;
    void Start()
    {
        _createPostsCallback = (jsonArrayString) => {
            StartCoroutine(CreatePostsRoutine(jsonArrayString));
        };

        CreatePosts();
    }

    public void CreatePosts()
    {
        string userId = Main.Instance.UserInfo.UserID;
        StartCoroutine(Main.Instance.Web.GetItemsIDs(userId, _createPostsCallback));
    }

    IEnumerator CreatePostsRoutine(string jsonArrayString)
    {
        //parsing json array string as an array
        JSONArray jsonArray = JSON.Parse(jsonArrayString) as JSONArray;

        for (int i = 0; i < jsonArray.Count; i++)
        {
            //Create local variables
            bool isDone = false; //are we done downloading
            string postId = jsonArray[i].AsObject["postID"];
            string id = jsonArray[i].AsObject["ID"];

            JSONObject postInfoJson = new JSONObject();

            //Create a callback to get the information from Web.cs
            Action<string> getPostInfoCallback = (postInfo) => {
                isDone = true;
                JSONArray tempArray = JSON.Parse(postInfo) as JSONArray;
                postInfoJson = tempArray[0].AsObject;
            };

            StartCoroutine(Main.Instance.Web.GetPost(postId, getPostInfoCallback));

            //Wait until the callback is called from WEB (info finsihed downloading)
            yield return new WaitUntil(() => isDone == true);

            //Instantiate Gameobject item prefab
            GameObject postGo = Instantiate(Resources.Load("Prefabs/Post") as GameObject);
            Post post = postGo.AddComponent<Post>();

            post.ID = id;
            post.PostID = postId;

            postGo.transform.SetParent(this.transform);
            postGo.transform.localScale = Vector3.one;
            postGo.transform.localPosition = Vector3.zero;

            //Fill Information
            postGo.transform.Find("Caption").GetComponent<Text>().text = postInfoJson["caption"];

            int PostVer = postInfoJson["PostVer"].AsInt;

            byte[] bytes = ImageManager.Instance.LoadImage(postId, PostVer);

            if (bytes.Length == 0)
            {
                //Create a callback to get the SPRITE from Web.cs
                Action<byte[]> getPostIconCallback = (downloadbyte) => {
                    Sprite sprite = ImageManager.Instance.BytestoSprite(downloadbyte);
                    postGo.transform.Find("PostImage").GetComponent<Image>().sprite = sprite;
                    ImageManager.Instance.SaveImage(postId, downloadbyte, PostVer);
                    ImageManager.Instance.SaveVersionJSON();
                };
                StartCoroutine(Main.Instance.Web.GetPostImg(postId, getPostIconCallback));
            }
            else
            {
                Sprite sprite = ImageManager.Instance.BytestoSprite(bytes);
                postGo.transform.Find("PostImage").GetComponent<Image>().sprite = sprite;
            }
            //continue to the next item

        }
    }
}
