using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;

namespace ST
{
    public class CharacterData : MonoBehaviour
    {
        string PlayerName = "";
        public TextMeshProUGUI Name;
        public ColorEvent GetHairColor;
        public ColorEvent GetSkinColor;
        public ColorEvent GetClothesColor;
        public ColorEvent GetEyesColor;
        public Color HairColor;
        public Color SkinColor;
        public Color ClothesColor;
        public Color EyesColor;

        // Start is called before the first frame update
        void Start()
        {
            PlayerName = PlayerPrefs.GetString("PlayerName");
            Name.text = PlayerName;
            ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString("HairColorString"), out HairColor);
            ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString("SkinColorString"), out SkinColor);
            ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString("ClothesColorString"), out ClothesColor);
            ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString("EyesColorString"), out EyesColor);
            GetHairColor?.Invoke(HairColor);
            GetSkinColor?.Invoke(SkinColor);
            GetClothesColor?.Invoke(ClothesColor);
            GetEyesColor?.Invoke(EyesColor);       
        }
    


    }
}
