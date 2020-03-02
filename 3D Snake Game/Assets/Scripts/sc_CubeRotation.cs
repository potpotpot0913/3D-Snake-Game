﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class sc_CubeRotation : MonoBehaviour{


    public float f_RotateTime;

    bool bool_IsRotate;

    void Start(){
        bool_IsRotate = false;
    }

    IEnumerator StartCubeRoation(Vector3 v3_rotateDirection){
        
        bool_IsRotate = true;
        yield return CubeRotation(v3_rotateDirection);
        bool_IsRotate = false;
    }

    IEnumerator CubeRotation(Vector3 v3_rotateDirection){
        // ease function: Ease.OutExpo
        // rotate time: f_RotateTime
        yield return this.gameObject.transform.DOLocalRotate(new Vector3(v3_rotateDirection.x,v3_rotateDirection.y,v3_rotateDirection.z), f_RotateTime,RotateMode.WorldAxisAdd).SetEase(Ease.OutExpo).WaitForCompletion();
    }

    public bool IsRotating(){
        return bool_IsRotate;
    }

    public void Rotate(string str_rotateDirection){
        Vector3 v3_rotateDirection = new Vector3(0.0f,0.0f,0.0f);

        if(str_rotateDirection == "up"){
            v3_rotateDirection.Set(0.0f,0.0f,90.0f);
        }else if(str_rotateDirection == "down"){
            v3_rotateDirection.Set(0.0f,0.0f,-90.0f);
        }else if(str_rotateDirection == "right"){
            v3_rotateDirection.Set(0.0f,-90.0f,0.0f);
        }else if(str_rotateDirection == "left"){
            v3_rotateDirection.Set(0.0f,90.0f,0.0f);
        }else if(str_rotateDirection == "clockwise"){
            v3_rotateDirection.Set(90.0f,0.0f,0.0f);
        }else if(str_rotateDirection == "counterClockwise"){
            v3_rotateDirection.Set(-90.0f,0.0f,0.0f);
        }

        if(!bool_IsRotate){
            StartCoroutine("StartCubeRoation" , v3_rotateDirection);
        }
    }

   

    void Update(){

    }


}
