using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveManager {
    // Start is called before the first frame update
    public SerializableVector4 savePosition;
    public SerializableVector4 maxPositionMap;
    public SerializableVector4 minPositionMap;
    public SerializableVector4 resetMaxPosition;
    public SerializableVector4 resetMinPosition;

    public SaveManager(Vector2 savePosition, VectorValue maxPositionMap, VectorValue minPositionMap, VectorValue resetMaxPosition, VectorValue resetMinPosition){
        this.savePosition = savePosition;
        this.maxPositionMap = maxPositionMap.initialValue;
        this.minPositionMap = minPositionMap.initialValue;
        this.resetMaxPosition = resetMaxPosition.initialValue;
        this.resetMinPosition = resetMinPosition.initialValue;
    }
    [System.Serializable]
    public class SerializableVector4
 {
     public float a;
     public float b;
     public float c;
     public float d;
 
     // Quaternion
     public static implicit operator Quaternion(SerializableVector4 sv)
     {
         return new Quaternion(sv.a, sv.b, sv.c, sv.d);
     }
 
     public static implicit operator SerializableVector4(Quaternion q)
     {
         return new SerializableVector4()
         {
             a = q.x,
             b = q.y,
             c = q.z,
             d = q.w
         };
     }
 
     // Color
     public static implicit operator Color(SerializableVector4 sv)
     {
         return new Color(sv.a, sv.b, sv.c, sv.d);
     }
 
     public static implicit operator SerializableVector4(Color c)
     {
         return new SerializableVector4()
         {
             a = c.r,
             b = c.g,
             c = c.b,
             d = c.a
         };
     }
 
     // Vector2
     public static implicit operator Vector2(SerializableVector4 sv)
     {
         return new Vector2(sv.a, sv.b);
     }
 
     public static implicit operator SerializableVector4(Vector2 v)
     {
         return new SerializableVector4()
         {
             a = v.x,
             b = v.y
         };
    }
 }

}