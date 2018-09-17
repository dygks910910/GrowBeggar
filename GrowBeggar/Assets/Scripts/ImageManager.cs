using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] allSprite;
    private int spriteIdx;
    public GameObject img;
    public GameObject ControllPictureButton;
    public GameObject CloseButton;
    public GameObject BasicWindowCanvas;
    public GameObject PrevButton;
    public GameObject InfomationText;

    void Start()
    {
        spriteIdx = 0;
        img = GameObject.Find("mainImage");
        ControllPictureButton = transform.parent.Find("ControllPictureButton").gameObject;
        CloseButton = transform.parent.Find("CloseButton").gameObject;
        BasicWindowCanvas = transform.parent.gameObject;
        PrevButton = ControllPictureButton.transform.Find("Prev").gameObject;
        InfomationText = transform.parent.Find("InfomationText").gameObject;

        PrevButton.SetActive(false);
        CloseButton.SetActive(false);

    }
    public void LoadSpritesForStoryCard(string folderName)
    {
        spriteIdx = 0;
        img = GameObject.Find("mainImage");
        ControllPictureButton = transform.parent.Find("ControllPictureButton").gameObject;
        CloseButton = transform.parent.Find("CloseButton").gameObject;
        BasicWindowCanvas = transform.parent.gameObject;
        PrevButton = ControllPictureButton.transform.Find("Prev").gameObject;
        InfomationText = transform.parent.Find("InfomationText").gameObject;

        PrevButton.SetActive(false);
        CloseButton.SetActive(false);

        allSprite = Resources.LoadAll<Sprite>(folderName);
        img.GetComponent<Image>().sprite = allSprite[spriteIdx];

    }
    public void NextImage()
    {
        spriteIdx++;
        //아직 보여줄 sprite가 남았다면?
        if (allSprite.Length > spriteIdx)
        {
            img.GetComponent<Image>().sprite = allSprite[spriteIdx];
            PrevButton.SetActive(true);
        }
        //마지막 sprite라면?
        if (allSprite.Length-1 == spriteIdx)
        {
                ControllPictureButton.SetActive(false);
                //버튼을 비활성화하고 close 버튼을 활성화.
                CloseButton.SetActive(true);
        }
    }
    public void DestroyThisCanvas()
    {
        Destroy(BasicWindowCanvas);
    }
    public void PreImage()
    {
        if(spriteIdx-- > 0)
        {
            img.GetComponent<Image>().sprite = allSprite[spriteIdx];
        }
        if(spriteIdx == 0)
        {
            PrevButton.SetActive(false);
        }
    }
    
}
