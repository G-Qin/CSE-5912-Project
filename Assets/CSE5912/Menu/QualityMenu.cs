using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class QualityMenu : MonoBehaviour
{
    /// <summary>
    /// If true, it means that this menu is enabled and showing properly.
    /// </summary>
    private bool menuIsEnabled;

    /// <summary>
    /// Main Post Processing Volume.
    /// </summary>
    private PostProcessVolume postProcessingVolume;
    /// <summary>
    /// Scope Post Processing Volume.
    /// </summary>
    private PostProcessVolume postProcessingVolumeScope;

    /// <summary>
    /// Depth Of Field Settings.
    /// </summary>
    private DepthOfField depthOfField;

    private void Start()
    {

        //Find post process volumes in scene and assign them.
        postProcessingVolume = GameObject.Find("Post Process Volume").GetComponent<PostProcessVolume>();
        postProcessingVolumeScope = GameObject.Find("Post Process Volume Scope").GetComponent<PostProcessVolume>();

        //Get depth of field setting from main post process volume.
        postProcessingVolume.profile.TryGetSettings(out depthOfField);
    }
    /// <summary>
    /// Sets whether the post processing is enabled, or disabled.
    /// </summary>
    private void SetPostProcessingState(bool value = true)
    {
        //Enable/Disable the volumes.
        postProcessingVolume.enabled = value;
        postProcessingVolumeScope.enabled = value;
    }

    /// <summary>
    /// Sets the graphic quality to very low.
    /// </summary>
    public void SetQualityVeryLow()
    {
        //Set Quality.
        QualitySettings.SetQualityLevel(0);
        //Disable Post Processing.
        SetPostProcessingState(false);
    }
    /// <summary>
    /// Sets the graphic quality to low.
    /// </summary>
    public void SetQualityLow()
    {
        //Set Quality.
        QualitySettings.SetQualityLevel(1);
        //Disable Post Processing.
        SetPostProcessingState(false);
    }

    /// <summary>
    /// Sets the graphic quality to medium.
    /// </summary>
    public void SetQualityMedium()
    {
        //Set Quality.
        QualitySettings.SetQualityLevel(2);
        //Enable Post Processing.
        SetPostProcessingState();
    }
    /// <summary>
    /// Sets the graphic quality to high.
    /// </summary>
    public void SetQualityHigh()
    {
        //Set Quality.
        QualitySettings.SetQualityLevel(3);
        //Enable Post Processing.
        SetPostProcessingState();
    }

    /// <summary>
    /// Sets the graphic quality to very high.
    /// </summary>
    public void SetQualityVeryHigh()
    {
        //Set Quality.
        QualitySettings.SetQualityLevel(4);
        //Enable Post Processing.
        SetPostProcessingState();
    }
    /// <summary>
    /// Sets the graphic quality to ultra.
    /// </summary>
    public void SetQualityUltra()
    {
        //Set Quality.
        QualitySettings.SetQualityLevel(5);
        //Enable Post Processing.
        SetPostProcessingState();
    }
}
