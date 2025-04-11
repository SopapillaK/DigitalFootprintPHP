using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInfo : MonoBehaviour
{
    public InputField cardNumber;
    public static string cardNumSave;

    public InputField expDate;
    public static string expDateSave;

    public InputField cvv;
    public static string cvvSave;

    public InputField postalCode;
    public static string postalCodeSave;

    void Start()
    {
        if (cardNumSave != null)
        {
            cardNumber.text = cardNumSave;
        }

        if (expDateSave != null)
        {
            expDate.text = expDateSave;
        }

        if (cvvSave != null)
        {
            cvv.text = cvvSave;
        }

        if (postalCodeSave != null)
        {
            postalCode.text = postalCodeSave;
        }
    }
}
