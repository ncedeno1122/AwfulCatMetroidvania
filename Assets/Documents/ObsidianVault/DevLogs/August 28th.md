Continuing from [[August 27th]]. It is the Dawn of the Final Day before school picks up and I'm back on that grind. Today I had french toast with this fancy, wonderful maple syrup from Canada and it was delicious. My word.

Ahh, I might make another skill today, but I'm deciding which one. I did say I wanted to tackle the Bless and Pray distinction, so I might make Pray today. As well, I'll need to make abilities reduce Attiniy when they're called. 

---

#### Do My Skill Component Scripts NEED to be MonoBehaviours?
You know what's crazy?  What's just a little nutso? I wonder if I *even NEED* my Component scripts to be MonoBehaviours...
I don't ever really use any Unity Functions/Messages besides Awake, which is essentially a constructor. The only thing I really use them for past that is coroutines, which... I could define a function for and then have that run within the PlayerState, since the IEnumerator function itself is more of a generator function than it is an actual one.
	Looking more into it, at my AchikSpiritFormState & AchikSpiritFormComponent, my SpiritFormComponent is relevant because it acts as my intermediary to other MonoBehavior things. I can get things, find things, etc. like a normal script...
In conclusion (for now) I'll keep this the way this IS until it no longer makes sense. It's like my UnityEvent approach before. When I have more of a system figured out in terms of what references I need and all that, I can just pass in the AchikController who will unite them, and have THAT guy be my intermediary. Talk about black-boxing, lol...

---

What's better than this, I'm DOING it baby yeah that's right. In any case, lol, I NOW have to reduce the amount of Attiniy. I also need to NOT activate the skill if we can't afford it. I think I can do that in the AchikComponent.

I think by definition my component scripts are doing what they're supposed to in terms of the component objects. I was a little afraid at first that I had strayed from their definitions but they DO allow me to extend the functionality of a PlayerController or character type object *by allowing them to access different states*. That's cool I think, they're still doing what they need to which is pretty alright.

There's some unwanted behavior that I've been tackling within the SpiritForm Component. Mostly in the fact that if I want to END early or we run out of Attiniy to use magic with, then I wasn't stopping the coroutines and we'd have overlapping coroutines happening. THIS is typically why I'd encapsulate and try to manage just one IEnumerator variable and check IT and all that, but because I've avoided that this time I need to make sure to stop them always.

What's more, I need to NOT start the thing actually and enter the state and all that if it can't be activated Attiniy-wise.

BOOM and I just worked that one out. Man, I'm glad this is all working out! What's more, I keep on debating about interfaces versus abstract classes... For the IResourceSkill interface, I only use it with floats for the generics. What's more, for the HasEnoughResource method, it's duplication. I think for that REASON I could justify making it an abstract class or something like that. We'll see after some dinner.

---

ALSO there's this annoying bug I need to fix with the movement when grounded. Basically you maintain velocity if you hold up or down when you shouldn't (you slide all over).

BAM baby so at least there, more done today. That rocks! I guess Mission Accomplished with what I'd said at the beginning. I made the Prayer one easily, the reduction of Attiniy for ResourceSkills, and made it so that you can't Activate() ResourceSkills with insuffient resource. (Though I do think I could pull that up somehow as an abstract class...)

Will I work more today? It's still a bit early...

I GOTTA BE HONEST I'm really interested in potentially making the aiming system for the knife throwing thing, OR just generally getting the EnergyBall skill implemented. The main thing is just aiming, I'm not exactly sure how I want to aim it...

I just have to think about (again) how I want to actuate the Energy Ball input versus the Knife. If the Knife was actuated horizontally, that'd be cool maybe. But perhaps some aiming mode is better...

Unless I was just to map them as Achik's basic attacks... but I want to use the knife optionally as well! Here's what we do. I'll make a Passive ability that can be activated or deactivated that will dictate whether Basic Attacks are EnergyBall shots OR knife attacks. How's THAT?

What's more, I can make this the Grounded Neutral and possibly Aerial Neutral Skill. I'll call it Attiniy Basic Attacks On / Off. I don't know honestly what a clever name to call it might be until later. Or just Attiniy Attacks Toggle?

Okay, I've just updated the Skill sheet in [[Achik]]. Now to actually get the code for this.

---

I'll save that for later though, hooking all that up. For now, I must rest and get ready for my first week of school!