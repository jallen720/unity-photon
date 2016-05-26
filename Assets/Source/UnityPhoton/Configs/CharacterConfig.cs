using UnityEngine;
using UnityUtils.ConfigUtils;

public class CharacterConfig : Config<CharacterConfig> {

    [SerializeField]
    private Color[] characterColors;

    // Static members

    public static Color[] CharacterColors {
        get {
            return Instance.characterColors;
        }
    }
}