using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class RemoveDuplicates : MonoBehaviour
{
    [Tooltip("要去出重复的文本")]
    public TextAsset text;

    string outPath;//文本输出路劲
    string resourseText;
    List<string> outText;//去重复后的字符串

    private void Awake()
    {
        outPath = Application.dataPath + "/_Text/Result";
        outText = new List<string>();
    }

    private void Start()
    {
        resourseText = text.ToString();
        for (int i = 0; i < resourseText.Length; i++)
        {
            outText.Add(resourseText[i].ToString());
        }

        WriteToText(RemoveRepeating(resourseText));
    }

    List<string> RemoveRepeating(string str)
    {
        for (int i = 0; i < outText.Count; i++)  //外循环是循环的次数
        {
            for (int j = outText.Count - 1; j > i; j--)  //内循环是 外循环一次比较的次数
            {

                if (outText[i] == outText[j])
                {
                    outText.RemoveAt(j);
                }

            }
        }

        return outText;
    }

    void WriteToText(List<string> list)
    {
        StreamWriter sw = new StreamWriter(outPath + "/result.txt");
        foreach (var item in list)
        {
            sw.Write(item);
        }
	//测试上d传
        sw.Close();
    }
}
