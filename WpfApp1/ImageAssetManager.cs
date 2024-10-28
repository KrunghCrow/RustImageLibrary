﻿using System.Collections.Generic;

public class ImageAssetManager
{
    private readonly Dictionary<string , string> imageAssetPaths;

    public ImageAssetManager()
    {
        imageAssetPaths = new Dictionary<string , string>
        {
            // <------------------------------------------------------------------------------------------------------- Avatars
            { "AttackHelicopter.icon", "assets/content/vehicles/attackhelicopter/AttackHelicopter.icon.png" },
            { "BanditGuardAvatar", "assets/rust.ai/agents/npcplayer/humannpc/banditguard/BanditGuardAvatar.png" },
            { "BearAvatar", "assets/rust.ai/agents/bear/BearAvatar.png" },
            { "BoarAvatar", "assets/rust.ai/agents/boar/BoarAvatar.png" },
            { "BradleyAvatar", "assets/prefabs/npc/m2bradley/BradleyAvatar.png" },
            { "CactusAvatar", null },
            { "CargoShipAvatar", "assets/content/vehicles/boats/cargoship/CargoShipAvatar.png" },
            { "complete_car.icon", null },
            { "ChickenAvatar", "assets/rust.ai/agents/chicken/ChickenAvatar.png" },
            { "DwellerAvatar", "assets/rust.ai/agents/npcplayer/humannpc/tunneldweller/DwellerAvatar.png" },
            { "GingerbreadManAvatar", null },
            { "HeavyScientistAvatar", "assets/rust.ai/agents/npcplayer/humannpc/scientist/HeavyScientistAvatar.png" },
            { "HorseAvatar_Appaloosa", null },
            { "HorseAvatar_Bay", null },
            { "HorseAvatar_BlackThoroughbred", null },
            { "HorseAvatar_Bucksin", null },
            { "HorseAvatar_Chestnut", null },
            { "HorseAvatar_DappleGrey", null },
            { "HorseAvatar_Piebald", null },
            { "HorseAvatar_Pinto", null },
            { "HorseAvatar_RedRoan", null },
            { "HorseAvatar_WhiteThoroughbred", null },
            { "locomotive.entity.icon", null },
            { "PatrolHelicopterAvatar", "assets/prefabs/npc/patrol helicopter/PatrolHelicopterAvatar.png" },
            { "PeacekeeperAvatar", "assets/rust.ai/agents/npcplayer/humannpc/scientist/PeacekeeperAvatar.png" },
            { "PolarBearAvatar", "assets/rust.ai/agents/bear/PolarBearAvatar.png" },
            { "Rowboat.icon", "assets/content/vehicles/boats/rowboat/Rowboat.icon.png" },
            { "ScarecrowAvatar", "assets/prefabs/npc/scarecrow/ScarecrowAvatar.png" },
            { "ScientistAvatar", "assets/rust.ai/agents/npcplayer/humannpc/scientist/ScientistAvatar.png" },
            { "ScientistNVGAvatar", "assets/rust.ai/agents/npcplayer/humannpc/scientist/ScientistNVGAvatar.png" },
            { "sentry.scientist.static.icon", "assets/content/props/sentry_scientists/sentry.scientist.static.icon.png" },
            { "SharkAvatar", null },
            { "Snowmobile.icon", null },
            { "StagAvatar", "assets/rust.ai/agents/stag/StagAvatar.png" },
            { "SubmarineDuo.entity.icon", null },
            { "SubmarineSolo.entity.icon", null },
            { "TomahaSnowmobile.icon", null },
            { "TrainWagon.icon", null },
            { "tugboat.icon", "assets/content/vehicles/boats/tugboat/tugboat.icon.png" },
            { "UnderwaterDwellerAvatar", "assets/rust.ai/agents/npcplayer/humannpc/underwaterdweller/UnderwaterDwellerAvatar.png" },
            { "WolfAvatar", "assets/rust.ai/agents/wolf/WolfAvatar.png" },
            { "workcart.entity.icon", null },
            // <------------------------------------------------------------------------------------------------------- Backgrounds : Found in the gamefiles
            { "ItemBackground", null },
            { "UI.Background.Tile", null },
            // <------------------------------------------------------------------------------------------------------- Custom : steam workshop skins (for use of Avatars as skinid)
            { "Boss_small_Avatar2", "3348953744" },
            { "Bradley_Guard_avatar", "3350450613"},
            { "JunkpileNpc", "3349208089"},
            { "PumpkinHead", "3353252003"},
            { "zombieavatar", "3348694705"},
            { "ZombieRocks", "3348761740"},
            // <------------------------------------------------------------------------------------------------------- Plugins : Custom steam workshop skins (for use of Plugin icons as skinid)
            { "AirEvent-Plugin" , "3350914432"},
            { "AlphaAnimals icon new3-512" , "3350306166"},
            { "BossMonster-Plugin" , "3351500714"},
            { "Caravan-Plugin" , "3350893464"},
            { "Convoy-plugin" , "3350873031"},
            { "HarborEvent-Plugin" , "3350905658"},
            { "JunkpileNpc-plugin", null},
            { "SatDishEvent-plugin2", "3349456852"},
            { "waterevent-plugin1" , "3349460078"},
            // <------------------------------------------------------------------------------------------------------- Icons : From Rust gamefiles
            { "add", "assets/icons/add.png"},
            { "air_tank0", null},
            { "air_tank1", null},
            { "air_tank2", null},
            { "air_tank3", null},
            { "air_tank4", null},
            { "air_tank5", null},
            { "ammunition", "assets/icons/ammunition.png"},
            { "arrow_right","assets/icons/arrow_right.png"},
            { "authorize", "assets/icons/authorize.png"},
            { "bite", "assets/icons/bite.png"},
            { "bleeding", "assets/icons/bleeding.png"},
            { "blueprint","assets/icons/blueprint.png"},
            { "blunt_0", "assets/icons/blunt.png"},
            { "boosts", null},
            { "bp-lock", "assets/icons/bp-lock.png"},
            { "broadcast", "assets/icons/broadcast.png"},
            { "bullet", "assets/icons/bullet.png"},
            { "check", "assets/icons/check.png"},
            { "Checkmark", null},
            { "chevron_down", null},
            { "chevron_right_0", null},
            { "chinook_map_blades", "assets/icons/chinook_map_blades.png"},
            { "chinook_map_body", "assets/icons/chinook_map_body.png"},
            { "circle_closed", "assets/icons/circle_closed.png"},
            { "circle_closed_toEdge", "assets/icons/circle_closed_toedge.png"},
            { "circle_closed_white", null },
            { "circle_closed_white_toEdge", null},
            { "circle_open", "assets/icons/circle_open.png" },
            { "clan", null },
            { "close", "assets/icons/close.png"},
            { "cold", "assets/icons/cold.png"},
            { "community_servers", "assets/icons/community_servers.png" },
            { "compass_strip_hd", "assets/content/ui/gameui/compass/compass_strip_hd.png"},
            { "construction", "assets/icons/construction.png" },
            { "cooking", "assets/icons/cooking.png" },
            { "crate", "assets/icons/crate.png"},
            { "cup_water", "assets/icons/cup_water.png"},
            { "deauthorize", "assets/icons/deauthorize.png" },
            { "demolish", "assets/icons/demolish.png"},
            { "demolish_cancel", "assets/icons/demolish_cancel.png"},
            { "dir_left", null},
            { "dir_right", null},
            { "discord 1", "assets/icons/discord 1.png"},
            { "download", "assets/icons/download.png"},
            { "drone", null },
            { "drop", "assets/icons/drop.png" },
            { "DropdownArrow", null },
            { "drowning", "assets/icons/drowning.png" },
            { "eat", "assets/icons/eat.png" },
            { "electric_0", "assets/icons/electric.png" },
            { "elevator_down", null },
            { "elevator_up", null },
            { "enter", "assets/icons/enter.png" },
            { "exit", "assets/icons/exit.png"},
            { "explosion", "assets/icons/explosion.png" },
            { "extinguish", "assets/icons/extinguish.png" },
            { "facebook-box", "assets/icons/facebook-box.png" },
            { "facepunch", "assets/icons/facepunch.png" },
            { "fall", "assets/icons/fall.png" },
            { "Favourite_active", null },
            { "Favourite_inactive", null },
            { "favourite_servers", "assets/icons/favourite_servers.png"},
            { "ferry", null },
            { "file", "assets/icons/file.png"},
            { "fire", null },
            { "fog_4", "assets/icons/fog.png" },
            { "folder", "assets/icons/folder.png" },
            { "folder_up", "assets/icons/folder_up.png" },
            { "food_cooked", null},
            { "food_raw", null},
            { "fork_and_spoon", "assets/icons/fork_and_spoon.png"},
            { "freezing", "assets/icons/freezing.png" },
            { "friends_servers", "assets/icons/friends_servers.png" },
            { "fun", null},
            { "fun_alt", null},
            { "gear", "assets/icons/gear.png" },
            { "gem", null },
            { "gesture-clap", null},
            { "gesture-friendly", null},
            { "gesture-hurry", null},
            { "gesture-ok-2", null},
            { "gesture-point", null},
            { "gesture-raise-the-roof", null},
            { "gesture-shrug", null},
            { "gesture-silly-dance-1-alternative", null},
            { "gesture-silly-dance-2", null},
            { "gesture-thumbs-down", null},
            { "gesture-thumbs-up", null},
            { "gesture-victory", null},
            { "gesture-wave", null},
            { "hand-looting", null},
            { "health", "assets/icons/health.png" },
            { "history_servers", "assets/icons/history_servers.png"},
            { "home", "assets/icons/home.png" },
            { "horse_ride", "assets/icons/horse_ride.png" },
            { "horse_ride_2", null },
            { "hot", "assets/icons/hot.png" },
            { "Hypnotisez", null },
            { "ice.pack.icon", null },
            { "icon-focus", null},
            { "icon-locked", null },
            { "icon-map", null },
            { "icon-map_circle-outline", null},
            { "icon-map_diamond-outline", null },
            { "icon-map_dollar", null },
            { "icon-map_gun", null},
            { "icon-map_home", null  },
            { "icon-map_loot", null },
            { "icon-map_parachute", null },
            { "icon-map_rock", null },
            { "icon-map_scope", null },
            { "icon-map_shield", null },
            { "icon-map_skull", null },
            { "icon-map_sleep", null },
            { "icon-map_waypoint", null },
            { "icon-map_zzz", null },
            { "icon-submarine", null },
            { "icon-unlocked", null },
            { "icon-water-1", null},
            { "icon-water-2", null},
            { "icon-water-3", null},
            { "icon-water-4", null},
            { "icon-water-5", null},
            { "icon-water-6", null},
            { "icon-water-7", null},
            { "icon-water-8", null},
            { "icon_age", null},
            { "icon_clear", null},
            { "icon_firework", null},
            { "icon_firework_disabled", null},
            { "icon_ground", null},
            { "icon_light", null},
            { "icon_overall", null},
            { "icon_stage", null},
            { "icon_temperature", null},
            { "icon_water-intake", null},
            { "icon_water-saturation", null},
            { "icon_yield", null},
            { "ignite_0", "assets/icons/ignite.png" },
            { "info", "assets/icons/info.png" },
            { "input", null },
            { "InputFieldBackground", null },
            { "instagram-logo", null },
            { "insurance_icon", null },
            { "iscooking", "assets/icons/iscooking.png" },
            { "isonfire", "assets/icons/isonfire.png" },
            { "Knob", null },
            { "lan_servers", "assets/icons/lan_servers.png" },
            { "level_metal", "assets/icons/level_metal.png" },
            { "level_stone", "assets/icons/level_stone.png" },
            { "level_top", "assets/icons/level_top.png" },
            { "level_wood", "assets/icons/level_wood.png" },
            { "lick", "assets/icons/lick.png" },
            { "light", null },
            { "light_campfire", "assets/icons/light_campfire.png" },
            { "lightbulb", "assets/icons/lightbulb.png" },
            { "loading", "assets/icons/loading.png" },
            { "lungs", null },
            { "maparrow", "assets/icons/maparrow.png" },
            { "Marker", null },
            { "MarkerCurrent", null },
            { "maximum", "assets/icons/maximum.png" },
            { "medical", "assets/icons/medical.png" },
            { "menu_dots", "assets/icons/menu_dots.png" },
            { "mission_icon", null },
            { "mission_provider", null },
            { "mlrs_border_double", null },
            { "mlrs_border_single", null },
            { "mlrs_diagonal_lines", null },
            { "mlrs_dotted_circle", null },
            { "mlrs_scanlines", null },
            { "mlrs_target_circle_fade", null },
            { "mlrs_target_cross", null },
            { "modded_servers", "assets/icons/modded_servers.png" },
            { "nextframe", null },
            { "nude_icon", null },
            { "occupied", "assets/icons/occupied.png" }
        };
    }

    public string GetAssetPath(string imageName)
    {
        if (imageAssetPaths.TryGetValue(imageName , out string assetPath))
        {
            return assetPath;
        }
        return null;
    }
}
