using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.VFX;
using static ColorExtension.ColorExtension;

public class FireEffectController : MonoBehaviour
{
    private VisualEffect vfx;
    private Light light;
    
    [Range(0.0f,1.0f)]
    public float growth;
    
    public Gradient colorOverGradient;
    public AnimationCurve radiusOverGrowth;
    public AnimationCurve turbulenceOverGrowth;
    public AnimationCurve lightIntensityOverGrowth;
    public AnimationCurve spawnRateOverGrowth;
    private Vector3 lastPosition;
    public Gradient testG;
    void Start()
    {
        light = GetComponent<Light>();
        vfx = GetComponent<VisualEffect>();
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = quaternion.identity;
        UpdateEffect();
        lastPosition = transform.position;
    }

    void UpdateEffect()
    {
        Color currentColor = colorOverGradient.Evaluate(growth);

        light.color = PowColor(MixColor(currentColor, Color.white, 0.6f), 0.3f);
        light.intensity = lightIntensityOverGrowth.Evaluate(growth);
        
        vfx.SetFloat("_Radius",radiusOverGrowth.Evaluate(growth));
        vfx.SetFloat("_TurbulenceIntensity",turbulenceOverGrowth.Evaluate(growth));
        vfx.SetFloat("_SpawnRate",spawnRateOverGrowth.Evaluate(growth));
        vfx.SetVector3("_TargetVelocity",(transform.position-lastPosition)/Time.deltaTime);
        vfx.SetGradient("_ColorGradient",GetParticleGradient(currentColor));
        testG = GetParticleGradient(currentColor);
    }

    static Gradient GetParticleGradient(Color color)
    {
        Gradient gradient = new Gradient();

        GradientColorKey[] colors = new GradientColorKey[4];
        colors[0] = new GradientColorKey(PowColor(MixColor(color,Color.white,0.3f),1.5f)*5f,0.0f);
        colors[1] = new GradientColorKey(PowColor(MixColor(color,Color.white,0.1f),2.5f)*5f,0.25f);
        colors[2] = new GradientColorKey(PowColor(MixColor(color,Color.black,0.1f),3.75f)*4f,0.6f);
        colors[3] = new GradientColorKey(PowColor(MixColor(color,Color.black,0.6f),5.0f)*1f,1f);
        GradientAlphaKey[] alphas = new GradientAlphaKey[]
        {
            new GradientAlphaKey(0f,0f),
            new GradientAlphaKey(1f,0.075f),
            new GradientAlphaKey(1f,0.75f),
            new GradientAlphaKey(0f,1f)
        };
        gradient.SetKeys(colors,alphas);
        return gradient;
    }

    private void OnValidate()
    {
        Start();
        FixedUpdate();
    }
}
