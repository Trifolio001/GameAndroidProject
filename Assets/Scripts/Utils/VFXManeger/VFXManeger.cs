using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using generic.core.Singleton;

public class VFXManeger : Singleton<VFXManeger>
{
    public enum VFXType
    {
        BulletEfect,
        JumpZombyEffect
    }

    public List<VFXManegerSetup> vfxSetup;
    
    public void PlayVFXByTipe(VFXType vfxType, Vector3 position, float scale)
    {
        foreach(var i in vfxSetup)
        {
            if(i.vfxType == vfxType)
            {
                var item = Instantiate(i.prefab);
                item.transform.position = position;
                item.transform.localScale = new Vector3( 1, 1, scale);
                Destroy(item.gameObject, 3f);
                break;
            }
        }
    }

    [System.Serializable]
    public class VFXManegerSetup
    {
        public VFXManeger.VFXType vfxType;
        public GameObject prefab;
    }

}
