using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SortObjects : MonoBehaviour
{
    public List<Transform> objlist = new List<Transform>(4);
    

    //外部で決めた値を元にソート
    // 4 -> 1 -> 2 -> 3 の順にソート
    public void SortBasedExternalValue() {
        List<int> order = new List<int>(){3,0,1,2};
        for(int i = 0; i < 4; i++ ) {
            objlist[order[i]].SetSiblingIndex(i);
        }
    }


    // 内部の value を元にソート
    public void SortBasedInternalValue() {
        List<Tuple<Transform,int>> objpairlist =  new List<Tuple<Transform,int>>();
        foreach (Transform obj in objlist){
            objpairlist.Add(new Tuple<Transform, int>(obj,obj.GetComponent<Value>().value ));
        }
        objpairlist.Sort((a, b) => a.Item2 - b.Item2 );
        // a.Item2 - b.Item2 < 0 なら a がbより前になる。つまり昇順ソート


        for(int i = 0; i < objpairlist.Count; i++) {
            objpairlist[i].Item1.SetSiblingIndex(i);
        }


    }


}
