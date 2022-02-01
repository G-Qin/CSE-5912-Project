using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class BillBoard : MonoBehaviour
    {
        public Transform camera;
        private void LateUpdate()
        {
            transform.LookAt(transform.position + camera.forward);
        }

    }


