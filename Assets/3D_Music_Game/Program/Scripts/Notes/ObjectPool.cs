using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    List<GameObject> poolObjList;
    GameObject poolObj;

    // オブジェクトプールを作成
    public void CreatePool(GameObject obj, int maxCount)
    {
        poolObj = obj;
        poolObjList = new List<GameObject>();
        for (int i = 0; i < maxCount; i++)
        {
            var newObj = CreateNewObject();
            newObj.SetActive(false);
            poolObjList.Add(newObj);
        }
    }

    public GameObject GetObject()
    {
        // 使用中でないものを探す
        foreach (var obj in poolObjList)
        {
            if (obj.activeSelf == false)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // 全て使用中だったら新しく作って返す
        var newObj = CreateNewObject();
        newObj.SetActive(true);
        poolObjList.Add(newObj);
        return newObj;
    }

    GameObject CreateNewObject()
    {
        var newObj = Instantiate(poolObj);
        newObj.name = poolObj.name + (poolObjList.Count + 1);
        return newObj;
    }
}
