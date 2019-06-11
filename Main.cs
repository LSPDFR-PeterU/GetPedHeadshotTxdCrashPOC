using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LSPD_First_Response.Engine.Scripting.Entities;
using Rage;
using LSPD_First_Response.Mod.API;

namespace GetPedHeadshotTxdCrashPOC
{

    public class Main : Plugin
    {

        public static Ped ped;


        public override void Initialize()
        {
            Functions.OnOnDutyStateChanged += Functions_OnOnDutyStateChanged;
        }

        public override void Finally()
        {
            if (ped)
            {
                ped.Delete();
            }
            return;
        }

        private void Functions_OnOnDutyStateChanged(bool onDuty)
        {
            ped = new Ped();
            ped.SetPositionWithSnap(Game.LocalPlayer.Character.GetOffsetPositionFront(3.0f));

            Persona newPersona = new Persona("Testy", "McTestFace", LSPD_First_Response.Gender.Male);
            Functions.SetPersonaForPed(ped, newPersona);

            Game.DisplaySubtitle("Now stop the ped holding 'E' and ask for ID.");

        }
    }
}
