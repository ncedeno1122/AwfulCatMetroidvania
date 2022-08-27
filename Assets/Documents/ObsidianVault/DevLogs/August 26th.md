Continuing from [[August 25th]]!
I feel somewhat bad because yesterday I laid such elaborate plans but didn't do very much. I worry that with school starting and my new part time job starting soon that I won't have much time to work with the project. BUT, I guess that's what plans are for. As well, I have done a LOT of work without committing it, but I want to solidify my new direction before I commit majorly (this totally doesn't go against my previous mantras towards commiting :)). In any case, I have some time today so I want to try and get my system working.

---

At present, I got the AchikComponent script up that's sort of my type object. I have a dictionary that relates a struct called SkillInput (made up of two enums and a bool representing the [[Achik#Skills]] fields for determining the input), and what is currently an ISkill component. I have a HandleInput function that takes in a SkillInput. The question is, now, how will I pass in the SkillInput struct? I'll send it currently in PlayerController, that's what I'll do.

Eventually I'll have to make some interface or relationship between the AchikComponent and KowiComponent and all other TypeObjects that I may need to make... Hmmm..

---

So I've gotten it working INITIALLY, but I haven't implemented DoubleTap logic for Skills yet. I'll need to use the SkillInput class to describe Achik's basic knife attacks, but I may need another way to do that. Hm.

Ahh, I'm so happy though, this seems to be a good thing. In having a dictionary that I INDEX, I either get a result or don't. I don't have to rely on iterating over some set or something like that. It's fast, it's fun, and it's working at least initially so I'm glad. It also follows those neat design principles by making it easy to extend / add onto this system.

Gosh, what a win. I'm glad because this has been sapping my brain energy since I started it, I really wanted to get this started properly. To see some success is relieving.

I do need to refactor some things though. I have duplication in how I determine what direction the input is coming from as I get it in AchikGround and AchikAir states.

---

See, now this is all pretty interesting... I JUST started to implement the DoubleTap Action in the input system, but I don't think that I ever really need to care about calling the PlayerState's OnSkill or whatever functions...

At present, I don't anticipate any scenario in which simply gathering the direction of a skill input - when it's pressed - is any different. I don't think I'd ever have to really specifically block the inputs in a hyper-specific way *yet*, so I'd be good to delete that soon if I didn't want it.

As well, an interesting bug has appeared in my attempts to implement this DoubleTap action. As it turns out, when I try and activate the DoubleTap ability, the SingleTap action is getting called. That was to be expected... but how to fix it?

What's happening more specifically is that the state is changing from one to the other very quickly, causing weird behavior. For example, as I do the Bless action that's bound to Grounded Up SingleTap, sometimes I end up invoking the MultiTap interaction and have my state switch to the SpiritFormState. How can I fix this? I can check to make sure when I try to transition from one state or another, that the state can actually be transitioned FROM logically (ex: I can transition to a new state from ONLY Grounded or AirState, none else). This would prevent these actions from happening, but might not clear up the input problem... I'll have to see...

---

You know what, I might have been using inputs incorrectly OR AT LEAST HARDLY to their full potential all this time. I just didn't really thoroughly go through it before. However, I have to take care of something tonight, so I may or may not revisit this. Before I do, however, I want to figure out what I need.

So I need some way to discern some different input interactions. Once I know what TYPE of interaction is happening, I can feed that properly into the system I have currently and get that all done. Firstly though, I need to understand how to have my Interactions working properly.

---

Alrighty, after a fun evening of babysitting, I'm back. I wrote up some code after looking at some examples from the Input System documentation, and now I've gotten my things working. It doesn't seem that bad at all in retrospect. Quite handy actually, with the Dynamic Callback Context functions and all that the UnityEvent approach allows me.

In fact, it's made me quite a bit more comfortable in implementing other Actions. I'm... weirded out by it, but it works! **I think that for the Bless and Pray actions, Holding might be better** as an InputAction.

That said though the last error I was aiming to fix remains in which we activate states in an improper way. This stems from the fact that we ATTEMPT to responisbly change states despite the fact that we shouldn't while we're in a state that has a skill or a skill component associated with it.

I wish there was a way for me to make states for the skill components recognizable, like an interface or superclass thing or something... I feel like that card may be overplayed for me though (even if it works). I need to look for more ways to relate classes than this...

#### Skill States working with Components 
But yeah, I think I could make ISkill into an abstract class with the EXCUSE that there's a boolean that specifies when the action is happening or not. Perhaps the STATES can take in that component in their constructor and HELP with that??? That might be REALLY COOL!

This is something I'm looking to implement next for SURE now that I've gotten my Interaction knowledge somewhat more solidified. In any case, that's all for today. Tomorrow, I'm going to eat at this one great buffet that I like to FUEL my brain for more awesome stuff like this. Onwards and upwards!

