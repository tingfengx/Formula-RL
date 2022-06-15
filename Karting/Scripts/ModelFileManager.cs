using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEditor;
using TMPro;

public class ModelFileManager : MonoBehaviour
{

    public int id;
    public static string[] paths = new string[2];

    public TextMeshProUGUI Textfield;
    string curPath;

    public void OpenFileExplorer()
    {
        curPath = EditorUtility.OpenFilePanel("Select your model","", "onnx");
        if(String.IsNullOrEmpty(curPath))
            return;
        
        StartCoroutine(GetName());
    }

    public IEnumerator GetName()
    {

        yield return new WaitForSeconds(0);

        Textfield.text = curPath;

        paths[id] = curPath;
    }

    public static string[] GetPaths()
    {
        return paths;
    }
}
