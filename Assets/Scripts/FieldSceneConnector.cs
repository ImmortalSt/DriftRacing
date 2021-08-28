using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FieldSceneConnector
{
    private static Field _field;
    private static bool GetAbility = false;

    public static void SaveField(Field field)
    {
        _field = field;
        GetAbility = true;
    }
    public static Field GetField()
    {
        if(GetAbility == true)
            return _field;

        GetAbility = false;
        return null;
    }
}
