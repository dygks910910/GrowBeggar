using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour {
    static GameObject canvas;

    public void CreatePictureCard(string path)
    {
         canvas = Instantiate(Resources.Load("prefabs/StoryCardForm")) as GameObject;
        Destroy(canvas.transform.Find("ControllPictureButton").gameObject);


        //메인 이미지를 찾아서 sprite삽입.
        canvas.transform.Find("PictureWindow").Find("mainImage").GetComponent<Image>().sprite = Resources.Load<Sprite>(path);
        //화면 전체에 보이지 않는 버튼을 생성하여 터치하면 끝내기.
        canvas.transform.Find("invisibleFullScreenButton").gameObject.SetActive(true);
        GameObject infoText = canvas.transform.Find("InfomationText").gameObject;
        infoText.SetActive(false);
    }
    public void CreatePictureTextCard(string path)
    {
         canvas = Instantiate(Resources.Load("prefabs/StoryCardForm")) as GameObject;
        Destroy(canvas.transform.Find("ControllPictureButton").gameObject);
        //메인 이미지를 찾아서 sprite삽입.
        canvas.transform.Find("PictureWindow").Find("mainImage").GetComponent<Image>().sprite = Resources.Load<Sprite>(path);
        //화면 전체에 보이지 않는 버튼을 생성하여 터치하면 끝내기.
        canvas.transform.Find("invisibleFullScreenButton").gameObject.SetActive(true);
        canvas.transform.Find("CloseButton").gameObject.SetActive(false);
    }
    public void SetText(string text)
    {
        GameObject infoText = canvas.transform.Find("InfomationText").gameObject;
        infoText.GetComponent<Text>().text = text;
    }
    public void CreateStoryCard(string folderPath)
    {
         canvas = Instantiate(Resources.Load("prefabs/StoryCardForm")) as GameObject;

        //메인 이미지를 찾아서 sprite삽입.
        canvas.transform.Find("ImageCtr").GetComponent<ImageManager>().LoadSpritesForStoryCard(folderPath);
        //화면 전체에 보이지 않는 버튼을 생성하여 터치하면 끝내기.
        canvas.transform.Find("invisibleFullScreenButton").gameObject.SetActive(false);
        GameObject infoText =  canvas.transform.Find("InfomationText").gameObject;
        infoText.SetActive(false);
    }
}
