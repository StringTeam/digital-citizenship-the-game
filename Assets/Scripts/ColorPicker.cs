using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;

//Color picker for character creation

namespace ST
{
[Serializable]
public class ColorEvent : UnityEvent<Color> { }

    public class ColorPicker : MonoBehaviour
    {
        //Variables for the Colorpicker

        //Using Unity Events system to place the colors with
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

        //Starting method
        void Start()
        {
            Rect = GetComponent<RectTransform>(); //To get the Rect transform component of the object

            ColorTexture = GetComponent<Image>().mainTexture as Texture2D; //Getting the image component and setting it as the texture
            PlayerPrefs.SetInt("setColors", 0); // Boolean to make sure player has picked all the colors before creating the character
        }

        void Update()
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(Rect, Input.mousePosition)) //To check that the mouse pointer is inside the Color picker image
            {
                Vector2 delta; //Vector2 variable for saving the pixel coordinates
                RectTransformUtility.ScreenPointToLocalPointInRectangle(Rect, Input.mousePosition, null, out delta); //To save the pixel coordinates where the mouse cursor is into the delta variable

                float width = Rect.rect.width;                      //Taking the width of the rectangle and saving it into a variable
                float height = Rect.rect.height;                    //Taking the height of the retangle and saving it into a variable

                //Doing some math to get a more precise location of the pixels color
                delta += new Vector2(width * .5f, height * .5f);    

                float x = Mathf.Clamp(delta.x / width, 0f, 1f);
                float y = Mathf.Clamp(delta.y / height, 0f, 1f);
 

                int texX = Mathf.RoundToInt(x * ColorTexture.width);
                int texY = Mathf.RoundToInt(y * ColorTexture.height);


                Color color = ColorTexture.GetPixel(texX, texY); //Saving the color from the pixel coordinates to a color variable

                //Checking which button has been pressed by the Player from the Colors variable
                if (Colors == 1)
                {
                    OnColorPreviewHair?.Invoke(color); //Uses the variable in the event
                    if (Input.GetMouseButtonDown(0))
                    {
                        OnColorSelectHair?.Invoke(color);
                        Color HairColor = color;
                        HairColorString = ColorUtility.ToHtmlStringRGB(HairColor); //Saves the color into a string variable from a color variable
                        PlayerPrefs.SetString("HairColorString", ColorUtility.ToHtmlStringRGB(HairColor)); //Saves the color string into a playerpref string, so that it can be loaded from the playerprefs
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

                if(setEyesColor && setClothesColor && setSkinColor && setHairColor) //When all colors has been selected, then this is true
                {
                    PlayerPrefs.SetInt("setColors", 1);
                }

            }
        }

        public void HairColorButtonDown() //Checks which body part button has been pressed
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
