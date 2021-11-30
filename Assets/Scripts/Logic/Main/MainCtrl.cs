using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCtrl : MonoBehaviour
{
    public Transform root;

    //点击录入
    public void OnClickEntering(){
        EnteringNormalCtrl.Show(root);
    }

    public void OnClickImport(){

    }

    public void OnClickFilter(){
        
    }
}
