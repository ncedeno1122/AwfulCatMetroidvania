I enjoyed a long weekend from this project to keep some ideas fresh and work my programming muscles out elsewhere - with some good old ASP.NET tutorials and web development stuff. It's actually been surprisingly fun?
Either way, I'm trying to get some cool work done here today.

---

In any case, I think it's time for a new branch in my Github as I get ready for these special-interaction tiles. Today I want to follow up on some of the R&D done in [[June 29]] about solutions for tile-based collision and things like that. This is the gateway for tiles with special interaction.

So last time, I was experimenting with the instantiated GameObjects with which RuleTiles spawn. The only PROBLEM was that there didn't seem to be any way to know which Tile the GameObject would represent.  In my understanding thus far, there *seems* to be only a reference *from the RuleTile to the GameObject*, but NOT the other way around.

I wanted them to be like the ones from Metroid. In that game, they're truly hidden under another Tile texture for the environment, BUT with a special GameObject whose collision we check for. Then, when a collision is made, depending on the special tile's unique behavior (destructible, fall-through, bombable, etc) and condiions that they react to, then we actually run some behaviors.
The ones from Metroid HAVE to be GameObjects that live on a tile identical to 

I wonder if I can check for tile-specific collision from the Tilemap collider... That might suck though.

The majority of my "problem" is a design one. I'd like to keep these special Tiles on a separate Tilemap. The normal (what's currently called PhysEnviroTilemap) tilemap would  technically have all of its secrets revealed and all that stuff as it wouldn't include special tiles.

HOWEVER, there are solutions that I could have for the most effectiveness. As I see currently, the same RuleTiles on different Tilemaps will NOT blend together or do the fun RuleTile thing that makes them look nice.
**IF I were to make some sort of LevelTilemapManager that manages the tilemaps in my levels by holding references to all of them, then I could dynamically break and restore tiles as I want. This may also allow for the destruction and generation of rooms according to a data (which me likes >:D)** THOUGH I AM FEARFUL THAT THIS MAY INTRODUCE BUGS THAT I DO NOT WANT I AM IN FACT VERY SCARED. But I haven't done anything to try it yet so. Nothing risked, nothing gained, let's GO!

In essence, I want to be able to destroy tiles from specific tilemaps depending on data from the GameObject that I have.

---

Ok, so let's take it back. What do I ACTUALLY want to try to make?

First things first, I want to make a RuleTile that represents some type of special level tile (temp name). I just need to make it have some GameObject with a sprite that signifies the Tile's behavior, no TileSprite needed. This GameObject will have a BoxCollider2D that will listen for collision info and stuff like that and do something.
When this something happens, I want to call some method to destroy the PhysEnviroTilemap tile at that position. However, I want to defer this behavior to happen in the LevelTilemapManager.

**I SHOULD SEE ABOUT HOW TO AVOID CONSTANTLY COLLIDING WITH THE TILEMAP COLLIDER! Might have something to do with different Layers.**

Second thing is, I need a LevelTilemapManager script to handle the wrangling of all of these fun tiles in different tilemaps. At the present, I only really need to manage the LevelTileTilemap and the PhysEnviroTilemap, handling tile deletion and other things like that.

These two things should allow me to mock up the basic behavior that I want. Let's do this.

---

I must confess that I am so, SO dangerously tempted to try and make some serializable formatting to create levels from. Images, JSON, or some other workflow that I could hook up, OOH I'm just so dangerously tempted to try something like that... But I suppose the editor is what that's for..... Sigh... It would be so cool though.

In any case, I'm trying to think in terms of the Single Responsibility Principle as I design my LevelTilemapManager class.
The only thing is that I'm trying to figure out is how to RESTORE tiles after deleting them. I can do this with a dictionary of deleted tiles for easy management and lookup, *but it suuure would be cool to reference another pre-loaded resource to determine what that tile should be*. It'd be inefficient though, so I'll have to stick to this approach.

This just in, after running some tests in Start(), this new DeletePhysEnviroTile seems to work so far, even if it is a bit of a mouthful. In any case, we can effectively remember what TileBase tile we're doing, which rocks! I'd have to test this on tiles that AREN'T RuleTiles.

---

Wouldn't it be cool to call some event or static function that occurs every time a LevelTile has its activation condition met, that simply sends over the position of the LevelTile on the Tilemap? That way, we need only check what Tile is at that position in the LevelTilemapManager and call the appropriate behavior from the LevelTilemapManager. But... Does this violate the Single Responsibility Principle?
The scope of this script is to manage the LevelTiles and their interactions with the PhysEnviroTilemap.

---

Looks like the new RestorePhysEnviroTileAt function is working well after some testing, very nice! :D

Now that I have tiles being deletable and restoreable, it's time to make a coroutine out of this.

BUT WAIT, I **shouldn't** put this coroutine in the LevelTilemap. I instead want to do any coroutine-specific thing in the LevelTilemapManager, but in the specific tiles themselves. Instead I will just want to notify the manager script via an event or something what I need from it.

With that, I suppose, I need to actually implement these events. Now, Unity or C# events...
C# Events it is :D!

Now, let's see what I need to make. I need to make the RuleTile that holds the GameObject on it, and THEN I need to make the script for that GameObjectInstance.

---

Well, I got it mostly working minus some extremely fine-tooth testing. I'm really glad this seems to work so far.

I just added a quick little particle system to the Breakable block prefab. I'm glad I got that done, that's very pleasing!