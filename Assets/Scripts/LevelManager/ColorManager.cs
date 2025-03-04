using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using generic.core.Singleton;

public class ColorManager : Singleton<ColorManager>
{
    public List<Material> materials;
    public List<ColorSetup> colorSetups;
    public List<Material> materialColorPredioSetups;

    public void ChangeColorByType(ArtManager.ArtType artTipe)
    {
        var setup = colorSetups.Find(i => i.artType == artTipe);

        for(int i = 0; i < materials.Count; i++)
        {
            materials[i].SetColor("_Color", setup.colors[i]);
        }
    }
}


[System.Serializable]
public class ColorSetup
{
    public ArtManager.ArtType artType;
    public List<Color> colors;
}
