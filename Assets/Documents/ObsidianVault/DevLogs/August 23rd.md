Continuing from [[August 22nd]] and proudly so! I might go and grab a quick lunch before I HARD CARRY SOME MORE TODAY!!

I'm so excited! Because every time I get to design and then code, I am pleased with what I come up with to some degree. Today, I will be following up on and making my `AchikController` script with my concrete references. I will do away with my UnityEvent, cute little UI things because I now know what I want in terms of skills and all that. Ahh, how nice...

---

In any case, it'll serve almost exactly like my PlayerController except that it'll have references to work with for the Component scripts for Skills.

What about a ScriptableObject that contains all the data I need for the skills I'm hooking up... That might be neat because they'd be united by the ISkill and IResourceSkill interfaces, which would easily be hooked up when I need to invoke them.

In any case, a Wawa BLT sounds *heavenly* about now and I need some nutrients at the moment, so I'll be back in a bit.

---

Ahhh, what a nice day it is. In any case, I'm back for now! Let's get to implementing an AchikController from my PlayerController script. I can *probably* make the PlayerController a parent class and only have more fields in the child one. Is this the best approach? Not so much... But is it the one I'm going with? For now, yes.

Hhhhrrmmmmmmnnngg...... It's just that this task may require more thought then this gung-ho approach I'm prattling on about. I need to think about a PlayerController that might benefit Kowi as well. 

It might not realistically be *that* difficult or anything... I'm just being a weenie.

I AM being a weenie justifiably though, because sometimes inheritance makes my skin crawl. And here it does too. It just seems... too convenient? And not modular like what I was working with before...

I know what I'll do though.

I'll restore my PlayerController but I'll make an object that will keep my logic as it is now, but I'll compose it with some new class that will enumerate and store the different types of Skills and data that each character will have. Maybe something like CharacterProfile or something?

In any case, first, I need to go and implement the appropriate interfaces to my existing Skill scripts. Then I can do what I'm describing here.
Aaand it turns out I've really only made two skills so far so no problem. NOW we'll proceed!

---

Okay, thinking data-wise about important things for each character, it MIGHT be useful to define some cohesive way to decide what INPUTS will address certain Skills. Could I use a dictionary to store all of the skills? Sure, I suppose. What I wonder is, is there a better way? Like I could make a class called SkillCollection that holds four input based spells and correlates them to some direction.

Look that might be limiting and overcomplicating. In the name of some flexibility, let's *try* a funky dictionary. Apparently they're decent too at lookup jobs (which I simply wasn't sure on), so I guess I'll proceed in this manner? Hmmm.

RRGH, it's just that I want to think about this data-wise, and I want to use ScriptableObjects. But the thing is, I'm not quite sure about how I'd populate my Dictionary in advance (in something like a ScriptableObject). I think it'd be really cool to have my things settled there.

But I guess what I COULD do is, in some ScriptableObject that will contain the definitions and correlations between my Skills and the inputs to activate them...

Only GRRR, there's something annoying me.