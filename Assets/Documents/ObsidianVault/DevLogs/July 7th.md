Well, a fun life development occurred from when I went to bed after [[July 6th]]. Unfortunately, I have Covid now.
Unfortunately, I won't stop either . :D! Thank goodness for laptops and also Fire Emblem (and also that one documentary on lobsters) for keeping me afloat as I recover.
In any case,

---

I was having some trouble figuring out what to work on today, but I think I want to try and implement some of the interactive tiles that had written about in [[July 6th#LevelTiles]]. I'm kind of excited to try this sort of thing!

First things first, I need to understand that the PlayerController gameObject is likely going to have to use collision to trigger the interactive tile's effect, based on some new input.

So I'll have to work in the PlayerController to develop some new Interact input action, hook it up, and somehow try to trigger the tile effect of an interactive tile that we're colliding with.

AFTER this, then I'll have to make some sort of LevelTileScriptGO prefab for the interactable tile and then do that script, likely with some active or inactive field.

Should I maintain two-state buttons versus a button that simply calls some action like an event (and defer the consequence of hitting the button to something else?)

Well, I suppose I don't have to choose, I'll just make both and try to pull them up OR together like I did with the BreakableTile components.

In any case, let's try to get this going. I'll start by creating the InputAction and all that.

---

Ooohhhhh wait a second..... As an aside, I wonder if I could refactor and generalize my trigger script from the FallThrough block for the FloorSwitch block? Hmmm..... That'd be interesting to say the least.

They would both have about the same conditions provided I did them in some normal manner...

...Whatever I'm not there yet so I can't care about it right now LOL.

---

Ok I'd run into an issue where my PlayerController with the Rigidbody Collider needed to detect a static trigger collider. Looking it up (https://docs.unity3d.com/Manual/CollidersOverview.html), I don't think that interaction can happen. I may have to add a TriggerCollider to my Player OR see some other way to use the Tile's collision to detect whether the **interaction input** has been done.

Adding another trigger collider to my Player GameObject is certainly a solution, but it feels immoral for some reason.

IF I were to add an IsInteracting field to the PlayerController, like IsGrounded or something, I'd be able to see exactly what it is that I'm doing, AND be able to check from the Tiles...
This seems like the best approach. As said in the Mandalorian, "This is the way."

##### Yummy Delicious Components
Good god do I really want to try and break my PlayerController script into various components, but I'm not sure it'd have any direct benefits... Currently, I'm "following" the SRP because it is indeed a script that controls the player, but perhaps things like interaction and firing deserve their own scripts and homes to be used elsewhere... But what do I know?
I'm sure I'll regret that later LOL, when I start making enemies I might want to have shoot or interact or something like that...

At least, it should be fairly easy to implement! ;)

---

In hindsight, my PlayerController knowing about InteractableTileScripts and all that was bad design, because it violates the SRP. I'm controlling the Player, not interacting with tiles... I'm glad I know that now!

---

Yippee! Now I've got my ToggleInteractableTile working after some testing, with a working status and everything.

However, I've implemented it all in one script. In order to make it a component like BreakableTile, I need to make a triggerscript that triggers this tile.
