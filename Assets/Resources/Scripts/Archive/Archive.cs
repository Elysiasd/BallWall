using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
/// <summary>
/// 存档相关
/// </summary>
public static class Archive
{
    private static string filePath => Application.dataPath + @"GameData.txt";
    private static Dictionary<string, string> data;
    /// <summary>
    /// 根据传入的键从<see cref="data"/>获取相应的值
    /// </summary>
    /// <returns>是个string，请自行转换谢谢喵</returns>
    /// <exception cref="System.Exception"/>
    public static string GetData(string key)
    {
        if (data.ContainsKey(key)) return data[key];
        else throw new System.Exception($"未找到{key}，请检查存档或键");
    }
    /// <summary>
    /// 根据传入的键向<see cref="data"/>写入相应的值
    /// </summary>
    public static void SetData(string key, string value)
    {
        if (data.ContainsKey(key)) data[key] = value;
        else data.Add(key, value);
    }
    /// <summary>
    /// 将当前<see cref="data"/>中的内容写入存档
    /// <br>一般来说，只需要在游戏结束时调用</br>
    /// </summary>
    public static void Save()
    {
        using (StreamWriter sw = new StreamWriter(filePath, false))
        {
            foreach (KeyValuePair<string, string> kvp in data)
            {
                sw.WriteLine(kvp.Key + " " + kvp.Value);
            }
            sw.Flush();
            sw.Close();
        }
    }
    /// <summary>
    /// 将当前存档中的内容读入<see cref="data"/>
    /// <br>一般来说，只需要在游戏结束时调用</br>
    /// </summary>
    public static void Load()
    {
        data = new Dictionary<string, string>();
        if (File.Exists(filePath))
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    data.Add(line.Split()[0], line.Split()[1]);
                }
                sr.Close();
            }
        }
        else throw new System.Exception("存档不存在");
    }
}
