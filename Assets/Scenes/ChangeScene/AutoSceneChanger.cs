using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using System.Text.RegularExpressions;

public class AutoSceneChanger : MonoBehaviour
{
    string allscenes;
    string curscene;
    string[] scenes = new string[10];
    // Start is called before the first frame update
    void Start()
    {
        string allpaths = Application.dataPath+ "/Scenes/AllScenes.txt";
        allscenes = File.ReadAllText(allpaths);
        string curpathscene = Application.dataPath + "/Saves/currentScene.txt";
        curscene = File.ReadAllText(curpathscene); ;
        Debug.Log(Application.dataPath);
    }
    private void ReadAll()
    {
        string pattern = "\n";
        string[] elements = Regex.Split(allscenes, pattern);
        int length = 0;
        string[] pathsarray = new string[10];
        foreach (string m in elements)
        {
            if (m != "")
            {
                pathsarray[length] = m;
                //Debug.Log(m);
                //Debug.Log(curscene);
                length++;
            }
        }
        for(int i = 0; i < length; i++)
        {
            //Debug.Log(pathsarray[i+1]);
            Debug.Log(curscene.Length);
            //Debug.Log((pathsarray[i] == curscene) + "2");
            pathsarray[i] = pathsarray[i].Substring(0,pathsarray[i].Length -1);
            Debug.Log(pathsarray[i].Length);
            if (pathsarray[i] == curscene) LoadScene(pathsarray[i + 1].Substring(0, pathsarray[i+1].Length - 1));
        }
    }
    private void LoadScene(string scenepath)
    {
        scenepath = scenepath.Replace("Assets/","");
        scenepath = scenepath.Replace(".unity", "");
        SceneManager.LoadScene(scenepath);
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "MainPlayer")
        {
            //Debug.Log("1");
            ReadAll();
        }
    }
}