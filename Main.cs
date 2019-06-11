using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public static Blip blip;


        public override void Initialize()
        {
            Game.LogTrivial($"Init {Assembly.GetExecutingAssembly().FullName}");
            Functions.OnOnDutyStateChanged += Functions_OnOnDutyStateChanged;
        }

        public override void Finally()
        {
            if (ped)
            {
                ped.Delete();
            }
            if (blip)
            {
                blip.Delete();
            }
            return;
        }

        private void Functions_OnOnDutyStateChanged(bool onDuty)
        {
            if (onDuty) { 
                ped = new Ped();
                blip = ped.AttachBlip();
                ped.SetPositionWithSnap(Game.LocalPlayer.Character.GetOffsetPositionFront(3.0f));

                Persona newPersona = new Persona("Testy", "McTestFace", LSPD_First_Response.Gender.Male);
                Functions.SetPersonaForPed(ped, newPersona);

                Game.DisplaySubtitle("Now cause the ped to be Stopped by Player by holding 'E' and ask for ID.");
            }
            else
            {
                Finally();
            }
        }
    }
}
