using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Adult {

    private void OnTriggerEnter(Collider other) {
        switch (other.tag) {
            case "Kidnapper":
                other.gameObject.SendMessage("Die");
                break;
            default:
                break;
        }
    }
    
}
