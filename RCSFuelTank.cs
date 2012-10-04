﻿using UnityEngine;

namespace MajiirKerbalLib
{
    public class RCSFuelTank : global::RCSFuelTank
    {
        protected override void onPartStart()
        {
            this.started = true;
            base.onPartStart();
        }

        protected override void onPartFixedUpdate()
        {
            if ((this.state == PartStates.DEACTIVATED) && (this.fuel > 0))
            {
                this.state = PartStates.ACTIVE;
                if (this.stackIcon != null)
                {
                    this.stackIcon.SetIconColor(XKCDColors.LightPeriwinkle);
                }
                else
                {
                    MonoBehaviour.print("[MajiirKerbalLib] StackIcon was null!");
                }
                this.getFuel(0);
            }
            base.onPartFixedUpdate();
        }

        public override bool RequestRCS(float amount, int earliestStage)
        {
            var commander = VesselCommander.GetInstance(this.vessel);
            if (!commander.ReturnRealRCS)
            {
                commander.RequestedRCS += amount;
                return true;
            }
            return base.RequestRCS(amount, earliestStage);
        }
    }
}
