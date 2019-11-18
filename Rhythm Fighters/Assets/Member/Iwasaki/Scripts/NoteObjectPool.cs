using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//オブジェクトプールとやら
public class NoteObjectPool : MonoBehaviour
{
    private List<GameObject> noteObjPoolL;
    private List<GameObject> noteObjPoolR;
    private GameObject noteObj;
    [SerializeField]
    private GameObject parentObj;

    //オブジェクトプール作成(左)
    public void CreatePoolL(GameObject obj, int maxCount)
    {
        noteObj = obj;
        noteObjPoolL = new List<GameObject>();
        for(int i = 0; i < maxCount; i++)
        {
            var newObj = CreateNewObjectL();
            newObj.SetActive(false);
            noteObjPoolL.Add(newObj);
        }
    }
    public GameObject GetGameObjL()
    {
        //使用中でないものを探す
        foreach (var obj in noteObjPoolL)
        {
            if (obj.activeSelf == false)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        //すべて使用中だったら新しく作って返す
        var newObj = CreateNewObjectL();
        newObj.SetActive(true);
        noteObjPoolL.Add(newObj);
        return newObj;
    }
    private GameObject CreateNewObjectL()
    {
        var newObj = Instantiate(noteObj);
        newObj.name = noteObj.name + (noteObjPoolL.Count + 1);
        newObj.transform.SetParent(parentObj.transform);
        return newObj;
    }
    //オブジェクトプール作成(右)
    public void CreatePoolR(GameObject obj, int maxCount)
    {
        noteObj = obj;
        noteObjPoolR = new List<GameObject>();
        for (int i = 0; i < maxCount; i++)
        {
            var newObj = CreateNewObjectR();
            newObj.SetActive(false);
            noteObjPoolR.Add(newObj);
        }
    }
    public GameObject GetGameObjR()
    {
        //使用中でないものを探す
        foreach(var obj in noteObjPoolR)
        {
            if(obj.activeSelf == false)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        //すべて使用中だったら新しく作って返す
        var newObj = CreateNewObjectR();
        newObj.SetActive(true);
        noteObjPoolR.Add(newObj);
        return newObj;
    }
    private GameObject CreateNewObjectR()
    {
        var newObj = Instantiate(noteObj);
        newObj.name = noteObj.name + (noteObjPoolR.Count + 1);
        newObj.transform.SetParent(parentObj.transform);
        return newObj;
    }
}
