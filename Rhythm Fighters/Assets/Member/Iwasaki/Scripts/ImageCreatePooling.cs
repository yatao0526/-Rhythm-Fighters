using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageCreatePooling : MonoBehaviour
{
    private List<Image> noteImagePoolL;
    private List<Image> noteImagePoolR;
    private Image noteUI;
    [SerializeField]
    private Canvas imageParent;

    public void CreatePoolL(Image img, int maxCount)
    {
        noteUI = img;
        noteImagePoolL = new List<Image>();
        for(int i = 0; i < maxCount; i++)
        {
            var newImg = CreateNewImageL();
            newImg.gameObject.SetActive(false);
            noteImagePoolL.Add(newImg);
        }
    }
    public Image GetGameImageL()
    {
        foreach(var img in noteImagePoolL)
        {
            if(img.gameObject.activeSelf == false)
            {
                img.gameObject.SetActive(true);
                return img;
            }
        }
        var newImg = CreateNewImageL();
        gameObject.SetActive(true);
        noteImagePoolL.Add(newImg);
        return newImg;
    }
    private Image CreateNewImageL()
    {
        var newImg = Instantiate(noteUI);
        newImg.name = noteUI.name + (noteImagePoolL.Count + 1);
        newImg.transform.SetParent(imageParent.transform, false);
        return newImg;
    }

    public void CreatePoolR(Image img, int maxCount)
    {
        noteUI = img;
        noteImagePoolR = new List<Image>();
        for (int i = 0; i < maxCount; i++)
        {
            var newImg = CreateNewImageR();
            newImg.gameObject.SetActive(false);
            noteImagePoolR.Add(newImg);
        }
    }
    public Image GetGameImageR()
    {
        foreach (var img in noteImagePoolL)
        {
            if (img.gameObject.activeSelf == false)
            {
                img.gameObject.SetActive(true);
                return img;
            }
        }
        var newImg = CreateNewImageR();
        gameObject.SetActive(true);
        noteImagePoolL.Add(newImg);
        return newImg;
    }
    private Image CreateNewImageR()
    {
        var newImg = Instantiate(noteUI);
        newImg.name = noteUI.name + (noteImagePoolR.Count + 1);
        newImg.transform.SetParent(imageParent.transform);
        return newImg;
    }
}
