using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using CurvedUI;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UserData : MonoBehaviour
{

    public static UserData instance;
    enum TextType
    { 
      nameType,
      mobileType
    }

    TextType textType;


    [SerializeField]
    GameObject namePlaceHolder;

    [SerializeField]
    TextMeshProUGUI nameText;

    [SerializeField]
    string nameString;

    [SerializeField]
    Button nextButton;

  

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        nameTextType();
    }

 


    #region User Data Related

    public void FillText(string data)
    {
        if (textType == TextType.nameType)
        {
            namePlaceHolder.SetActive(false);
            nameText.text += data;
            nameString = nameText.text;
            

            if (nameText.text.Length > 3)
                nextButton.interactable = true;

        }
    }


   public void removeString()
    {
        if (textType == TextType.nameType)
        {
            if (nameText.text.Length > 1)
            {
                nameText.text = nameText.text.Remove(nameText.text.Length - 1);
                nameString = nameText.text;
               

                if (nameText.text.Length == 0)
                    namePlaceHolder.SetActive(true);


                if (nameText.text.Length < 3)
                    nextButton.interactable = false;

            }
        }
        
    }

  

    public void Next()
    {
      nameString = nameString.Substring(1);
      PlayerPrefs.SetString("Name", nameString);
        Debug.Log(nameString);
       SceneManager.LoadScene(1);
    }

    public void nameTextType()
    {
        textType = TextType.nameType;
    }

   

    #endregion

   

}
