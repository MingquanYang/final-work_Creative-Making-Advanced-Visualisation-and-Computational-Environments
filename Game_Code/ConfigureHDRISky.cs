using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class ConfigureHDRISky : MonoBehaviour
{
    public Cubemap hdrTexture;  // ���HDR��EXR�ļ�
    public float exposure = 1.0f;
    public float rotation = 0.0f;

    void Start()
    {
        // ����Volume��������Ϊȫ��
        Volume volume = gameObject.AddComponent<Volume>();
        volume.isGlobal = true;

        // ����Volume Profile
        VolumeProfile profile = ScriptableObject.CreateInstance<VolumeProfile>();
        volume.profile = profile;

        // ���HDRI Sky Override
        HDRISky hdrSky;
        if (!profile.TryGet(out hdrSky))
        {
            hdrSky = profile.Add<HDRISky>(true);
        }

        // ����HDRI Sky
        hdrSky.active = true;
        hdrSky.hdriSky.value = hdrTexture;
        hdrSky.exposure.value = exposure;
        hdrSky.rotation.value = rotation;
    }
}
