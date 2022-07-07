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

