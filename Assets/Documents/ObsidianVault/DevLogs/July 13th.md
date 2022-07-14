Continuing on from [[July 11th]], I had some ideas while brainstorming about how to continue adding onto the foundation I've made thus far. What's really exciting to me is that I've been brainstorming about different movement abilities. However, I was having a little bit of an internal debate about design philosophies.

So I was wondering: in designing movement abilities for my character in this Metroidvania game, should I be designing the abilities as "answers" to different solutions? I was thinking like with the Morph Ball from Metroid. When you first roll up and go to the right (iirc), you are too tall to enter a passage. When you BACKTRACK and go to the far left, you find the Morph Ball. In this case, the game tries to teach you how to play it. You get the Morph Ball as a "solution" to that room.
In that realm, yes, I could design in that way. Initially, to show people how they might play my game. However, I want to make my movement abilities different ways to interact with the world and I was worried that in introducing them in that "answer"-focused way I would be taking that away... Not necessarily, I suppose.

Well, I guess that's settled.

In any case, I had ideas where you could change forms into different spirit forms. For one, I wanted to make it something like a dash or Morph Ball-like state with the ability to go through narrow tunnels and stuff like that.

Perhaps it could be something in which you can float around and fly around and stuff (but for only a certain distance).

I'll work on that in another branch though, I still have work to do here with my interactable blocks.

---

#### Interactable Blocks Things :D

So as it was, I had to do some of the backend stuff about my interactable tiles so far. I had two major ideas so far:
1. To make certain Tiles "listen" for and react to certain events...
	1. Unity events might be a good thing here LIKE THE EXAMPLE WE DID IN SCHOOL WITH THE SCRIPTABLE OBJECT!!!!!!!!
2. To make a ScriptableObject that will load the textures for certain levels for interactable blocks (based on area/theme).

OK, for the first thing, I have to figure some approach out. A lot of the CONSTRAINT with my initial solution is that I don't have access to the instantiated objects outside of runtime. Afterwards, I'm good...
	The thing from my class that I remembered was that I could make a ScriptableObject with a specific UnityEvent that could handle most/all of the event invoking and listening and all that stuff. I could make a script to listen for a specific event and then trigger a tile effect, or something like that....
	And I ***could*** attach them to the tiles that NEED them during runtime, but... Is this really a good approach? I mean it might work...

Well, I also already have a little something in place already. I currently use C# Events that are sent FROM my LevelTileGOs to the LevelTileManager, which handles that sort of thing.

The main thing is that I have no real way of adding....
Unless...

I have to think. It's been a while since I've done something like this, but I WONDER if I can take advantage of static C# events from ANOTHER class as well... The main thing is invoking them.

My current approach to this problem is by having an abstract base class for  LevelTileGOScripts, which currently has two children, BreakableTile and InteractableTile. At present, they both share the capability to THAT'S IT

Ok, I was SO concerned about non-static events. I don't know if they're even legal (or where we might use them). BUT I remembered that static members mean there's only ONE per type.

---

Hmmm.... I already have LevelTileGOScript with an event that the tiles inherit. What I had in mind was to move those events down into the BreakableTile and InteractableTile classes, respectively. However, provided I did this and justified it and it worked fine, I don't think it'd have any real bearing on what I end up doing as the next steps.

That would BE actually finding ways to make things happen BECAUSE I fired off an event. This seems to be a much more robust issue. It could be changing variables about the game's state / progress, it could be activating certain things, it could be a MILLION different things.

I just have to see how I do this...

I had this idea a bit ago about storing and querying tiles that are meant to react to stimuli stored in a Dictionary by location of the sender. HOWEVER, I'm thinking there might be a better, different way to do this.

Just had a quick idea within the listener classes as well. What if I were to make a UnityEvent within each listener script that would allow me to trigger specific behaviors within the GameObject. Like my PlayerInput component does! ***That'd be cool, I'll have to remember that.***

---

***HO HOOOOO!***
I've figured something out... No, I may not be able to very cutely handle instantiated LevelTileGOs in the editor YET. But now, I've added a maintained list of the LevelTileGOs in my LevelTilemapManager script.

But how will I integrate this with other things...

UnityEvents make this process easy, but... I just have to see how else I'd do something like this... Hrrrnnngg.... I'm overthinking this. I'm fine. I can totally do this.

Man, programming exposes my peak insanity as I ponder over my solutions and implementations, lol. In any case,

I think I WILL use UnityEvents in whatever capacity I am available. I JUST have to see how exactly I can hook them up. I'm seeing in my mind, a door. This door has a doorscript that will make the door rise animatedly. I want to make this door open, a function in its doorscript, trigger via an event. I can add an event listener with a UnityEvent to do whatever my little heart desires ***BUT*** how do I listen for an event from a certain object?

I *COULD* just create a Vector3 field that listens for an event, checks if the location of the sender InteractableTile is the location we react to and do something. That could WORK, but it's hard-coding, it feels like a magic number that I could really mess up if I do it poorly...

I'm really debating setting up some CustomInspector nonsense...

Restating it here, I have a C# event that is sent from some InteractableTile via the LevelTileGO event RequestTileInteract. I want to respond to this C# event in some listener class that I can put on just about any GameObject, which will use a UnityEvent to trigger other neat behavior. ***THE PROBLEM IS THAT*** I don't currently have a good and user-friendly way of ensuring what InteractableTIle sent that event.

Now,  I could do this the old fashioned way. I could send the object that SENT the event with the event, alongside some event args if necessary. I could also implement a .Equals method which could compare if a LevelTileGO is equal to another LevelTileGO instance. This would allow me to check in a fairly easy way whose event I'm receiving. BUT this assumes I'd have a list of LevelTileGOScripts or InteractableTiles to pull from in the EDITOR, and I don't have that :).

Now, what if I were to send an enumerated number or something? But then I'd need to have and maintain some sort of long enum list for EVERYTHING I WANTED TO HAPPEN and that'd suck.

Again, I could just listen to some specific Vector3 position and verify that's the fella who sent it. That seems like the most intuitive approach I currently have, but the workflow for that in the editor seems unfriendly and unintuitive by comparison. If ONLY I could have the MENU of ALL THE THINGS that I get with GAMEOBJECTS made in the EDITOR, if only!

Grrr, that makes me so MAD! This would be easy if they were just normally-instantiated GameObjects not created during runtime. Why aren't I doing this? Because I wanted to make a fairly robust system that LIVES in Tilemap directly. Pretty much everything I can think of in the game will live on the Tilemap, so why NOT use the Ruletile GameObjects?

Another potential solution is to have my LevelTilemapManager script listen for the C# event, and then query some defined dictionary where I have a list of eventlisteners for certain locations? But THAT would give me the same problem with the redundancy that I could react to the C# event WITHIN the listener class!!

I could try to pass in some unique Id for the event being passed in, but that's the same issue as with the enumerated number approach with maintaining a tedious list of all this. It might not be a BAD thing, but maintaining it would SUCK! If I could do something like the tag list or layermask list where the numbers are listed and it's a static field, that's what I'd really like. The problem is that this is just really editor unfriendly.

Sigh...

Maybe an enumerated field would be best... the problem is that I have to set a unique Id per interactable tile, which I would have no control over, and hope they set the same way each time... heh... heh...

I think I'm onto something with maintaining the indexes of the InteractableTileScripts in a list format. I would prefer an array if possible.

you know what else is really cool? i don't think, for my interactionlistener class, that I'd even be able to have them do things like break on certain events, because we'd never get to SET the data to know what position/id/whatever to listen for anyhow. What's the quote, "Ain't war hell?"

---

A solution to this? Separate interactable tiles from the Tilemap. These are objects that require much more sophisticated behavior than can currently be allowed with Unity's instantiated RuleTile Gameobject THING. That's good for things like my Breakable blocks, which can have much more common, easier to implement behavior.

But for connecting objects in my Scene in an Editor-friendly way, I think I must need something else. Something more.

What if, I were to create a new TileBase child specifically for InteractableTiles? Here, I could have some static Id for each of them on the  Tilemap, and a link to a gameobject that I can pre-instantiate and KEEP in the Editor? Let's give it a try.

You know what? I'll even do it in the normal LevelTileBase, so that everything can have its own more easily trackable instanced gameObject if they need it. Here's hoping it works...

Well, I gave it a good old college "try", and I ended up getting an interesting type mismatch error. Essentially, since Tiles are ScriptableObjects, trying to  save some live, runtime-asset to them is garbanzo beans while NOT in runtime. Hence why we instantiate and recreate prefab GameObjects only during runtime, if I'm understanding this correctly.

So it's getting late and I have to go to bed, but I'll be at this tomorrow with a new approach. I'm interested in getting this working as something I can use with/on the Tilemap, but I'm not sure I can.

But at present, the idea of making a GameObject, assigning it to a Grid's cell  center in OnValidate every chance we get, and having it live predefined in the inspector sounds nice to me. Or, since I'll have to instantiate those somehow (likely), some data structure that stores the event listeners with the events we publish.

Point is, I'll have to tackle this tomorrow. Let's give this another shot then.