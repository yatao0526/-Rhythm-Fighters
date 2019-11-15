using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//オブジェクトプールとやら
public class NoteObjectPool : MonoBehaviour
{
    private List<GameObject> noteObjPool;
    private GameObject noteObj;
    [SerializeField]
    private GameObject parentObj;

    //オブジェクトプール作成
    public void CreatePool(GameObject obj, int maxCount)
    {
        noteObj = obj;
        noteObjPool = new List<GameObject>();
        for(int i = 0; i < maxCount; i++)
        {
            var newObj = CreateNewObject();
            newObj.SetActive(false);
            noteObjPool.Add(newObj);
        }
    }
    //
    public GameObject GetGameObjR()
    {
        //使用中でないものを探す
        foreach(var obj in noteObjPool)
        {
            if(obj.activeSelf == false)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        //すべて使用中だったら新しく作って返す
        var newObj = CreateNewObject();
        newObj.SetActive(true);
        noteObjPool.Add(newObj);
        return newObj;
    }
    public GameObject GetGameObjL()
    {
        //使用中でないものを探す
        foreach (var obj in noteObjPool)
        {
            if (obj.activeSelf == false)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        //すべて使用中だったら新しく作って返す
        var newObj = CreateNewObject();
        newObj.SetActive(true);
        noteObjPool.Add(newObj);
        return newObj;
    }
    //
    private GameObject CreateNewObject()
    {
        var newObj = Instantiate(noteObj);
        newObj.name = noteObj.name + (noteObjPool.Count + 1);
        newObj.transform.SetParent(parentObj.transform);
        return newObj;
    }
}
