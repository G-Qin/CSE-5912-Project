using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class BillBoard : MonoBehaviour
    {
        public Transform camera;

        void Start(){
            camera=GameObject.Find("/P_LPSP_FP_CH_1/SK_FP_CH_Default_Root/Armature/root/pelvis/spine_01/spine_02/spine_03/neck_01/head/SOCKET_Camera/Camera/Camera Depth").transform;
        }

        private void LateUpdate()
        {
            transform.LookAt(transform.position + camera.forward);
        }

    }


