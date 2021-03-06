﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameScreen
{
    /// <summary>
    /// オブジェクトを生成して使い回すクラス
    /// </summary>
    public abstract class ObjectPool : MonoBehaviour
    {
        /// <summary> Poolしたオブジェクトを </summary>
        GameObject parentObj;
        /// <summary> PoolするObject </summary>
        GameObject poolObj;
        /// <summary> PoolしたObjectを格納するList </summary>
        List<GameObject> poolObjList = new List<GameObject>();

        /// <summary>
        /// オブジェクトプールを作成
        /// </summary>
        /// <param name="obj"> Instance化するObject </param>
        /// <param name="pos"> Instance化する位置 </param>
        /// <param name="angle"> Instance化する角度 </param>
        protected void CreatePool(GameObject parentObj, GameObject obj, Vector3 pos, Quaternion angle)
        {
            poolObj = obj;

            var newObj = CreateNewObject(parentObj, pos, angle);
            //newObj.gameObject.SetActive(false);
            poolObjList.Add(newObj);
        }

        /// <summary>
        /// 未使用のObjectを探す
        /// </summary>
        /// <param name="pos"> Instance化する位置 </param>
        /// <param name="angle"> Instance化する角度 </param>
        /// <returns></returns>
        protected GameObject GetUnusedObject(Vector3 pos, Quaternion angle)
        {
            // 使用中でないものを探す
            foreach (var obj in poolObjList)
            {
                if (obj.gameObject.activeSelf == false)
                {
                    obj.gameObject.SetActive(true);
                    return obj;
                }
            }

            // 全て使用中だったら新しく作って返す
            var newObj = CreateNewObject(parentObj, pos, angle);
            newObj.gameObject.SetActive(true);
            poolObjList.Add(newObj);
            return newObj;
        }

        /// <summary>
        /// Objectが足らなかった場合、新しくInstance化する
        /// </summary>
        /// <param name="pos"> 位置 </param>
        /// <param name="angle"> 角度 </param>
        /// <returns> Instance化したObject </returns>
        GameObject CreateNewObject(GameObject parent, Vector3 pos, Quaternion angle)
        {
            var newObj = Instantiate(poolObj, pos, angle);
            newObj.name = poolObj.name + (poolObjList.Count + 1);
            newObj.transform.parent = parent.transform;
            return newObj;
        }

        /// <summary>
        /// PoolしたObjectを全て削除する
        /// </summary>
        protected void DeleteAllPoolObject()
        {
            foreach (var poolObj in poolObjList)
            {
                Destroy(poolObj);
            }

            poolObjList.Clear();
        }
    }
}