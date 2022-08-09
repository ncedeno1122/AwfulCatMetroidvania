Continuing from [[August 6th]]! It's a shame I've not had more time to work on this, I'm splitting time between learning and making a webapp for the company I work for currently. In any case, I still wanted to get some work done here today.

In the last entry, I spent some time ideating and composing some music, even though I didn't write so much about it. In that aspect, I'm still developing an aesthetic sound-wise. I'm finding a better blend of my live instruments with synths and stuff like that which is nice, but there's still work to be done. As well, I've been notating ideas and composing them in Musescore which is nice so I can have them on paper, rather than in Cubase where I can't extract their ideas without actually hopping into the files and finding them all.

In any case, I wanted to think more about some fun ideas like last time for abilities and stuff like that. Perhaps, however, I need to approach these abilities by trying to build a level or something. That way, I can really see what limitations I want to design for. For example, designing by limitations, like I'd said before. What can't we do or break at this moment?

I know that for one of Achik's abilities I wanted him to be able to "Bless" or do something like that. Basically he takes up a prayer stance and creates a little bubble around him that would trigger things. This was inspired by the frequent divinations every time the Incas would break the earth to plant crops for fortune with the harvest and such. This would also be a neat thing to go from one world to another as I want to. Perhaps I'll do that today.

#### Achik: Downwards Thrust with Priest Knife
IDEA really quick, wouldn't it be fun to give Achik the Zelda II Down Thrust attack in the air with his priest knife? Or something? That'd be fun I think, and a unique thing for him. It also helps with ACTUALLY implementing a knife at all, its short range makes it a hard weapon to try and convey with other moves, potentially.

---

For this, I'd obviously need to implement the state, the animation, and however I plan to create the object/effect for blessing certain objects or something. I'd also need to create some sort of "handler" component to listen for this and trigger some events, kind of like my observer-listener script I had before.

The main thing that I'm concerned with in making these skills is the feedback they'll give for using them, that contributes to the game feel and all that. At least early on, anyway. Would it be more effective to use a little particle effect that I trigger with an OverlapBox or something, OR would it be better to actually have a GameObject with a component script and trigger collider for me to bless with?
The second option seems more scalable and workable. The best thing is, it can fairly seamlessly integrate with my systems as I've decoupled them so far. That way, many things can bless if I need them to! I think that's the way.

So, making a managed GameObject that will bless and all that is the way to go I think. Should it be a prefab, or something I keep on the player? Hmm...

I COULD control it via the animation system, but... I don't want to rely on that. I'd much rather do it as a state or something rather than that, as I did with the spirit form stuff.

Really quick, I want to commit this work so I can have it for later.

So yeah, I can basically have it as a GameObject with a component script whose sole duty it is to maintain the size of a Collider and a coroutine and all that, and trigger certain things if something will choose to react to it (done in another script - CollisionListener? IDK).

---

My first approach was to get the majority of the coding out of the way with how I wanted things to lerp and all that, but I have to think more design-wise now. What would be a good way to handle this..?

My little issue is that I want to structure things well. It feels weird and foreign somehow to make some sort of childed GameObject with the increased collider size. There, I *could* just make some script whose stuff I invoke via UnityEvent and stuff like that like usual, but it's the first one that I'm making that would trigger something outside of the GameObject. I may want to activate/deactivate the little collider GameObject which is why I worry about my dear script.

This is easier than I think, actually. I'll make a script on the Player that will handle invoking the action and all that, and then a script that can be deactivatable that handles the collision on the GameObject.

---

Aaaand I've implemented the lot of the code half of it. I've got the expanding collider, all that stuff. Now I just need to implement some sort of script that listens for the interaction and provides functions for when it gets blessed.

Moreover, I have to get some animation on that and have the state interface with the PlayerController state machine and all that. For now, I'll commit this work.

---

Boom, now I've made an AchikBlessState, so it's animation time.

I did this SUPER simply since I know I'll want to resprite/animate this later with more transition frames and all that. For now, this works, and that's what I want. RAPID prototyping.

I wanted to add a little Particle effect to make it look nicer, but because I'm changing the scale it's getting stretched out and weird. Perhaps I'll just change the size of the collider and the sprite renderer. 

Now I've done that, so I'll make a little BlessListener or something to react to my blessing.

---

Yeah uh, I guess I did it. That was... easy. LOL! I rarely ever praise my own ability to get this stuff done. But, I did it at least at a basic level and that's all I should ask for now. Later, I can polish and add a bunch of crazyness, but this is more than okay for now.

I think I need to think about what specials I want for each direction. I can make UnityEvents and name them for each direction and special and grounded/non-grounded ability. This would be a good way to organize things going forwards, that's for sure.

It's a LOT of skills for the Inspector though, so I may have to write a CustomInspector script to make them easier on the eyes.