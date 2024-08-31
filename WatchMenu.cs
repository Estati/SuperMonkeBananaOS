using BananaOS;
using BananaOS.Pages;
using Photon.Pun;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.XR;
using Utilla;

namespace SuperMonkeBananaOS
{
    internal class WatchMenu : WatchPage
    {
        public override string Title => "<color=red>Super</color><color=blue>Monke</color>";
        public override bool DisplayOnMainMenu => true;
        public bool IsEnabled;

        public override void OnPostModSetup()
        {

            selectionHandler.maxIndex = 1;
        }
        public override string OnGetScreenContent()
        {
            var BuildMenuOptions = new StringBuilder();
            BuildMenuOptions.AppendLine("<color=red>========================</color>");
            BuildMenuOptions.AppendLine("            <color=blue>Super Monke</color>");
            BuildMenuOptions.AppendLine("");
            BuildMenuOptions.AppendLine("             By: <color=blue>Estatic</color>");
            BuildMenuOptions.AppendLine("<color=red>========================</color>");
            BuildMenuOptions.AppendLine("");
            BuildMenuOptions.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(0, "[Enabled : " + IsEnabled + "]"));
            BuildMenuOptions.AppendLine("");
            BuildMenuOptions.AppendLine(selectionHandler.GetOriginalBananaOSSelectionText(1, "[Force : " + force + "]"));
            return BuildMenuOptions.ToString();

        }
        public float force;
        public bool NoGravBool;



        public override void OnButtonPressed(WatchButtonType buttonType)
        {
            switch (buttonType)
            {
                case WatchButtonType.Down:
                    selectionHandler.MoveSelectionDown();
                    break;

                case WatchButtonType.Up:
                    selectionHandler.MoveSelectionUp();
                    break;

                case WatchButtonType.Right:
                    if (selectionHandler.currentIndex == 1)
                    {
                        if (force > 25)
                        {
                            force -= 1f;
                        }
                        else
                        {
                            force += 1f;
                        }
                    }

                    break;
                case WatchButtonType.Left:
                    if (selectionHandler.currentIndex == 1)
                    {
                        if (force < 1)
                        {
                            force += 1f;
                        }
                        else
                        {
                            force -= 1f;
                        }
                    }
                    break;

                case WatchButtonType.Enter:
                    if (selectionHandler.currentIndex == 0)
                    {
                        IsEnabled = !IsEnabled;
                    }
                    break;

                case WatchButtonType.Back:
                    ReturnToMainMenu();
                    break;
            }
        }
        void Update()
        {
            // thanks for the gamemode check dean!
            if (IsEnabled && PhotonNetwork.CurrentRoom.CustomProperties["gameMode"].ToString().Contains("MODDED_"))
            {

                if (ControllerInputPoller.instance.rightControllerPrimaryButton)
                {
                    GorillaLocomotion.Player.Instance.transform.position += GorillaLocomotion.Player.Instance.headCollider.transform.forward * force * Time.deltaTime;
                    GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity = Vector3.zero;
                }

                if (ControllerInputPoller.instance.rightControllerSecondaryButton)
                {
                    GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity += GorillaLocomotion.Player.Instance.bodyCollider.transform.up * 9.9f * Time.deltaTime;
                }
            }
        }
    }
}
