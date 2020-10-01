using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanPickUpItem : MonoBehaviour 
{
   void OnTriggerEnter(Collider other) {
    if (other.gameObject.layer == GameLayer.Collectable) {
      Destroy(other.gameObject);
    }
  }
}
