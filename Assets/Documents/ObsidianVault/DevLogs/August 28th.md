Continuing from [[August 27th]]. It is the Dawn of the Final Day before school picks up and I'm back on that grind. Today I had french toast with this fancy, wonderful maple syrup from Canada and it was delicious. My word.

Ahh, I might make another skill today, but I'm deciding which one. I did say I wanted to tackle the Bless and Pray distinction, so I might make Pray today. As well, I'll need to make abilities reduce Attiniy when they're called. 

---

#### Do My Skill Component Scripts NEED to be MonoBehaviours?
You know what's crazy?  What's just a little nutso? I wonder if I *even NEED* my Component scripts to be MonoBehaviours...
I don't ever really use any Unity Functions/Messages besides Awake, which is essentially a constructor. The only thing I really use them for past that is coroutines, which... I could define a function for and then have that run within the PlayerState, since the IEnumerator function itself is more of a generator function than it is an actual one.
	Looking more into it, at my AchikSpiritFormState & AchikSpiritFormComponent, my SpiritFormComponent is relevant because it acts as my intermediary to other MonoBehavior things. I can get things, find things, etc. like a normal script...
In conclusion (for now) I'll keep this the way this IS until it no longer makes sense. It's like my UnityEvent approach before. When I have more of a system figured out in terms of what references I need and all that, I can just pass in the AchikController who will unite them, and have THAT guy be my intermediary. Talk about black-boxing, lol...

---

