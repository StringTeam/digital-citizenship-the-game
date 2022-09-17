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

        void Start()
        {
            Rect = GetComponent<RectTransform>();

            ColorTexture = GetComponent<Image>().mainTexture as Texture2D;
        }

        void Update()
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(Rect, Input.mousePosition))
            {
                Vector2 delta;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, Input.mousePosition, null, out delta);

                string debug = "mousePosition=" + Input.mousePosition;
                debug += "<br>delta=" + delta;

                float width = Rect.rect.width;
                float height = Rect.rect.height;
                delta += new Vector2(width * .5f, height * .5f);
                debug += "<br>offset delta=" + delta;

                float x = Mathf.Clamp(delta.x / width, 0f, 1f);
                float y = Mathf.Clamp(delta.y / height, 0f, 1f);
                debug += "<br>x=" + x + "y=" + y;

                int texX = Mathf.RoundToInt(x * ColorTexture.width);
                int texY = Mathf.RoundToInt(y * ColorTexture.height);
                debug += "<br>texX=" + texX + "texY=" + texY;
                debug += "<br>color=" + Colors;

                Color color = ColorTexture.GetPixel(texX, texY);

                DebugText.color = color;
                DebugText.text = debug;

                if (Colors == 1)
                {
                    OnColorPreviewHair?.Invoke(color);
                    if (Input.GetMouseButtonDown(0))
                    {
                        OnColorSelectHair?.Invoke(color);
                        Color HairColor = color;
                        HairColorString = ColorUtility.ToHtmlStringRGB(HairColor);
                        PlayerPrefs.SetString("HairColorString", ColorUtility.ToHtmlStringRGB(HairColor));
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
                        Colors = 0;
                    }
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
