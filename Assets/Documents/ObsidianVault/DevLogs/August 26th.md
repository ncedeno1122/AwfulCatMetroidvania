Continuing from [[August 25th]]!
I feel somewhat bad because yesterday I laid such elaborate plans but didn't do very much. I worry that with school starting and my new part time job starting soon that I won't have much time to work with the project. BUT, I guess that's what plans are for. As well, I have done a LOT of work without committing it, but I want to solidify my new direction before I commit majorly (this totally doesn't go against my previous mantras towards commiting :)). In any case, I have some time today so I want to try and get my system working.

---

At present, I got the AchikComponent script up that's sort of my type object. I have a dictionary that relates a struct called SkillInput (made up of two enums and a bool representing the [[Achik#Skills]] fields for determining the input), and what is currently an ISkill component. I have a HandleInput function that takes in a SkillInput. The question is, now, how will I pass in the SkillInput struct? I'll send it currently in PlayerController, that's what I'll do.

Eventually I'll have to make some interface or relationship between the AchikComponent and KowiComponent and all other TypeObjects that I may need to make... Hmmm..

---

So I've gotten it working INITIALLY, but I haven't implemented DoubleTap logic for Skills yet. I'll need to use the SkillInput class to describe Achik's basic knife attacks, but I may need another way to do that. Hm. 