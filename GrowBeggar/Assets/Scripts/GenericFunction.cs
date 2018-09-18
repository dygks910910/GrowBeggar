using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenericFunction : MonoBehaviour {
    Text txt;
    // Use this for initialization
    void Start()
    {
        txt = GetComponent<Text>();
        //StartCoroutine("wait");
    }
    ulong tmpUlong=0;
    void Update()
    {
        txt.text = ulongMoneyToKoreanStr(tmpUlong++);
    }
    string ulongMoneyToKoreanStr(ulong a)
    {
        string lastUnit = "원";
        string[] unitArr = { "만", "억", "조", "경", "해" };

        string tmpString = "";
        string returnStr = "";
        //        1.입력받은 수를 문자열로 변환한다.
        string fullNumStr = a.ToString();

        //최대 단위 구하기.
        if (fullNumStr.Length > 4)
        {
            int highUnit = fullNumStr.Length / 4 - 1;
            int currUnitIdx = fullNumStr.Length % 4;
            //문자열 제일앞 단위자리 구하기.
            if (currUnitIdx > 0)
            {
                tmpString = fullNumStr.Substring(0, currUnitIdx);
                returnStr += tmpString + unitArr[highUnit];
            }
            for (int i = 1; i <= 2; ++i)
            {
                if (highUnit > 0)
                {
                    tmpString = fullNumStr.Substring(currUnitIdx + (4 * i), 4);
                    returnStr += tmpString + unitArr[--highUnit];
                }
                else
                {
                    tmpString = fullNumStr.Substring(currUnitIdx, 4);
                    returnStr += tmpString;
                    break;
                }
            }
        }
        else
        {
            return fullNumStr += lastUnit;
        }

        //마지막에 "원"삽입
        returnStr += lastUnit;
        return returnStr;
    }
    // Update is called once per frame
    ulong tmpFactor = 0;
    IEnumerator wait()
    {
        while (true)
        {
            tmpFactor += tmpFactor;
            txt.text = ulongMoneyToKoreanStr(tmpFactor);
            yield return new WaitForSeconds(0.5f);
        }

    }
}
