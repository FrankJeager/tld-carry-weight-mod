using MelonLoader;
using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppTLD.Gear;
using Il2CppTLD.IntBackedUnit;
using static Il2CppSystem.Xml.XmlWellFormedWriter.AttributeValueCache;

namespace CarryWeightMod
{
    class CarryWeightMod : MelonMod
    {
        public override void OnInitializeMelon()
        {
            Settings.OnLoad();
        }

        public static void EncumberUpdate(Encumber encumberComp)
        {
            if (Settings.options.carryKgAdd > 0 || Settings.options.infiniteCarry)
            {
                int carryAdd = Settings.options.carryKgAdd;
                if (Settings.options.infiniteCarry) carryAdd = 9970;

                encumberComp.m_MaxCarryCapacity = ItemWeight.FromKilograms(30f + carryAdd);
                encumberComp.m_MaxCarryCapacityWhenExhausted = ItemWeight.FromKilograms(15f + carryAdd);
                encumberComp.m_NoSprintCarryCapacity = ItemWeight.FromKilograms(40f + carryAdd);
                encumberComp.m_NoWalkCarryCapacity = ItemWeight.FromKilograms(60f + carryAdd);
                encumberComp.m_EncumberLowThreshold = ItemWeight.FromKilograms(31f + carryAdd);
                encumberComp.m_EncumberMedThreshold = ItemWeight.FromKilograms(40f + carryAdd);
                encumberComp.m_EncumberHighThreshold = ItemWeight.FromKilograms(60f + carryAdd);
            }
            else
            {
                encumberComp.m_MaxCarryCapacity = ItemWeight.FromKilograms(30f);
                encumberComp.m_MaxCarryCapacityWhenExhausted = ItemWeight.FromKilograms(15f);
                encumberComp.m_NoSprintCarryCapacity = ItemWeight.FromKilograms(40f);
                encumberComp.m_NoWalkCarryCapacity = ItemWeight.FromKilograms(60f);
                encumberComp.m_EncumberLowThreshold = ItemWeight.FromKilograms(31f);
                encumberComp.m_EncumberMedThreshold = ItemWeight.FromKilograms(40f);
                encumberComp.m_EncumberHighThreshold = ItemWeight.FromKilograms(60f);
            }
        }
    }
}
