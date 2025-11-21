using UnityEngine;
 using System;
 using System.Collections.Generic;
 using Newtonsoft.Json;

public class MyData
{
       [JsonProperty("player_id")]
       public string playerId;
       public string nickname;
       [JsonProperty("account_info")]
       public AccountInfo accountInfo;
       public Character character;
       [JsonProperty("quests_active")]
       public List<QuestActive> questsActive;
       public Inventory inventory;
       [JsonProperty("match_history")]
       public List<MatchHistory> matchHistory;
       [JsonProperty("settings_cfg")]
       public SettingsConfig settingsConfig;
   }
   
   [Serializable]
   public class AccountInfo
   {
       [JsonProperty("email_addr")]
       public string email;
       [JsonProperty("created_on")]
       public string creationDate;
   }
   
   [Serializable]
   public class Character
   {
       [JsonProperty("char_id")]
       public string charId;
       [JsonProperty("char_name")]
       public string charName;
       [JsonProperty("class-type")]
       public string classType;
       [JsonProperty("level_cur")]
       public int currentLevel;
       [JsonProperty("xp_next_lvl")]
       public int xpToNextLevel;
       public Stats stats;
       public Equipment equipment;
   }
   
   [Serializable]
   public class Stats
   {
       [JsonProperty("hp_max")]
       public int hp;
       [JsonProperty("mp_max")]
       public int mp;
       [JsonProperty("atk_pwr")]
       public float atk;
       [JsonProperty("def_rate%")]
       public float def;
       [JsonProperty("crit-chance%")]
       public float critChance;
   }
   
   [Serializable]
   public class Equipment
   {
       [JsonProperty("weapon_slot")]
       public WeaponSlot weaponSlot;
       [JsonProperty("armor_slot")]
       public ArmorSlot armorSlot;
   }
   
   [Serializable]
   public class WeaponSlot
   {
       [JsonProperty("item_code")]
       public string itemCode;
       [JsonProperty("name_txt")] 
       public string name;
       public string rarity;
       [JsonProperty("dmg_val")] 
       public int damage;
       [JsonProperty("fireRate/sec")] 
       public float fireRate;
   }
   
   [Serializable]
   public class ArmorSlot
   {
       [JsonProperty("item_code")]
       public string itemCode;
       [JsonProperty("name_txt")] 
       public string name;
       public string rarity;
       [JsonProperty("def_bonus")] 
       public int defense;
       [JsonProperty("resist-map")] 
       public ResistMap resistances;
   }
   
   [Serializable]
   public class ResistMap
   {
       public int fire;
       public int ice;
       public int shock;
   }
   
   [Serializable]
   public class QuestActive
   {
       [JsonProperty("q_id")]
       public string questId;
       [JsonProperty("qTitle")]
       public string questTitle;
       [JsonProperty("progress-step")]
       public int progressStep;
       public List<Objective> objectives;
   }
   
   [Serializable]
   public class Objective
   {
       [JsonProperty("desc")]
       public string description;
       public bool done;
   }
   
   [Serializable]
   public class Inventory
   {
       [JsonProperty("bag_main")]
       public List<BagItem> bagMain;
       [JsonProperty("bag_resources")]
       public List<ResourceItem> bagResources;
   }
   
   [Serializable]
   public class BagItem
   {
       [JsonProperty("itm_id")]
       public string itemId;
       [JsonProperty("itm_name")]
       public string itemName;
       [JsonProperty("qty")]
       public int quantity;
       [JsonProperty("extra-vals")]
       public ExtraValues extraValues;
   }
   
   [Serializable]
   public class ExtraValues
   {
       [JsonProperty("energy_lvl")]
       public int energyLevel;
   }
   
   [Serializable]
   public class ResourceItem
   {
       [JsonProperty("res_type")]
       public string resourceType;
       public int units;
   }
   
   [Serializable]
   public class MatchHistory
   {
       [JsonProperty("match_id")]
       public string matchId;
       [JsonProperty("start_time_unix")]
       public long startTimeUnix;
       [JsonProperty("duration_sec")]
       public int durationSeconds;
       public string result;
       public Score score;
   }
   
   [Serializable]
   public class Score
   {
       public int kills;
       public int assists;
       public int deaths;
   }
   
   [Serializable]
   public class SettingsConfig
   {
       public Audio audio;
       public Graphics graphics;
       [JsonProperty("controls_map")]
       public ControlsMap controlsMap;
   }
   
   [Serializable]
   public class Audio
   {
       [JsonProperty("vol_master")]
       public float volumeMaster;
       [JsonProperty("vol_fx")]
       public float volumeFx;
       [JsonProperty("vol_music")]
       public float volumeMusic;
   }
   
   [Serializable]
   public class Graphics
   {
       [JsonProperty("quality_lvl")]
       public string qualityLevel;
       [JsonProperty("fov_angle")]
       public int fovAngle;
   }
   
   [Serializable]
   public class ControlsMap
   {
       [JsonProperty("sens_mouse")]
       public float mouseSensitivity;
       public Keybinds keybinds;
   }
   
   [Serializable]
   public class Keybinds
   {
       [JsonProperty("move_forward")]
       public string moveForward;
       [JsonProperty("move_back")]
       public string moveBack;
       [JsonProperty("special_skill")]
       public string specialSkill;
       [JsonProperty("ultimate_skill")]
       public string ultimateSkill;
   }
