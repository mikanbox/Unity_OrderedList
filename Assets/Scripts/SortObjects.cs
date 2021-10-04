using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SortObjects : MonoBehaviour
{
    public List<Transform> objlist = new List<Transform>(4);

    public bool isMoving = false;

    Transform a;
    Vector3 a_destPos;
    Transform b;
    Vector3 b_destPos;

    

    //外部で決めた値を元にソート
    // 4 -> 1 -> 2 -> 3 の順にソート
    public void SortBasedExternalValue() {
        // List<int> order = new List<int>(){3,2,1,0};
        // for(int i = 0; i < 4; i++ ) {
        //     objlist[order[i]].SetSiblingIndex(i);
        // }
    }

    // 移動中は座標を少しづつ変化させる
    void Update() {
        if (isMoving) {
            a.position = a.position + new Vector3( (a_destPos.x - a.position.x) /20f ,  (a_destPos.y - a.position.y)/20f,0 );
            b.position = b.position + new Vector3( (b_destPos.x - b.position.x) /20f ,  (b_destPos.y - b.position.y)/20f,0 );

            if ( (a.position.y - a_destPos.y)*(a.position.y - a_destPos.y)  < 0.1f  ) {
                isMoving = false;
                List<Transform> tmpobjlist =  new List<Transform>();
        
                for(int i = 0; i < objlist[0].parent.childCount; i++ ) {
                    Transform obj = objlist[0].parent.GetChild(i);
                    tmpobjlist.Add(obj);
                }
                for(int i = 0; i < tmpobjlist.Count ; i++ ) {
                    tmpobjlist[i].GetComponent<UnityEngine.UI.Image>().color = Color.black;
                }
            }
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



        for(int i = 0; i < tmpobjlist.Count - 1; i++ ) {       
            int val_a = tmpobjlist[i].GetComponent<Value>().value;
            int val_b = tmpobjlist[i + 1].GetComponent<Value>().value;


            if (val_a > val_b) {
                tmpobjlist[i].GetComponent<UnityEngine.UI.Image>().color = Color.blue;
                tmpobjlist[i + 1].GetComponent<UnityEngine.UI.Image>().color = Color.blue;

                // 切り替え後処理
                tmpobjlist[i + 1].SetSiblingIndex(i);
                isMoving = true;
                a = tmpobjlist[i];
                a_destPos = tmpobjlist[i + 1].position;
                b = tmpobjlist[i + 1];
                b_destPos = tmpobjlist[i].position;
                break;
            }
        }
        




    }


}
