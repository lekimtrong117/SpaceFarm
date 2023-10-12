using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//base max yang energy	upgraded max yang energy	base max ying energy	upgraded max ying energy	base attack	upgraded attack
public class ConfigMainCharacterRecord

{
    public float base_max_yang_energy;
    public float upgraded_max_yang_energy;
    public float base_max_ying_energy;
    public float upgraded_max_ying_energy;
    public float base_attack;
    public float upgraded_attack;
}
public class ConfigMainCharacter : MyDataTable<ConfigMainCharacterRecord>
{
    public override ConfigCompare<ConfigMainCharacterRecord> DefineCompare()
    {
        ConfigCompare<ConfigMainCharacterRecord> configcompare = new ConfigCompare<ConfigMainCharacterRecord>("upgraded_attack");
        return configcompare;
    }
}
