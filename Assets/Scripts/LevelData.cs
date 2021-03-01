using System.Collections;
using System.Collections.Generic;


namespace gvdt
{
    [System.Serializable]
    public class LevelData
    {
        public int level;
        public string playerName;
        public Object[] entities;
        public UnityEngine.Color backGroundColor;
        public Object cannon;
    }

    [System.Serializable]
    public class Object
    {
        public int Prefabid;
        public int PrefabVariant;
        public int id;
        public float x;
        public float y;
        public float xScale;
        public float yScale;
        public float zRot;
        public float z;
        
    }
}