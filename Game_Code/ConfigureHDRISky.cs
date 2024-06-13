using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class ConfigureHDRISky : MonoBehaviour
{
    public Cubemap hdrTexture;  // 你的HDR或EXR文件
    public float exposure = 1.0f;
    public float rotation = 0.0f;

    void Start()
    {
        // 创建Volume对象并设置为全局
        Volume volume = gameObject.AddComponent<Volume>();
        volume.isGlobal = true;

        // 创建Volume Profile
        VolumeProfile profile = ScriptableObject.CreateInstance<VolumeProfile>();
        volume.profile = profile;

        // 添加HDRI Sky Override
        HDRISky hdrSky;
        if (!profile.TryGet(out hdrSky))
        {
            hdrSky = profile.Add<HDRISky>(true);
        }

        // 配置HDRI Sky
        hdrSky.active = true;
        hdrSky.hdriSky.value = hdrTexture;
        hdrSky.exposure.value = exposure;
        hdrSky.rotation.value = rotation;
    }
}
