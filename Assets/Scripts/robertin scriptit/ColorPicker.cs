using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;


namespace ST
{
[Serializable]
public class ColorEvent : UnityEvent<Color> { }

    public class ColorPicker : MonoBehaviour
    {
        public TextMeshProUGUI DebugText;
        public ColorEvent OnColorPreviewHair;
        public ColorEvent OnColorPreviewSkin;
        public ColorEvent OnColorPreviewClothes;
        public ColorEvent OnColorPreviewEyes;
        public ColorEvent OnColorSelectHair;
        public ColorEvent OnColorSelectSkin;
        public ColorEvent OnColorSelectClothes;
        public ColorEvent OnColorSelectEyes;
        RectTransform Rect;
        Texture2D ColorTexture;
        public string HairColorString { get; set; }
        public string SkinColorString { get; set; }
        public string ClothesColorString { get; set; }
        public string EyesColorString { get; set; }
        public int Colors { get; set; }
        public bool setHairColor = false;
        public bool setSkinColor = false;
        public bool setClothesColor = false;
        public bool setEyesColor = false;
        public int setColors { get; set; }


        void Start()
        {
            Rect = GetComponent<RectTransform>();

            ColorTexture = GetComponent<Image>().mainTexture as Texture2D;
            PlayerPrefs.SetInt("setColors", 0);
        }

        void Update()
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(Rect, Input.mousePosition))
            {
                Vector2 delta;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, Input.mousePosition, null, out delta);

                float width = Rect.rect.width;
                float height = Rect.rect.height;
                delta += new Vector2(width * .5f, height * .5f);

                float x = Mathf.Clamp(delta.x / width, 0f, 1f);
                float y = Mathf.Clamp(delta.y / height, 0f, 1f);
 

                int texX = Mathf.RoundToInt(x * ColorTexture.width);
                int texY = Mathf.RoundToInt(y * ColorTexture.height);


                Color color = ColorTexture.GetPixel(texX, texY);


                if (Colors == 1)
                {
                    OnColorPreviewHair?.Invoke(color);
                    if (Input.GetMouseButtonDown(0))
                    {
                        OnColorSelectHair?.Invoke(color);
                        Color HairColor = color;
                        HairColorString = ColorUtility.ToHtmlStringRGB(HairColor);
                        PlayerPrefs.SetString("HairColorString", ColorUtility.ToHtmlStringRGB(HairColor));
                        setHairColor = true;
                        Colors = 0;
                    }
                }
                else if (Colors == 2)
                {
                    OnColorPreviewSkin?.Invoke(color);
                    if (Input.GetMouseButtonDown(0))
                    {
                        OnColorSelectSkin?.Invoke(color);
                        Color SkinColor = color;
                        SkinColorString = ColorUtility.ToHtmlStringRGB(SkinColor);
                        PlayerPrefs.SetString("SkinColorString", ColorUtility.ToHtmlStringRGB(SkinColor));
                        setSkinColor = true;
                        Colors = 0;
                    }
                }
                else if (Colors == 3)
                {
                    OnColorPreviewClothes?.Invoke(color);
                    if (Input.GetMouseButtonDown(0))
                    {
                        OnColorSelectClothes?.Invoke(color);
                        Color ClothesColor = color;
                        ClothesColorString = ColorUtility.ToHtmlStringRGB(ClothesColor);
                        PlayerPrefs.SetString("ClothesColorString", ColorUtility.ToHtmlStringRGB(ClothesColor));
                        setClothesColor = true;
                        Colors = 0;
                    }
                }
                else if (Colors == 4)
                {
                    OnColorPreviewEyes?.Invoke(color);
                    if (Input.GetMouseButtonDown(0))
                    {
                        OnColorSelectEyes?.Invoke(color);
                        Color EyesColor = color;
                        EyesColorString = ColorUtility.ToHtmlStringRGB(EyesColor);
                        PlayerPrefs.SetString("EyesColorString", ColorUtility.ToHtmlStringRGB(EyesColor));
                        setEyesColor = true;
                        Colors = 0;
                    }
                }

                if(setEyesColor && setClothesColor && setSkinColor && setHairColor)
                {
                    PlayerPrefs.SetInt("setColors", 1);
                }

            }
        }

        public void HairColorButtonDown()
        {
            Colors = 1;
        }

        public void SkinColorButtonDown()
        {
            Colors = 2;
        }

        public void ClothesButtonDown()
        {
            Colors = 3;
        }

        public void EyesButtonDown()
        {
            Colors = 4;
        }
    }
}
