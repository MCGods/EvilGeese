﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

/// <summary>
/// [EXTENSION ASSESSMENT 4] - added Gorrilla character 
/// [EXTENSIONS] - Added bonusHealth and bonusAttack stats to allow characters to grow stronger
/// [CHANGES] - Changed BobbyBard character type
/// 		  - Add bonus health to character types so that they can become stronger
/// </summary>
public static class CombatCharacterFactory {
	public enum CombatCharacterPresets{// always store an element from this list instead of a CombatCharacter if a variable needs to be serialized
		BobbyBard,
		CharlieCleric,
		MabelMage,
		SusanShapeShifter,
		WalterWizard,
		PamelaPaladin,
		Goose,
        ViceChancellor,
		Gorilla
	}   

	public static int bonusHealth = 0;
	public static int bonusAttack = 0;

	/// <summary>
	/// [CHANGE] - Remove feature setting Bobby Bard to half health and beta testers found it confusing and wasn't necessary to
	/// distinguish his character type
	/// [EXTENSION ASSESSMENT 4] - added clause to set gorrilla characters attack friendlies chance
	/// </summary>
	public static CombatCharacter MakeCharacter(CombatCharacterPresets characterType){
		CombatCharacter newCharacter = null;
		int characterMaxHealth = GetCharacterMaxhealth (characterType);
		int characterMaxEnergy = GetCharacterMaxEnergy (characterType);
		CombatAbility basicAttack = getCharacterBasicAttack (characterType);
		newCharacter = new CombatCharacter(characterMaxHealth, characterMaxHealth, characterMaxEnergy, characterMaxEnergy, basicAttack);
		List<CombatAbility> abilities = GetCharacterAbilities (characterType);
		foreach (CombatAbility ability in abilities) {
			newCharacter.AddAbility (ability);
		}
		if (characterType == CombatCharacterPresets.Gorilla) {
			newCharacter.attackFriendlyChance = 0.5f;
		}
		newCharacter.combatSprites = getCharacterSprites (characterType);
		return newCharacter;
	}

	/// <summary>
	/// [EXTENSION ASSESSMENT 4] - added Gorilla
	/// </summary>
	public static string GetCharacterName(CombatCharacterPresets characterType){
		switch (characterType) {
		case CombatCharacterPresets.BobbyBard:
			return "Bobby The Bard";
		case CombatCharacterPresets.CharlieCleric:
			return "Charlie The Cleric";
		case CombatCharacterPresets.MabelMage:
			return "Mabel The Mage";
		case CombatCharacterPresets.PamelaPaladin:
			return "Pamela The Paladin";
		case CombatCharacterPresets.WalterWizard:
			return "Walter The Wizard";
		case CombatCharacterPresets.SusanShapeShifter:
			return "Susan The ShapeShifter";
		case CombatCharacterPresets.Goose:
			return "Goose";
        case CombatCharacterPresets.ViceChancellor:
            return "Vice Chancellor";
		case CombatCharacterPresets.Gorilla:
			return "Garrett The Gorilla";
		}
		return "Character name not defined";
	}

	/// <summary>
	/// [CHANGE] - For all non-enemy types, add bonusHealth to their base stat
	/// </summary>
	/// <returns>The character's maximum health</returns>
	/// <param name="characterType">The character type</param>
	public static int GetCharacterMaxhealth(CombatCharacterPresets characterType){
		switch (characterType) {
		case CombatCharacterPresets.BobbyBard:
			return 70 + bonusHealth;
		case CombatCharacterPresets.CharlieCleric:
			return 100 + bonusHealth;
		case CombatCharacterPresets.MabelMage:
			return 130 + bonusHealth;
		case CombatCharacterPresets.PamelaPaladin:
			return 180 + bonusHealth;
		case CombatCharacterPresets.WalterWizard:
			return 100 + bonusHealth;
		case CombatCharacterPresets.SusanShapeShifter:
			return 100 + bonusHealth;
		case CombatCharacterPresets.Goose:
			return 50;
        case CombatCharacterPresets.ViceChancellor:
            return 1000;
		case CombatCharacterPresets.Gorilla:
			return 250 + bonusHealth;
		}
		return 1;
	}

	public static int GetCharacterMaxEnergy(CombatCharacterPresets characterType){
		switch (characterType) {
		case CombatCharacterPresets.BobbyBard:
			return 200;
		case CombatCharacterPresets.CharlieCleric:
			return 150;
		case CombatCharacterPresets.MabelMage:
			return 130;
		case CombatCharacterPresets.PamelaPaladin:
			return 60;
		case CombatCharacterPresets.WalterWizard:
			return 150;
		case CombatCharacterPresets.SusanShapeShifter:
			return 120;
		case CombatCharacterPresets.Gorilla:
			return 150;
		}
		return 1;
	}

	public static List<CombatAbility> GetCharacterAbilities (CombatCharacterPresets characterType){
		List<CombatAbility> abilities = new List<CombatAbility> ();
		switch (characterType) {
		case CombatCharacterPresets.BobbyBard:
			abilities.Add (new SimpleHeal (30, 50, 40, "Basic Heal"));
			abilities.Add( new GiveEffect (new CombatEffect( CombatEffect.effectType.damageDealtModifier, 3, damageType : "melee", modifier : 1.5f), 30, true, "Melee Buff"));
			break;
		case CombatCharacterPresets.CharlieCleric:
			abilities.Add (new SimpleHeal (30, 50, 40, "Basic Heal"));
			abilities.Add (new SimpleHeal (80, 100, 80, "Big Heal"));
			break;
		case CombatCharacterPresets.MabelMage:
			abilities.Add (new SimpleAttack (60, 80, "melee", 40, "Heavy Strike"));
			abilities.Add (new SimpleAttack (65, 75, "magic", 40, "Ethereal Projectile"));
			break;
		case CombatCharacterPresets.PamelaPaladin:
			abilities.Add (new SimpleAttack (60, 80, "melee", 40, "Heavy Strike"));
			abilities.Add (new SimpleAttack (80, 100, "melee", 80, "Epic Strike"));
			break;
		case CombatCharacterPresets.WalterWizard:
			abilities.Add (new SimpleAttack (60, 70, "fire", 30, "Fireball"));
			abilities.Add (new SimpleAttack (65, 100, "electric", 70, "Lightning Strike"));
			break;
		case CombatCharacterPresets.SusanShapeShifter:
			abilities.Add (new SelfEffect (new CombatEffect (CombatEffect.effectType.damageTakenModifier, 3, damageType : "melee", modifier : 0.2f), 40, "Skin of Steel"));
			abilities.Add (new SelfEffect (new CombatEffect (CombatEffect.effectType.damageDealtModifier, 3, damageType : "melee", modifier : 4f), 40, "Knives For Hands"));
			break;
		case CombatCharacterPresets.Goose:
			break;
        case CombatCharacterPresets.ViceChancellor:
            break;
		case CombatCharacterPresets.Gorilla:
			abilities.Add (new SimpleAttack (90, 200, "melee", 50, "Rip"));
			abilities.Add (new SimpleAttack (120, 180, "melee", 50, "Tear"));
			break;
		}
		return abilities;
	}

	/// <summary>
	/// [EXTENSION] - Add bonusAttack to max and min stats for any non enemy tpes
	/// </summary>
	/// <returns>The character's basic attack</returns>
	/// <param name="characterType">The character type</param>
	public static CombatAbility getCharacterBasicAttack(CombatCharacterPresets characterType){
		switch (characterType) {
            case CombatCharacterPresets.ViceChancellor:
                return new SimpleAttack(60, 120, "melee", 0);
		case CombatCharacterPresets.Goose:
			return new SimpleAttack (20, 30, "melee", 0);
		default:
			return new SimpleAttack (20 + bonusAttack, 30 + bonusAttack, "melee", 0);
		}
	}

	public static Dictionary<string, List<Sprite>> getCharacterSprites(CombatCharacterPresets characterType){
		Dictionary<string, List<Sprite>> sprites = new Dictionary<string, List<Sprite>> ();
		List<Sprite> frames = new List<Sprite> ();
		switch (characterType) {
		case CombatCharacterPresets.BobbyBard:
			frames = new List<Sprite> ();
			frames.Add (Resources.Load<Sprite> ("Sprites/Character 6/F4"));
			sprites.Add ("base", frames);
			frames = new List<Sprite> ();
			frames.Add (Resources.Load<Sprite> ("Sprites/Character 6/F5"));
			frames.Add (Resources.Load<Sprite> ("Sprites/Character 6/F6"));
			sprites.Add ("attack", frames);
			break;

		case CombatCharacterPresets.CharlieCleric:
			frames = new List<Sprite> ();
			frames.Add (Resources.Load<Sprite> ("Sprites/Character 4/D4"));
			sprites.Add ("base", frames);
			frames = new List<Sprite> ();
			frames.Add (Resources.Load<Sprite> ("Sprites/Character 4/D7"));
			frames.Add (Resources.Load<Sprite> ("Sprites/Character 4/D6"));
			sprites.Add ("attack", frames);
			break;
		
		case CombatCharacterPresets.MabelMage:
			frames = new List<Sprite> ();
			frames.Add (Resources.Load<Sprite> ("Sprites/Character 2/A4"));
			sprites.Add ("base", frames);
			frames = new List<Sprite> ();
			frames.Add (Resources.Load<Sprite> ("Sprites/Character 2/A5"));
			frames.Add (Resources.Load<Sprite> ("Sprites/Character 2/A6"));
			sprites.Add ("attack", frames);
			break;
		
		case CombatCharacterPresets.PamelaPaladin:
			frames = new List<Sprite> ();
			frames.Add (Resources.Load<Sprite> ("Sprites/Character 5/E4"));
			sprites.Add ("base", frames);
			frames = new List<Sprite> ();
			frames.Add (Resources.Load<Sprite> ("Sprites/Character 5/E5"));
			frames.Add (Resources.Load<Sprite> ("Sprites/Character 5/E6"));
			sprites.Add ("attack", frames);
			break;
		
		case CombatCharacterPresets.SusanShapeShifter:
			frames = new List<Sprite> ();
			frames.Add (Resources.Load<Sprite> ("Sprites/Character 3/B4"));
			sprites.Add ("base", frames);
			frames = new List<Sprite> ();
			frames.Add (Resources.Load<Sprite> ("Sprites/Character 3/B5"));
			frames.Add (Resources.Load<Sprite> ("Sprites/Character 3/B6"));
			sprites.Add ("attack", frames);
			break;
		
		case CombatCharacterPresets.WalterWizard:
			frames = new List<Sprite> ();
			frames.Add (Resources.Load<Sprite> ("Sprites/Character 1/c21"));
			sprites.Add ("base", frames);
			frames = new List<Sprite> ();
			frames.Add (Resources.Load<Sprite> ("Sprites/Character 1/c4"));
			frames.Add (Resources.Load<Sprite> ("Sprites/Character 1/c6"));
			sprites.Add ("attack", frames);
			break;

		case CombatCharacterPresets.Goose:
			frames = new List<Sprite> ();
			frames.Add (Resources.Load<Sprite>("Sprites/Goose"));
			sprites.Add ("base", frames);
			break;

        case CombatCharacterPresets.ViceChancellor:
            frames = new List<Sprite>();
            frames.Add(Resources.Load<Sprite>("Sprites/ViceChancellor/ViceChancellor"));
            sprites.Add("base", frames);
            frames = new List<Sprite>();
            frames.Add(Resources.Load<Sprite>("Sprites/ViceChancellor/ViceChancellor3"));
            frames.Add(Resources.Load<Sprite>("Sprites/ViceChancellor/ViceChancellor2"));
            sprites.Add("attack", frames);
            break;
		
		case CombatCharacterPresets.Gorilla:
			frames = new List<Sprite> ();
			frames.Add (Resources.Load<Sprite> ("Sprites/Gorilla/z4"));
			sprites.Add ("base", frames);
			frames = new List<Sprite> ();
			frames.Add (Resources.Load<Sprite> ("Sprites/Gorilla/z5"));
			frames.Add (Resources.Load<Sprite> ("Sprites/Gorilla/z6"));
			sprites.Add ("attack", frames);
			break;
		}
		return sprites;
	
	}
}

