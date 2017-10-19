using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuImageChange : MonoBehaviour
{

    public Image BGimage;      //Source for the background image

    public void GolfImage()   //Change background to the Golf background
    {
        {
            BGimage.sprite = Resources.Load<Sprite>("GOLF");
        }
    }
    public void ToyImage()   //Change background to the Toy background
    {
        {
            BGimage.sprite = Resources.Load<Sprite>("TOY");
        }
    }
    public void DiscoImage()   //Change background to the Disco background
    {
        {
            BGimage.sprite = Resources.Load<Sprite>("DISCO");
        }
    }
    public void CityImage()   //Change background to the City background
    {
        {
            BGimage.sprite = Resources.Load<Sprite>("CITY");
        }
    }
}
