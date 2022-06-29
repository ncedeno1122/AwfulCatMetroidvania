# First Note!
**Now** this project is official, lol. I usually always make an Obsidian vault for the projects that I post so I can always try to maintain my scoping and goals when I pick up a project again. Here, I aim to do so aggressively as this is the main project I aim to develop.

## Today's Work
Today I worked a lot in the morning and afternoon. I added the StoneBrickTile and ThatchedRoofTile assets, though the latter could probably use more work. What's more, I created a proper background tilemap that simulates parallax to some degree. As well, this note is being written from my laptop - I've uploaded the project to Github and added my yummy documentation with this Obsidian Vault. That's where we are now.
Tonight, before I rested, I changed up the control scheme a bit (D-Pad for movement input on Gamepads) and drew up some windows and doors.

## Next Work to do
I'm **dying** to get work on the interactable tiles I have planned for the game: triggers, the variety of Metroid-esque blocks that break upon being blasted, stood upon, and more things. I REALLY want to do this.

I will likely almost always be tuning my PlayerController script to fine-tune interactions, animations, and things like that to make the player character feel better.

I also want to get a song going for this town area that I'm working on right now. 

---
## Really Late Night Work
I'm up at like 3:32 because AGAIN I just have to fall asleep and take a short nap at like 10-ish, wake up feeling *rested* and **alive** to some extent. I figured that I might as well try to figure something out here.

#### Reading Tile Collision
So I wanted to make some special tiles, like the ones in Metroid, where you can interact with them in a special game. For example, blocks that break when you shoot or stand on them, or when you bomb them or something like that.

I initially wasn't sure how to do this without making a specific tilemap for each type of special tile. However, there MUST be a way to do this differently.

So then, I started thinking about how I might fix this. Perhaps, if I were to make an abstraction for each type of SpecialTile that has OnTriggerEnter, Exit, and Stay methods, along with a unique ID for that tile, I could theoretically collide with, query, and trigger behavior from one Tilemap Collider. This behavior would occur FOR that tile.
	This approach might be fun to program, but I seriously doubt its efficiency. I think that I might need to look into actually placing GameObjects onto the Tilemap and messing with them from there.

Alternatively, I could try and make a RuleTile that spawns a separate GameObject with it, that could imitate the behaviors that I want. Essentially, the Tilemap would be my data entry / simplification solution for adding normal GameObjects on the grid. These GameObjects, which may in turn have collision to function in the manner I want them to, would do decoupled from the Tilemap.
As it turns out, I might be able to make **this** approach work and have a reference to the instantiated object on the RuleTile with this (link: https://docs.unity3d.com/ScriptReference/Tilemaps.Tilemap.GetInstantiatedObject.html).
If this object were to, upon instantiation, save its location on the Tilemap, then I could have real effects like in Metroid. For example, you know how in Metroid, when you break a destructible tile, the tile sprite disappears to show the effect? I could do that by the GameObject's collision and things like that, temporarily removing or deactivating the tiles in other Tilemaps to accurately recreate that effect. That's just what I'm thinking so far though, there's likely still a better way.

In any case, I'm going to commit this and try to rest. Good night!