using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RGBMaterial : MonoBehaviour
{
    Material mt;
    float H;

    bool emissionEnabled = true;

    Color c;

    // Start is called before the first frame update
    void Start()
    {
        mt = GetComponent<Renderer>().material;
        c = mt.GetColor("_EmissionColor");
        H = Random.Range(0.0f, 1.0f);
        InvokeRepeating("SwitchButtonLight", 0.2f, 0.5f);
    }

    void SwitchButtonLight()
    {
        emissionEnabled = !emissionEnabled;
        if (emissionEnabled)
        {
            mt.EnableKeyword("_EMISSION");
            mt.SetColor("_EmissionColor", c);
        }
        else
        {
            mt.DisableKeyword("_EMISSION");
            mt.SetColor("_EmissionColor", Color.black);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //H += 0.01f;
        //if (H > 1.0f) H -= 1.0f;
        //mt.SetColor("_EmissionColor", Color.HSVToRGB(H, 1.0f, 1.0f) * 4.0f);
    }
}
