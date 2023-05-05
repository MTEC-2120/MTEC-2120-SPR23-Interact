using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Interaction
{
    public class Inventory : MonoBehaviour
    {
        public bool HasKey = false;

        private void Update()
        {
            if (Keyboard.current.qKey.wasPressedThisFrame) HasKey = !HasKey;
        }
    }
}