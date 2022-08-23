Continuing from [[August 23rd]] and proudly so! I might go and grab a quick lunch before I HARD CARRY SOME MORE TODAY!!

I'm so excited! Because every time I get to design and then code, I am pleased with what I come up with to some degree. Today, I will be following up on and making my `AchikController` script with my concrete references. I will do away with my UnityEvent, cute little UI things because I now know what I want in terms of skills and all that. Ahh, how nice...

---

In any case, it'll serve almost exactly like my PlayerController except that it'll have references to work with for the Component scripts for Skills.

What about a ScriptableObject that contains all the data I need for the skills I'm hooking up... That might be neat because they'd be united by the ISkill and IResourceSkill interfaces, which would easily be hooked up when I need to invoke them.

In any case, a Wawa BLT sounds *heavenly* about now and I need some nutrients at the moment, so I'll be back in a bit.

---

Ahhh, what a nice day it is. In any case, I'm back for now! Let's get to implementing an AchikController from my PlayerController script. I can *probably* make the PlayerController a parent class and only have more fields in the child one. Is this the best approach? Not so much... But is it the one I'm going with? For now, yes.

