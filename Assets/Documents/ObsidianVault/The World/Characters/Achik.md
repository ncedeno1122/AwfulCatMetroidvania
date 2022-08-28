# Achik

## Intro
Son of the son of the Sun (the king's son) and a priest in training, Achik is devoted to improving the world as best as he can. Armed with a myriad of mystical techniques and knowledge, he channels the power of the Sun for his magic.

---

## Gameplay
Achik is a ranged character almost primarily, whose priestly talents enhance his normally mundane physicality. Using spells to enhance his jumps, range, moves, and more, Achik's kit relies on his *Attiniy* passive (translates to "capability" in Quechua). Without *Attiniy*, Achik relies on his priest's knife and other physical implements to supplement his missing magical power - not reliably, however. WITH plenty of *Attiniy*, he can make use of all of the fun abilites he wants, and be a powerful character to play.

Achik should play like a ranged unit who relies on ranged attacks, with a weaker close-range game. This is why I've implemented his priest knife basic attack set, so that he may rely on a limited knife moveset. It should serve, however, as a backup for a lack of *Attiniy* spells, which he relies on more.

#### Passive Abilities
- Resources
	- Attiniy (Solar Magic)
		- Refreshed by:
			- Prayer ability
			- Damaging foes
- Terrain Immunities:
	- Solar
	- Sacral (Heavily Spiritual / Complex areas)

#### Basic Attacks (Priest's Knife)
| **Directional Input** | **Grounded? (G/A)** | **InputType** | _MoveName_ | **Description** |
|---|---|---|---|---|
| Neutral | G | SingleTap | Slash | A small horizontal slash with Achik's priest knife forward. |
| Down | G | SingleTap | Crouch Stab | A small, forward stab from a crouched position. |
| Up | G | SingleTap | Upwards Stab | A small stab directed directly above Achik. |
| Down | A | SingleTap | Falling Stab | Falls with the priest's knife leading downwards. |
| Neutral | A | SingleTap | Air Slash | A small horizontal slash in the air. |
| Up | A | SingleTap | Upwards Air Stab | A small stab upwards in the air. |

#### Skills
| **Directional Input** | **Grounded? (G/A)** | **InputType** | _SkillName_ | **Description** |
|---|---|---|---|---|
| Up | G | SingleTap | **_Bless_** | Performs a blessing, triggering interactions in BlessListeners.<br>Reflects projectiles? |
| Up | G | Hold | **_Spirit Form_** | Enters Spirit Form, unrestricted air movement and smaller hitbox for a few seconds. |
| Up | A | Hold | **_Spirit Form_** | (Same as Above) |
| Down | G | Hold | **_Prayer_** | Prays, restoring precious Attiniy. |
| Down | A | SingleTap | **_Falling Stab_** | Points the knife downwards and falls quicker. If an enemy is hit, Achik will bounce upwards. |
| Horizontal / Any | G | Hold + FreeAim | **_Knife Throw / Return_** | Enters a state to throw Achik's priest knife in any direction. If the knife is OUT, it will fly back to Achik. |
| Horizontal / Any | A | Hold + FreeAim | **_Knife Throw Air / Return_** | Enters a state to throw Achik's priest knife in any direction while airborne. If the knife is OUT, it will fly back to Achik. |
| Horizontal / Any | G | SingleTap + FreeAim | **_Energy Ball_** | Fires a blast of solar energy using Attiniy. |
| Horizontal / Any | A  | SingleTap + FreeAim | **_Energy Ball Aerial_** | Fires a blast of solar energy using Attiniy in the air. |
| Horizontal | G | Hold | **_Solar Beam_** | Fires a medium-range, sustained beam of Attiniy that hurts enemies and can trigger things (melt?) |
|  |  |  |  |  |

^8ec086

