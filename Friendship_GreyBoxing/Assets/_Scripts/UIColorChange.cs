using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIColorChange : MonoBehaviour
{
    public Image Image;
    public Color ImageColorToBeUsed = Color.white;
    public Color milkColor;
    public Color starCandy2Color;

    public Image AppleImage;
    public Image MilkImage;
    public Image BlueberriesImage;
    public Image flourImage;
    public Image carrotsImage;
    public Image starCandyImage;
    public Image starCandy2Image;
    public Image starCandy3Image;

    static public bool apple;
    static public bool milk;
    static public bool blueberries;
    static public bool flour;
    static public bool carrots;
    static public bool starCandy;
    static public bool starCandy2;
    static public bool starCandy3;

    private void Start()
    {
        apple = false;
        milk = false;
        blueberries = false;
        flour = false;
        carrots = false;
        starCandy = false;
        starCandy2 = false;
        starCandy3 = false;
    }

    private void Update()
    {
        UIColorChanger();
    }

    public void UIColorChanger()
    {
        if (apple == true)
        {
            Image = AppleImage.GetComponent<Image>();
            Image.color = ImageColorToBeUsed;
        }

        if (milk == true)
        {
            Image = MilkImage.GetComponent<Image>();
            Image.color = milkColor;
        }
        if (blueberries == true)
        {
            Image = BlueberriesImage.GetComponent<Image>();
            Image.color = ImageColorToBeUsed;
        }
        if (flour == true)
        {
            Image = flourImage.GetComponent<Image>();
            Image.color = ImageColorToBeUsed;
        }
        if (carrots == true)
        {
            Image = carrotsImage.GetComponent<Image>();
            Image.color = ImageColorToBeUsed;
        }
        if (starCandy == true)
        {
            Image = starCandyImage.GetComponent<Image>();
            Image.color = ImageColorToBeUsed;
        }
        if (starCandy2 == true)
        {
            Image = starCandy2Image.GetComponent<Image>();
            Image.color = starCandy2Color;
        }
        if (starCandy3 == true)
        {
            Image = starCandy3Image.GetComponent<Image>();
            Image.color = ImageColorToBeUsed;
        }
    }
}