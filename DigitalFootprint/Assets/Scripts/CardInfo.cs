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
        cardNumSave = cardNumber.text;
        expDateSave = expDate.text;
        cvvSave = cvv.text;
        postalCodeSave = postalCode.text;
        /*
        if (cardNumSave != null)
        {
            //cardNumber.text = cardNumSave;
            cardNumSave = cardNumber.text;
        }

        if (expDateSave != null)
        {
            //expDate.text = expDateSave;
            expDateSave = expDate.text;
        }

        if (cvvSave != null)
        {
            //cvv.text = cvvSave;
            cvvSave = cvv.text;
        }

        if (postalCodeSave != null)
        {
            //postalCode.text = postalCodeSave;
            postalCodeSave = postalCode.text;
        }*/

        cardNumber.text = PlayerPrefs.GetString("CardNumber", cardNumSave);
        expDate.text = PlayerPrefs.GetString("ExpDate", expDateSave);
        cvv.text = PlayerPrefs.GetString("CVV", cvvSave);
        postalCode.text = PlayerPrefs.GetString("PostalCode", postalCodeSave);
    }

    // Call this to save:
    public void SaveCardInfo()
    {
        PlayerPrefs.SetString("CardNumber", cardNumber.text);
        PlayerPrefs.SetString("ExpDate", expDate.text);
        PlayerPrefs.SetString("CVV", cvv.text);
        PlayerPrefs.SetString("PostalCode", postalCode.text);
        PlayerPrefs.Save();
    }

    /*
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
    }*/
}
