using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBillBoard : MonoBehaviour
{
    private Transform camera;
    private Vector3 offset;

    void Start()
    {
        camera = GameObject.Find("/P_LPSP_FP_CH_1/SK_FP_CH_Default_Root/Armature/root/pelvis/spine_01/spine_02/spine_03/neck_01/head/SOCKET_Camera/Camera/Camera Depth").transform;
        offset = transform.position - camera.position;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + camera.forward);
        transform.rotation = camera.rotation;
        transform.position = camera.position + offset;
    }
}
