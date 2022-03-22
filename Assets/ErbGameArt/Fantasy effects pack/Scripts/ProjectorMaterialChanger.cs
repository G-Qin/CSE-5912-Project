using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorMaterialChanger : MonoBehaviour
{
    private float value = 0.01f;
    private float TimeRate = 0;
    public float Timer = 2f;
    private float TimerPlus = 0f;
    private float TimerMinus = 0f;

    private bool Undo;
    public bool opacity = false;
    public bool PlusAndMinus = false;
    private Material mat;

    void Start()
    {
        TimerPlus = (Timer / 10f) * 1f;
        TimerMinus = (Timer / 10f) * 9f;
        Undo = false;
        var proj = GetComponent<Projector>();
        if (!proj.material.name.EndsWith("(Instance)"))
            proj.material = new Material(proj.material) { name = proj.material.name + " (Instance)" };
        mat = proj.material;
    }
    void Update ()
    {
        if (opacity == true && TimeRate <= Timer && Undo == false)
        {
            TimeRate += Time.deltaTime;
            if (PlusAndMinus == false)
            {
                value = Mathf.Lerp(1f, 0f, TimeRate / Timer);
            }
            else
            {
                if (TimeRate < TimerPlus)
                {
                    value = Mathf.Lerp(0f, 1f, TimeRate / TimerPlus);
                }
                if (TimeRate > TimerPlus)
                {
                    value = Mathf.Lerp(1f, 0f, TimeRate / TimerMinus);
                }
            }
            mat.SetFloat("_Opacity", value);
        }

        if (opacity == false)
        {
            if (TimeRate <= Timer && Undo == false)
            {
                TimeRate += Time.deltaTime;
                value = Mathf.Lerp(0.01f, 4f, TimeRate / Timer);
                mat.SetFloat("_MoveCirle", value);
            }

            if (TimeRate >= Timer && Undo == false)
            {
                check();
            }

            if (Undo == true && TimeRate <= Timer)
            {
                TimeRate += Time.deltaTime;
                value = Mathf.Lerp(4f, 0.01f, TimeRate / Timer);
                mat.SetFloat("_MoveCirle", value);
            }
        }
    }

    void check()
    {
        Undo = true;
        TimeRate = 0;
    }
}
