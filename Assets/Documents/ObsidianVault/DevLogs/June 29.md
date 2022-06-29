# June 29
## Picking Up Where I Left Off
I wanted to piggyback a bit off of my work late last night on the ideas for implementing special tiles (from [[June 28]]).

So I just had a quick little idea AGAIN, on the sort of idea of this. I *know* that there are going to have to be certain tiles that are triggers that react to the Player (or more), and I was thinking that I can check and react on that collision information IN the Player class. Essentially, if we hit some special tile or something like that, trigger some handling information for the Tilemap at that collision's position. Essentially, it'd be the Player's job to inform the Tilemap, which would then trigger the behavior to happen in a given Tile. Just a thought.

Now **IF** the instantiated GameObject on a given RuleTile will be instantiated in the EDITOR, as opposed to during runtime, then I should be good to make a GameObject Prefab that has what I need to distinguish certain tiles from one another. I'll have to see how this works, exactly, though. No better time than the present, I suppose (or before my next teaching session).

---

Okay, I mocked up an example with a RuleTile and a script that responds to the Trigger collider events, works well. The only thing is that I don't seem to have control of the actual cloned GameObject on the tile unless I was to query the Tilemap for the instantiated object at a given location. So, it'd be hard for me to manually set the behavior of these triggers without something like a unique ID system or something like that. For example, I could make a static manager class that maintains a list of the rule tiles that have instantiated GameObjects and not only assign them an ID, but link that ID to a specific behavior. 
This doesn't seem like the best design though, I'm skeptical... Lookup stuff like that is cool but I'd like to avoid the hassle of it if possible.

What's more, I **could** query the GameObject by POSITION rather than anything else, which is also a way to make them unique and use less data...

But I have to establish exactly what I want here. That way I don't drown in the hypotheticals like I'm starting to.

What I *want* is to have a set of special tiles that can independently handle collision-based events (ie: doors, destructible blocks, fall-through blocks). Kinda of Spelunky-style interaction on the doors, but that interaction style could be a lever or something too.

I WANT to be able to trigger the collision events PER tile so I can create scripts to customize the behavior. Let's say I have different objectives for progression, like gems that I can slot into walls. Those would likely have to react to things the way I have now with the instantiated GameObject.
Now, let's say that I have something like a door, that needs to take us to the next room over. We'd need to connect to some other door tile on another map or something like that (then unload the rooms we don't have a direct connection to :D), but that's INCREDIBLY  individual behavior. I don't think there's any way around directly linking those to one another. That's something I'd like to use GameObjects for, but it may be possible to do another way as well...

For each LEVEL, there's a chance that I could do the idea I was describing before (lookup via tile location / ID and then trigger that Tile's behavior. If I was to trigger an OnDoor event or something that sent the location of the door tile, I could look that up in a Dictionary of locations and the associated behavior with that tile...

Hmm, but I REALLY want a way to control those instantiated GameObjects on the RuleTiles, even to have them in the inspector would be brilliant. In essence, the EASY part is indexing the Tiles and all that stuff, but having more sophisticated ways to connect different rooms via doors is intriguing.

According to the Unity docs, "This [GameObject](https://docs.unity3d.com/ScriptReference/GameObject.html) will be instantiated at the start of the Scene at the [Tile](https://docs.unity3d.com/ScriptReference/Tilemaps.Tile.html)" (https://docs.unity3d.com/ScriptReference/Tilemaps.Tile-gameObject.html). So we don't have access to it in the editor because it's instantiated at Start...

Yet perhaps, I could create some way to organize data for Tiles at specific places. For example, ye olde CSV file of Door Tiles in the game and where they connect to. Perhaps there, at the press of a button or something, I could try and read through the Tiles in the tilemap and figure out where they are. This behavior could be read through and hooked up properly at runtime, but I'm not sure this is the best solution... Sigh.......

But you know how in Metroid, the ENTIRE room blacks out as Samus travels through a door and loads the next room? Maybe the door IS a GameObject that stays connecting the maps as the Tilemaps fade to black and load the next room? It's a possibility that that's how that might work... That said, I could just make doors normal, Hierarchically-organized GameObjects in the Editor as opposed to runtime.

---

Make no mistake, however. I COULD just make them normal old GameObjects that I could place the normal way. I could even do an OnValidate and align them to the Tilemap they belong to, at that cell center.
But there's something about the convenience of working SOLELY within the Tilemap to do these things that's so... desirable. I don't want to have to mix and match, I'd like to keep things organized if I can...

So what I'm gathering is a couple things.... I don't know a single, decisive approach about the behavior of doors that I feel confident in, but other less complicated things like switches and things like that could be more repeatable behavior... NO, I'm WRONG AGAIN.

Okay, the lookup thing is sounding pretty attractive, not gonna lie. I'm dying to sink my teeth into it. I'm thinking if I were to include things like chests that have certain contents, I could just lookup that information per-chest, and hook up their contents and behavior via chest ID or tile location or something like that...
Doors were the same way for me... They too need a way to interact with the Player, and trigger some instance-specific behavior.

The main *thing* for me is the workflow around these special tiles. It'd be hard to distinguish one from another because they're not instantiated in the Editor for convenience. It might be difficult to organize them with an effective naming scheme ANYWAY, but I still want to try organization.

---

You know what's funny is that I'm trying to make this work with the least work possible in a sense, with the base stuff available to me (just a basic rule tile and all that). If I wanted to get crazy (which I usually do), I can literally just make my own ScriptableTile that has behavior like what I want. I think I **SHOULD** do that to see if I can't get the instantiated GameObjects to exist in the editor like I want them to, in which case I pretty much win with my previous approach.

Dude I'm braining so hard right now... I'm thinking about making Inspector Tools to hook doors up to one another, and creating ScriptableObject instances for my doors and chests that holds their state so the Tile merely provides an interface in which to modify that... I'm in deep but I know I have to pull it back.

It's getting close to my teaching time and I need some water so I'll be back in a moment...

It might be expensive to maintain scriptableObjects per door that lead to their next location, so I might instead try to maintain information on the room in a ScriptableObject instead. That way, I can mark all doors within the room with a dictionary and do the old lookup strategy elsewhere...

Point is so far, that there's just a lot of design decision that I have to make regarding the style of my game, how it's played and all that stuff, that could illuminate more of the technical solution that I'm looking for. 