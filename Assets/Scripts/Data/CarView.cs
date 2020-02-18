using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarView : ReusableObject
{
    Collider _colliderObj;

   public Collider colliderObj{
      get{
        if (_colliderObj == null)
            _colliderObj = GetComponent<Collider>();

         return _colliderObj;
      }
      set{
         _colliderObj = value;
      }
   }   
}
