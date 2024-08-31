using System;
using System.Collections.Generic;
using System.Text;
using BepInEx;
using UnityEngine;
using UnityEngine.XR;

namespace EasyInputsClass
{
    [BepInPlugin("com.EasyTools.EasyInputs","Easy Inputs","1.0.0")]
    internal class EasyInputs:BaseUnityPlugin
    {
        public static bool Rtrigger;
        public static bool Ltrigger;
        public static bool Rgrip;
        public static bool Lgrip;
        public static bool Rprim;
        public static bool Rsec;
        public static bool Lprim;
        public static bool Lsec;
        public static Vector2 Rstick;

        void Update()
        {
            Rtrigger = ControllerInputPoller.TriggerFloat(XRNode.RightHand) == 1f;
            Rgrip = ControllerInputPoller.GripFloat(XRNode.RightHand) == 1f;
            Lgrip = ControllerInputPoller.GripFloat(XRNode.LeftHand) == 1f;
            Ltrigger = ControllerInputPoller.TriggerFloat(XRNode.LeftHand) == 1f;
            Rsec = ControllerInputPoller.instance.rightControllerSecondaryButton;
            Lsec = ControllerInputPoller.instance.leftControllerSecondaryButton;
            Rprim = ControllerInputPoller.instance.rightControllerPrimaryButton;
            Lprim = ControllerInputPoller.instance.leftControllerPrimaryButton;
            Rstick = ControllerInputPoller.instance.rightControllerPrimary2DAxis;

        }

    }
}
