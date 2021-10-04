using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SortObjects : MonoBehaviour
{
    public List<Transform> objlist = new List<Transform>(4);

    bool isMoving = false;

    public float time = 0f;
    

    //外部で決めた値を元にソート
    // 4 -> 1 -> 2 -> 3 の順にソート
    public void SortBasedExternalValue() {
        List<int> order = new List<int>(){3,2,1,0};
        for(int i = 0; i < 4; i++ ) {
            objlist[order[i]].SetSiblingIndex(i);
        }
    }

    void Update() {
        if (time > 0) {
            // 移動中は座標を少しづつ変化させる
        } else {
            isMoving = false;
        }
    }


    // 内部の value を元にソート
    public void SortBasedInternalValue() {
        if (isMoving)
            return;
        
        List<Transform> tmpobjlist =  new List<Transform>();
        
        for(int i = 0; i < objlist[0].parent.childCount; i++ ) {
            Transform obj = objlist[0].parent.GetChild(i);
            tmpobjlist.Add(obj);
        }


        // objpairlist.Sort((a, b) => a.Item2 - b.Item2 );
        // a.Item2 - b.Item2 < 0 なら a がbより前になる。つまり昇順ソート
        for(int i = 0; i < tmpobjlist.Count ; i++ ) {
            tmpobjlist[i].GetComponent<UnityEngine.UI.Image>().color = Color.black;
        }

        for(int i = 0; i < tmpobjlist.Count - 1; i++ ) {       
            int val_a = tmpobjlist[i].GetComponent<Value>().value;
            int val_b = tmpobjlist[i + 1].GetComponent<Value>().value;


            if (val_a > val_b) {
                tmpobjlist[i].GetComponent<UnityEngine.UI.Image>().color = Color.blue;
                tmpobjlist[i + 1].GetComponent<UnityEngine.UI.Image>().color = Color.blue;

                // 切り替え後処理
                tmpobjlist[i + 1].SetSiblingIndex(i);
                time = 1f;
                isMoving = true;
                break;
            }
        }
        




    }


}
