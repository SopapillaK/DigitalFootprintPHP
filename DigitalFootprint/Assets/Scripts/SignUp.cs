using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignUp : MonoBehaviour
{
    public GameObject signUpPanel;
    public GameObject instaPanel;
    public void SignUpButton()
    {
        signUpPanel.SetActive(false);
        instaPanel.SetActive(true);
    }
}
