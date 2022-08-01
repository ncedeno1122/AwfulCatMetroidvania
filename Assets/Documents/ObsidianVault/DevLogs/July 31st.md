Continuing directly on from [[July 30th]]! In the words of the Mayans (Yucatecan ones anyway,), ma'alo'ob k'iin! I love that saying. Being gracious for the sun, the day, and everything it brings really strikes me. In any case, let's get on with the show.

Last night, I had more of a realization about what an Ability (as I called them then) actually is. Here I was talking about passive abilities and skills. Both of them technically have a start point and an end point in time, in which their effects are applied and all that stuff. For skills that require player input to start their effects, they would need to override the current state of the PlayerController somehow... How specifically? Well, I hope to look more into that today.

---

That brings me back to my current little place of dealing with the state machine for the PlayerController. I wanted to avoid making the PlayerController into a monolithic script that had all the behavior I wanted. Instead, I thought it more appropriate to make the behaviors more readable by separating their behavior into different states and all that. My only question now is, **what is the scope of each state?**

Why I even have to ask this is because I've never had a state machine whose scope is actually the whole of a character's movement. I guess it's not really that different. The scope is influenced by the fact that we're literally handing Player Input and all that. So I have to think in terms of that. *What do we do with input in each state?*

A major question of mine is, what states even are there? I can do one that governs the character's movement and all that stuff. I have that one already in fact...
Maybe I have a state that goes on when the player gets hurt, or **any other time the ability to move the player via the input and external factors conflict.** You know how you get impulsed back in Metroid when you take damage? Like that kinda, you can't really control too much about as you're getting hurt and all that stuff. And what about times if you get launched through a cannon or something like that, where you can maybe DI the launch but not by much or something? I think I'm getting more about this now.

#### Semantic Idle States
Moreover, there's a lot of power in having semantically idle states. You know how in Metroid when you get on an Elevator you're just STILL? This *could* be achieved in many different ways (literally spriting the character on the elevator and moving THAT sprite), but if there's a semantically idle state related to that then we have the power of knowing where it might be used. After all, that idle state is different to one reserved for skills, for doing something else, etc.

Yeah, I think I'm getting more of this now. I need to try and explain it really simply so I don't forget though. My PlayerStates control how the Player is controlled in different situations. ***Essentially, each State contains logic I'd write in the PlayerController class were it not a more flexible context class.***

***I have to rework the default physics or create a more in-depth character physics profile for both Achik and Kowi***. This can be achieved with a ScriptableObject :D (likely, anyway).

---

Now, I've reimplemented jumping into the main PlayerMoveState. I was worried that I may need a jump state or something like that, but UNTIL I DO I'll proceed in this manner.

#### WaitUntil States
It just occurred to me that I can also make WaitUntil states, that wait until some state and potentially target a state to turn to after (in the constructor) its condition is met. For example, for a death animation, we can WaitUntilGrounded and then play an animation like that afterwards or something.

That's pretty neat, I suppose. In any case, let's continue with my work for now...

What's next is actually learning how to activate a skill based on certain inputs. I think of something like Down-B-ing in smash. Perhaps there's something I can make, like how the inputs in SoulCalibur work for detecting more complex strings of inputs... then again, I'm not sure that's entirely necessary.

I know what I need. I have my Fire button for a basic input, but I need a second Fire type input. Perhaps I need to call this button something else...

---

So I've been looking at the InputSystem documentation and while I can't say I fully understand it on my first read, Interactions might be what I'm looking for... I have to see, but it seems that I can create more Actions, things like OnMove, OnFire, OnJump, OnInteract, etc..

From what I understand, these event handling functions are invoked every time some information about that InputAction are changed. This is how I can move the character, poll for button presses, all that.

BUT, Interactions will only invoke the Action's event if a certain input pattern or something like that is met (Holding, Tapping, etc.). This could be useful if I was to make some actions about my new input. 

This is versatile... Very versatile. I have to see how I'll handle these things...

What's neat about them is that I don't seem to be able to check them in tandem with other input things, I'll have to do that in the script. For example, if I invoked the Skill Action by holding, multi-tapping, etc, I'd have to determine in-script. For that reason, I'll have to change the nomenclature of my Actions. Depending on the Interaction I'm waiting for, I can append --Tap, MultiTap, Hold, etc. to the end of my actions.

This is, of course, my initial understanding of this very versatile system. I'm weirded out by that you can add multiple Interactions to one Action.

What may be useful is to decouple my ideas somewhat. **I must create interactions for the events that happen to that specific input**, and **I must listen for these in combination with other data in scripts**. Essentially, I can listen to the inputs like anything else, but I have to process what actually happens elsewhere, like for directional inputs (a la Down-B).

Let's try programming this... 

#### Achik Spirit Form Input
> Also I think it'd be nice to have a MultiTap input from which, for Achik, I can trigger his Spirit Form while holding DOWN on the PlayerInput Vector3.

---

Ok so I'm now very simply reading inputs as they pertain to directions. This is pretty good, I'm pleased so far, but now I need to see how it is that I'll hook up DIFFERENT states and actions to go to.

The thing is, I'm trying to implement Achik's spirit form, and I need a different little physics scheme for that. That's fine and all, but to make a component that I can use on any character I want to make, things are different. Kowi cannot do a spirit form thing like that, so I need to get to some point where I can read common inputs and patterns between the two of them and if the current character has a special state or ability relating to that, handle it.

The current idea I have for this involves a ScriptableObject where I can specify all the routes and stuff like that. A secondary idea is to, depending on the character whose ScriptableObject I'm loading is, create an AchikPlayerState and a KowiPlayerState. This way, I can create connections between states that are more per-character and less generic...

Hmm, I'm not sure, but the latter approach sounds a little easier to implement personally. If I'm so serious about ensuring that Achik and Kowi play differently, then the time spent defining these states and all that stuff is well worth it. For that purpose, I think it is!

It still just makes me think though... The physics, passive abilities, and skills are really the only main differences between the two characters.... No, that's wrong. I'll have to separate them via classes as I said above!

For now, I'll push this commit, then make that next change.

---

So what's REALLY got to change? I know that my PlayerMoveState absolutely should. This is a concrete state that controls how the character (now, only Achik) will move and all that.

I'm still so unsure... something stinks about this approach and I'm not sure what just yet.  I like the generic approach but I think this more specific approach works better... Hmmm............

Let's try this approach and see if anything goes horrifically wrong. At present, it seems the far more flexible way to be able to make my characters feel different (and it is, logically)...

Ok, first, let's create an AchikMoveState, which may or may not be EXACTLY like my PlayerMoveState currently.

I've started by actually separating a GroundStat and an AirState. There may be a wealth of states like a JumpState in between to add the impulse, all that fun stuff, etc, but I think this is the way forwards.

I've started by figuring out how I know whether or not I'm grounded. This might be something as easy as checking the Rigidbody's y velocity combined with a raycast or something like that, or it might not be. I have to coach an Overwatch scrimmage for now though, so I'll get to this when I return.