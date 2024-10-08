using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ld56;

public static class AllDialog {

  //This is the response given by all NPCs to their food
  public static readonly Dictionary<MealQuality, MealResult> MealResponse = new() {
    [MealQuality.Perfect] = new MealResult {
      Text = ["That meal is PERFECT!", "Here, take 10 gold."],
      Result = () => {
        GameState.Gold += 10;
      }
    },
    [MealQuality.Close] = new MealResult {
      Text = ["Uhh...."],
      Result = () => { }
    },
    [MealQuality.Miss] = new MealResult {
      Text = ["DIE IN A FIRE."],
      Result = () => {
        GameState.Gold = Math.Max(GameState.Gold - 5, 0);
      }
    }
  };

  //DIALOGUE STARTS HERE

  // Tom
  public static List<IDialogItem> Tom = [
    new DialogItem {
      Text = "It was late spring morning.",
      Speaker = CreatureId.Tom, OverrideSpeakerName = "????"},
    new DialogItem {
      Text = "A storm was coming, and there was a scent of rain in the air sharp enough to mow the lawn.",
      Speaker = CreatureId.Tom, OverrideSpeakerName = "????"},
    new DialogItem {
      Text = "Not that I was complaining.",
      Speaker = CreatureId.Tom, OverrideSpeakerName = "????"},
    new DialogItem {
      Text = "Mornings like this keep me sharp too,",
      Speaker = CreatureId.Tom, OverrideSpeakerName = "????"},
    new DialogItem {
      Text = "and most days, a sharp wit’s the only thing keeping me from taking a long nap in the Main Street gutter with half a dozen bullets in my back.",
      Speaker = CreatureId.Tom, OverrideSpeakerName = "????"},
    new DialogItem {
      Text = "…can I take your order?", Speaker = CreatureId.You},
    new DialogItem {
      Text = "The name’s Detective Tom Shortcoat.", Speaker = CreatureId.Tom},
    new DialogItem {
      Text = "My friends call me Tom. My enemies call me Shortcoat.", Speaker = CreatureId.Tom},
    new DialogItem {
      Text = "Any my lovers, well, that’s not something I ought to discuss in polite company.", Speaker = CreatureId.Tom},
    new DialogItem {
      Text = "Um. Can I take your order, Detective Shortcoat?", Speaker = CreatureId.You},
    new DialogItem {
      Text = "The dame had powder-blue eyes that grew as big as dinner plates when she saw me walk through the door.", Speaker = CreatureId.Tom},
    new DialogItem {
      Text = "The apron looked well enough on her, but they tell stories about beautiful blondes with million-dollar smiles,", Speaker = CreatureId.Tom},
    new DialogItem {
      Text = "and let’s just say her smile could maybe buy a cup of coffee if you lent her a couple bucks.", Speaker = CreatureId.Tom},
    new DialogItem {
      Text = "Excuse me???", Speaker = CreatureId.You},
    new DialogItem {
      Text = "All my nutrition lately had come from whiskey and cigarette smoke, I mused,", Speaker = CreatureId.Tom},
    new DialogItem {
      Text = "so I reulctantly ordered a [color=#af973e]veggie omelet.[/color]", Speaker = CreatureId.Tom},
    new DialogItem {
      Text = "...coming right up...", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Egg, IngredientId.Onion, IngredientId.Mushroom], MealResponse);
      },
    }
  ];

  // Jerry
  public static List<IDialogItem> Jerry = [
    new DialogItem {
      Text = "Sweetheart! What a pleasure to see ya. All grown up, ain’tcha?", Speaker = CreatureId.Jerry},
    new DialogItem {
      Text = "Mr. Fontina! It’s been so long! What can I get you?", Speaker = CreatureId.You},
    new DialogItem {
      Text = "I could put away a big bowl of [color=#af3e48]onion[/color] soup right about now.", Speaker = CreatureId.Jerry},
    new DialogItem {
      Text = "Can do!", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook(
          [IngredientId.Milk, IngredientId.Onion],
          MealResponse
        );
      }
    }
  ];


  // Hazel
  public static List<IDialogItem> Hazel = [
    new DialogItem {
      Text = "Hi~ How's it going~", Speaker = CreatureId.Hazel},
    new DialogItem {
      Text = "Doing great, and you?", Speaker = CreatureId.You},
    new DialogItem {
      Text = "Couldn't be better~", Speaker = CreatureId.Hazel},
    new DialogItem {
      Text = "May I have an [color=#af3e48]onion soup[/color] please~", Speaker = CreatureId.Hazel},
    new DialogItem {
      Text = "Absolutely!", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Milk, IngredientId.Onion], MealResponse);
      }
    }
  ];

  public static List<IDialogItem> Hazel2 = [
    new DialogItem {
      Text = "Hiya Lena~", Speaker = CreatureId.Hazel},
    new DialogItem {
      Text = "Hey Hazel", Speaker = CreatureId.You},
    new DialogItem {
      Text = "Could I get a [color=#8d3eaf]kale and blue cheese flapjack[/color] pleaseee~", Speaker = CreatureId.Hazel},
    new DialogItem {
      Text = "Uh… I’m sorry, but I don’t think we serve that.", Speaker = CreatureId.You},
    new DialogItem {
      Text = "You...", Speaker = CreatureId.Hazel},
    new DialogItem {
      Text = "don't...", Speaker = CreatureId.Hazel},
    new DialogItem {
      Text = "HAVE THAT?! WHAT?!?!", Speaker = CreatureId.Hazel},
    new DialogItem {
      Text = "HUMPH!!!!!", Speaker = CreatureId.Hazel},
    new DialogItem {
      Text = "FINE. Bring me any other [color=#3e77af]flapjack[/color] instead.", Speaker = CreatureId.Hazel},
    new DialogItem {
      Text = "I... okay, sorry!", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Flour], MealResponse);
      }
    }
  ];


  // Chip
  public static List<IDialogItem> Chip = [
  new DialogItem {
      Text = "Whoa, Chip! You look banged up.", Speaker = CreatureId.You},
    new DialogItem {
      Text = "All good, Lena. Can’t learn to skateboard without cracking a few eggs!", Speaker = CreatureId.Chip},
    new DialogItem {
      Text = "And you know what? That sounds pretty good. Can you get me anything with [color=#af973e]egg[/color], please?", Speaker = CreatureId.Chip},
    new DialogItem {
      Text = "Coming right up!", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Egg], MealResponse);
      }
    }
  ];

  public static List<IDialogItem> Chip2 = [
  new DialogItem {
      Text = "Chip! You look worse than ever!", Speaker = CreatureId.You},
    new DialogItem {
      Text = "Yeah, I kinda ate it in the arena today. I’ll hit up the hospital soon, but you can’t skip lunch, right? It’s the third-most important meal of the day!", Speaker = CreatureId.Chip},
    new DialogItem {
      Text = "Uh...", Speaker = CreatureId.You},
    new DialogItem {
      Text = "Can I get a [color=#af973e]lactose omelet[/color] please? All that calcium should help heal my bones.", Speaker = CreatureId.Chip},
    new DialogItem {
      Text = "Oh boy...", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Egg, IngredientId.Milk, IngredientId.Cheese], MealResponse);
      }
    }
  ];


  // Kero
  public static List<IDialogItem> Kero = [
  new DialogItem {
      Text = "Hi Kero! Looking good today!", Speaker = CreatureId.You},
    new DialogItem {
      Text = "Thanks, Lena. It’s all thanks to this new diet.", Speaker = CreatureId.Kero},
    new DialogItem {
      Text = "And speaking of… I’ll have anything with [color=#277c2e]leaf[/color], please.", Speaker = CreatureId.Kero},
    new DialogItem {
      Text = "Coming right up!", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Leaf], MealResponse);
      }
    }
  ];

  public static List<IDialogItem> Kero2 = [
  new DialogItem {
      Text = "Whoa, look who’s bulky!", Speaker = CreatureId.You},
    new DialogItem {
      Text = "Yeah, my exercise regimen is really paying off!", Speaker = CreatureId.Kero},
    new DialogItem {
      Text = "Gotta get some more protein in me though. Anything with [color=#af973e]egg[/color], please.", Speaker = CreatureId.Kero},
    new DialogItem {
      Text = "Can do.", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Egg], MealResponse);
      }
    }
  ];


  // Rufus
  public static List<IDialogItem> Rufus = [
  new DialogItem {
      Text = "So hungry… I would love something [color=#8d3eaf]aromantic.[/color]", Speaker = CreatureId.Rufus},
    new DialogItem {
      Text = "Did you mean [color=#8d3eaf]aromatic?[/color]", Speaker = CreatureId.You},
    new DialogItem {
      Text = "?? No.", Speaker = CreatureId.Rufus},
    new DialogItem {
      Text = "Oh. Coming right up, I guess?", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Leaf], MealResponse);
      }
    }
];

  public static List<IDialogItem> Rufus2 = [
  new DialogItem {
      Text = "Still hungry… I would love something with [color=#8d3eaf]ant oxidizers.[/color]", Speaker = CreatureId.Rufus},
    new DialogItem {
      Text = "Did you mean [color=#8d3eaf]antioxidants?[/color]", Speaker = CreatureId.You},
    new DialogItem {
      Text = "?? No.", Speaker = CreatureId.Rufus},
    new DialogItem {
      Text = "Uh, I’ll get right on that, then.", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Blueberry], MealResponse);
      }
    }
];


  // Bonnie
  public static List<IDialogItem> Bonnie = [
  new DialogItem {
      Text = "Howdy, miss.", Speaker = CreatureId.Bonnie},
    new DialogItem {
      Text = "Howdy!", Speaker = CreatureId.You},
    new DialogItem {
      Text = "This here’s a mighty fine B&B, I reckon. I’ve got a hankerin’ fer some [color=#3e77af]flapjacks[/color]. Anything you can do fer ol’ Bonnie?", Speaker = CreatureId.Bonnie},
    new DialogItem {
      Text = "Why, of course!", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Flour], MealResponse);
      }
    }
];

  public static List<IDialogItem> Bonnie2 = [
  new DialogItem {
      Text = "I do say, this town sure is quaint. Y'all git along better'n two shrews in a shoebox.", Speaker = CreatureId.Bonnie},
    new DialogItem {
      Text = "Thanks! Anything I can get you?", Speaker = CreatureId.You},
    new DialogItem {
      Text = "Aw, bless your heart. I'll take any [color=#af3e48]soups[/color] ya got.", Speaker = CreatureId.Bonnie},
    new DialogItem {
      Text = "On my way!", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Milk], MealResponse);
      }
    }
];


  // Poe
  public static List<IDialogItem> Poe = [
  new DialogItem {
      Text = "I would like a—", Speaker = CreatureId.Poe},
    new DialogItem {
      Text = "(Huh? You don't?)", Speaker = CreatureId.Poe},
    new DialogItem {
      Text = "Okay, never mind. I'll get something else.", Speaker = CreatureId.Poe},
    new DialogItem {
      Text = "Um... who are you talking to?", Speaker = CreatureId.You},
    new DialogItem {
      Text = "You can't see them? I—", Speaker = CreatureId.Poe},
    new DialogItem {
      Text = "(What? Oh, sorry.)", Speaker = CreatureId.Poe},
 new DialogItem {
      Text = "Nobody at all. Could I get a [color=#277c2e]salad,[/color] please?", Speaker = CreatureId.Poe},
    new DialogItem {
      Text = "Uh, sure.", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Leaf], MealResponse);
      }
    }
];

  public static List<IDialogItem> Poe2 = [
  new DialogItem {
      Text = "Hi, I'd like to order—", Speaker = CreatureId.Poe},
    new DialogItem {
      Text = "(What? But I want… Oh, fine.)", Speaker = CreatureId.Poe},
    new DialogItem {
      Text = "One [color=#af3e48]tomato soup[/soup] please.", Speaker = CreatureId.Poe},
    new DialogItem {
      Text = "Are you sure? You seem torn.", Speaker = CreatureId.You},
    new DialogItem {
      Text = "Well, what I really wanted was—", Speaker = CreatureId.Poe},
    new DialogItem {
      Text = "(Huh? But she asked! Sigh…)", Speaker = CreatureId.Poe},
 new DialogItem {
      Text = "Yes. One [color=#af3e48]tomato soup[/soup].", Speaker = CreatureId.Poe},
    new DialogItem {
      Text = "I guess I'll get that for you...", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Milk, IngredientId.Tomato], MealResponse);
      }
    }
];


  // Speedy
  public static List<IDialogItem> Speedy = [
  new DialogItem {
      Text = "Gimme a flapjack! I gotta carbo-load!", Speaker = CreatureId.Speedy},
    new DialogItem {
      Text = "Any toppings in particular?", Speaker = CreatureId.You},
    new DialogItem {
      Text = "Throw whatever together! Just do it quickly!!", Speaker = CreatureId.Speedy},
    new DialogItem {
      Text = "Right away!", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Flour], MealResponse);
      }
    }
];


  // Lav
  public static List<IDialogItem> Lav = [
    new DialogItem {
      Text = "my horoscope today... said i should have something with [color=b74db8]nectar...[/color]", Speaker = CreatureId.Lav},
    new DialogItem {
      Text = "the stars... never lead us astray, you know...!", Speaker = CreatureId.Lav},
    new DialogItem {
      Text = "You sure that's not just your sweet tooth leading you, Lav?", Speaker = CreatureId.You},
    new DialogItem {
      Text = "who can say... besides the heavens...", Speaker = CreatureId.Speedy},
    new DialogItem {
      Text = "Whatever you say...", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Nectar], MealResponse);
      }
    }
];


  // Pip
  public static List<IDialogItem> Pip = [
  new DialogItem {
      Text = "Hnngggh… I can't make up my mind…!! (What do I tell her??)", Speaker = CreatureId.Pip},
    new DialogItem {
      Text = "It’s ok! Want me to come back later?", Speaker = CreatureId.You},
    new DialogItem {
      Text = "No, I think I'm ready, but—oh, wait... (this third thing looks so good)...!!", Speaker = CreatureId.Pip},
        new DialogItem {
      Text = "I'll give you a few more minutes.", Speaker = CreatureId.You},
    new DialogItem {
      Text = "No, hang on! I've changed my mind! I'll have...", Speaker = CreatureId.Pip},
    new DialogItem {
      Text = "...", Speaker = CreatureId.Pip},
    new DialogItem {
      Text = "...", Speaker = CreatureId.You},
    new DialogItem {
      Text = "...could you maybe pick something for me, please...?", Speaker = CreatureId.Pip},
    new DialogItem {
      Text = "S-sure.", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([], MealResponse);
      }
    }
];


  // Emily
  public static List<IDialogItem> Emily = [
  new DialogItem {
      Text = "Ahem.", Speaker = CreatureId.Emily},
    new DialogItem {
      Text = "Some golden victuals do desire I;\n'pon morel duty cook, perchance to cry", Speaker = CreatureId.Emily},
    new DialogItem {
      Text = "Uh... what did you mean by this?", Speaker = CreatureId.You},
        new DialogItem {
      Text = "Well, I never! Some philistines simply cannot appreciate poetry. An [color=#af973e]omelet of vegetable[/color], if you do so please.", Speaker = CreatureId.Emily},
    new DialogItem {
      Text = "Oh, sure. Coming right up!", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Egg, IngredientId.Onion, IngredientId.Mushroom], MealResponse);
      }
    }
];

  public static List<IDialogItem> Emily2 = [
    new DialogItem {
      Text = "Ah...", Speaker = CreatureId.Emily},
    new DialogItem {
      Text = "A hearty quaff should tickle and delight\nWith sav'riness distilled from shade of night.", Speaker = CreatureId.Emily},
    new DialogItem {
      Text = "Uh... what did you mean by this?", Speaker = CreatureId.You},
        new DialogItem {
      Text = "Unbelievable! Read a book—I beseech you. Please bring me [color=#af3e48]soup of richest tomato[/color], posthaste.", Speaker = CreatureId.Emily},
    new DialogItem {
      Text = "Oh, sure. Coming right up!", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Egg, IngredientId.Onion, IngredientId.Mushroom], MealResponse);
      }
    }
  ];

  public static List<IDialogItem> Emily3 = [
    new DialogItem {
      Text = "えーっと…", Speaker = CreatureId.Emily},
    new DialogItem {
      Text = "High-stacked prominence\nAn outer-seeded snowcap\nThe rain falls rosy", Speaker = CreatureId.Emily},
    new DialogItem {
      Text = "Uh... what did you mean by this?", Speaker = CreatureId.You},
        new DialogItem {
      Text = "Why, I find myself in high dudgeon at your continued illiteracy! A [color=#3e77af]strawberry flapjack[/color] is what I require at this time.", Speaker = CreatureId.Emily},
    new DialogItem {
      Text = "Oh, sure. Coming right up!", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Egg, IngredientId.Onion, IngredientId.Mushroom], MealResponse);
      }
    }
  ];

  // StuartS
  public static List<IDialogItem> StuartS = [
  new DialogItem {
      Text = "Mr. Squeakins, it’s nice to see you!", Speaker = CreatureId.You},
    new DialogItem {
      Text = "Lena! How've you been holding up, kiddo?", Speaker = CreatureId.Stuart},
    new DialogItem {
      Text = "Hanging in there. What can I get for you?", Speaker = CreatureId.You},
    new DialogItem {
      Text = "I’ll have a plate of [color=#3e77af]fluffjacks,[/color] if you can. Your mom’s recipe was a real winner.", Speaker = CreatureId.Emily},
    new DialogItem {
      Text = "Of course!", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Flour, IngredientId.Nectar, IngredientId.Egg, IngredientId.Milk], MealResponse);
      }
    }
];


  // MinnieS
  public static List<IDialogItem> MinnieS = [
  new DialogItem {
      Text = "Good morning, Ms. Minnie! I mean, Ms. Squeakins.", Speaker = CreatureId.You},
    new DialogItem {
      Text = "Ms. Minnie is fine, hahaha!", Speaker = CreatureId.MinnieS},
    new DialogItem {
      Text = "Most of my old students call me that, even the ones who aren't in elementary school anymore.", Speaker = CreatureId.MinnieS},
    new DialogItem {
      Text = "So embarrassing… anyway, can I get you anything?", Speaker = CreatureId.You},
    new DialogItem {
      Text = "I’d love a [color=#3e77af]Mega Salad![/color] Thanks, Lena.", Speaker = CreatureId.Emily},
    new DialogItem {
      Text = "Of course!", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Leaf, IngredientId.Turnip, IngredientId.Tomato], MealResponse);
      }
    }
];


  // CarrieS
  public static List<IDialogItem> CarrieS = [
  new DialogItem {
      Text = "Lena! Is that really you?", Speaker = CreatureId.CarrieS},
    new DialogItem {
      Text = "Hi Carrie! It’s been a while, huh.", Speaker = CreatureId.You},
    new DialogItem {
      Text = "You’ve gotten so big… I remember babysitting you when you were half that height.", Speaker = CreatureId.CarrieS},
    new DialogItem {
      Text = "Now I'm feeling all nostalgic... times like these call for some homemade [color=af3e48]soup![/color]", Speaker = CreatureId.CarrieS},
    new DialogItem {
      Text = "You got it!", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Milk], MealResponse);
      }
    }
];


  // Harry Squeakins
  public static List<IDialogItem> HarryS = [
  new DialogItem {
      Text = "'Sup, Lena'", Speaker = CreatureId.HarryS},
    new DialogItem {
      Text = "Hey, Harry! How's the band?", Speaker = CreatureId.You},
    new DialogItem {
      Text = "It's chill. The Asia leg of our world tour starts next week.", Speaker = CreatureId.HarryS},
    new DialogItem {
      Text = "What??", Speaker = CreatureId.You},
    new DialogItem {
      Text = "Can I get some [color=3e77af]blueberry flapjacks?[/color]", Speaker = CreatureId.HarryS},
    new DialogItem {
      Text = "Wait, WHAT??? The WHAT leg of your WHAT tour?????", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Milk], MealResponse);
      }
    }
];


  // Gary Squeakins
  public static List<IDialogItem> GaryS = [
    new DialogItem {
      Text = "Hey, Gary.", Speaker = CreatureId.You},
    new DialogItem {
      Text = "Hey, Lena. Been a long time since prom, huh.", Speaker = CreatureId.GaryS},
    new DialogItem {
      Text = "Yep.", Speaker = CreatureId.You},
   new DialogItem {
      Text = "...", Speaker = CreatureId.GaryS},
    new DialogItem {
      Text = "...", Speaker = CreatureId.You},
    new DialogItem {
      Text = "[color=277c2e]Salad?[/color]", Speaker = CreatureId.GaryS},
    new DialogItem {
      Text = "OK.", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Leaf], MealResponse);
      }
    }
];


  // Terry Squeakins
  public static List<IDialogItem> TerryS = [
    new DialogItem {
      Text = "Terry Squeakins, right?", Speaker = CreatureId.You},
    new DialogItem {
      Text = "H-hi.", Speaker = CreatureId.TerryS},
    new DialogItem {
      Text = "Can I get you something to eat?", Speaker = CreatureId.You},
   new DialogItem {
      Text = "...", Speaker = CreatureId.TerryS},
    new DialogItem {
      Text = "[color=3e77af]S-syrupy flapjack.[/color]", Speaker = CreatureId.TerryS},
    new DialogItem {
      Text = "Coming right up!", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Milk], MealResponse);
      }
    }
];


  // Sherry Squeakins
  public static List<IDialogItem> SherryS = [
    new DialogItem {
      Text = "You're... Merry Squeakins?", Speaker = CreatureId.You},
    new DialogItem {
      Text = "No, I'm Sherry!", Speaker = CreatureId.SherryS},
    new DialogItem {
      Text = "Merry's the one with the overbite and the bad fashion sense.", Speaker = CreatureId.SherryS},
   new DialogItem {
      Text = "Hey!!!", Speaker = CreatureId.MerryS},
    new DialogItem {
      Text = "Anyway, can I have a [af973e]lactose omelet?[/color]", Speaker = CreatureId.SherryS},
    new DialogItem {
      Text = "You got it!", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Egg, IngredientId.Milk, IngredientId.Cheese], MealResponse);
      }
    }
];


  // Merry Squeakins
  public static List<IDialogItem> MerryS = [
    new DialogItem {
      Text = "You must be... Sherry Squeakins?", Speaker = CreatureId.You},
    new DialogItem {
      Text = "No, I'm Merry!", Speaker = CreatureId.MerryS},
    new DialogItem {
      Text = "Sherry's the one with the underbite and the poor grades.", Speaker = CreatureId.MerryS},
   new DialogItem {
      Text = "I heard that!!!", Speaker = CreatureId.SherryS},
    new DialogItem {
      Text = "Anyway, can I have some [af3e48]bean soup?[/color]", Speaker = CreatureId.MerryS},
    new DialogItem {
      Text = "Sure!", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Milk, IngredientId.Bean], MealResponse);
      }
    }
];


  // Puff Squeakins
  public static List<IDialogItem> PuffS = [
    new DialogItem {
      Text = "Hewwo Wena! :3", Speaker = CreatureId.PuffS},
    new DialogItem {
      Text = "Hi Puff! What can I do for you today?", Speaker = CreatureId.You},
    new DialogItem {
      Text = "Um… One [af973e]omewet[/color] pwease! ^.^", Speaker = CreatureId.MerryS},
    new DialogItem {
      Text = "Sure!", Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Egg], MealResponse);
      }
    }
];




  // Example dialogue
  public static List<IDialogItem> Example = [
    new DialogItem {
      Text = "Anything with a [green]leaf[/color] would be great.",
      Speaker = CreatureId.MrChicken,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook();
      }
    },
  ];

  public static List<IDialogItem> MrChicken = new()
  {
    new DialogItem { Text = "Hello, I am [color=green]Mr. Chicken[/color].", Speaker = CreatureId.You },
    new DialogItem { Text = "I'm aware.", Speaker = CreatureId.You },
    new DialogOptions {
      Text = "Please, [color=gray]I beg you[/color]. I want a drink that reminds me of the sea.",
      Speaker = CreatureId.You,
      Options = new()
      {
        new DialogOption {
          OptionText = "[color=green]Start cooking[/color]",
          OnSelect = async (CreatureId creatureId) => {
            var result = await CookingScreen.Cook();

            await DialogBox.ShowDialog([
              new DialogItem { Text = $"I made you some {result.DisplayName}", Speaker = CreatureId.You} ,
              new DialogItem {
                Text = "Bad news, my friend.",
                Speaker = CreatureId.You,
                OverrideSpeakerName = "I HATE YOU",
              },
              new DialogItem {
                Text = "You see, I HATE YOUR STUPID MEAL.",
                Speaker = CreatureId.You,
                OnComplete = (CreatureId creatureId) => {
                  GameState.Gold -= 10;

                  GameState.CustomerResults.Add(new(
                    CreatureId: creatureId,
                    TipEarned: 0,
                    Satisfaction: CustomerSatisfaction.Angry,
                    DayIndex: GameState.DayIndex
                  ));

                  return Task.CompletedTask;
                }
              }],
              creatureId
            );


            return;
          }
        },

        new DialogOption {
          OptionText = "[color=yellow]Pay her 200g to get out of your hair.[/color]",
          IsAvailable = () => {
            return GameState.Gold > 200;
          },
          IsHidden = () => {
            return false;
          },
          OnSelect = async (CreatureId creatureId) => {
            GameState.Gold -= 200;

            await DialogBox.ShowDialog([
              new DialogItem { Text = "Thanks for the gold, ya loser.", Speaker = CreatureId.You},
              new DialogItem { Text = "...", Speaker = CreatureId.You},
              new DialogItem { Text = "Hehehehehe...............", Speaker = CreatureId.You},
            ], creatureId);
          },
        },

        new DialogOption {
          OptionText = "[color=red]I'm sorry, I can't do that[/color]",
          OnSelect = async (CreatureId creatureId) => {
            await DialogBox.ShowDialog([
              new DialogItem {
                Text = "I'm going to tell your mom on you",
                Speaker = CreatureId.You,
                OnComplete = async (CreatureId creatureId) => {
                  GameState.Gold += 10;
                }
              },
            ], creatureId);

            GameState.CustomerResults.Add(new(
              CreatureId: creatureId,
              TipEarned: 5,
              Satisfaction: CustomerSatisfaction.Upset,
              DayIndex: GameState.DayIndex
            ));

            return;
          }
        },
      }
    }
  };

  public static List<IDialogItem> MrsCow = new()
  {
    new DialogItem { Text = "Hello, I am Mrs. Cow", Speaker = CreatureId.You },
    new DialogItem { Text = "I'm exceedingly aware.", Speaker = CreatureId.You },
    new DialogOptions {
      Text = "Please, I beg you. I WANT MILK.",
      Speaker = CreatureId.You,
      Options = new()
      {
        new DialogOption {
          OptionText = "WTF. That seems... problematic.",
          IsAvailable = () => GameState.Gold > 10
        },
        new DialogOption { OptionText = "OK... whatever." }
      }
    }
  };

  // public static List<IDialogItem> MrBlegg = new()
  // {
  //   new DialogItem { Text = "Hello, I am [color=green]Mr. Blegg[/color].", Speaker = CreatureId.You },
  //   new DialogItem {
  //     Text = "Oh no. No. NO. NOT THE BLEGG.",
  //     Speaker = CreatureId.You,
  //     OnComplete = async (CreatureId creatureId) => {
  //      MrBlegg = MrBleggSecond;
  //     }
  //   }
  // };

  // public static List<IDialogItem> MrBleggSecond = new()
  // {
  //   new DialogItem { Text = "Hello, I am [color=green]Mr. Blegg[/color].", Speaker = CreatureId.You},
  //   new DialogItem { Text = "Not again. Please, no.", Speaker = CreatureId.You,
  //     OnComplete = async (CreatureId creatureId) => {
  //      MrBlegg = MrBleggSecond;
  //     }
  //   }
  // };

  public static List<IDialogItem> NoDialogYet = new()
  {
    new DialogItem { Text = "I don't have dialog yet.", Speaker = CreatureId.You },
  };

  public static List<IDialogItem> MrPig = new()
  {
    new DialogItem { Text = "Hello.", Speaker = CreatureId.You },
    new DialogItem { Text = "Hi.", Speaker = CreatureId.You },
    new DialogItem {
      Text = "Please make me some food.",
      Speaker = CreatureId.You,
      OnComplete = async (CreatureId creatureId) => {
        await CookingScreen.Cook();
      }
    },
  };

  public static List<IDialogItem> MrPigWithMouse = [
    new DialogItem {
      Text = "Mr. Mouse, you're late.",
      Speaker = CreatureId.You,
    },
    new DialogItem {
      Text = "...",
      Speaker = CreatureId.You,
    },
    new DialogItem {
      Text = "I'm sorry, I was held up by a [color=yellow]cat[/color].",
      Speaker = CreatureId.MrMouse,
    },
  ];

  public static List<IDialogItem> MrMouse = [
    new DialogItem { Text = "I don't have dialog yet.", Speaker = CreatureId.You}
  ];

  public static List<IDialogItem> MrHamster = [
    new DialogItem { Text = "I don't have dialog yet.", Speaker = CreatureId.You}
  ];

  public static List<IDialogItem> MrSquirrel = [
    new DialogItem { Text = "I don't have dialog yet.", Speaker = CreatureId.You}
  ];
}

// public static class SampleDialog {
//   public static List<IDialogItem> MrChicken = [
//     new DialogItem { Text = "Hello, I am [color=green]Mr. Chicken[/color].", Speaker = AllCreatures.MrChicken },
//     new DialogItem { Text = "I'm aware.", Speaker = AllCreatures.You },
//     new DialogOptions {
//       Text = "Please, [color=gray]I beg you[/color]. I want a drink that reminds me of the sea.",
//       Speaker = AllCreatures.MrChicken,
//       Options = [
//         new DialogOption {
//           OptionText = "[color=green]Start cooking[/color]",
//           OnSelect = async (CreatureData creature) => {
//             var result = await CookingScreen.Cook();

//             await DialogBox.ShowDialog([
//               new DialogItem { Text = $"I made you some {result.DisplayName}", Speaker = AllCreatures.You },
//               new DialogItem {
//                 Text = "Bad news, my friend.",
//                 Speaker = AllCreatures.MrChicken,
//                 OverrideSpeakerName = "I HATE YOU",
//               },
//               new DialogItem {
//                 Text = "You see, I HATE YOUR STUPID MEAL.",
//                 Speaker = AllCreatures.MrChicken,
//                 OnComplete = async (CreatureData creature) => {
//                   GameState.Gold -= 10;

//                   GameState.CustomerResults.Add(new(
//                     Creature: creature,
//                     TipEarned: 0,
//                     Satisfaction: CustomerSatisfaction.Angry,
//                     DayIndex: GameState.DayIndex
//                   ));
//                 }
//               },
//             ], creature);

//             return;
//           }
//         },

//         new DialogOption {
//           OptionText = "[color=yellow]Pay her 200g to get out of your hair.[/color]",
//           IsAvailable = () => {
//             return GameState.Gold > 200;
//           },
//           IsHidden = () => {
//             return false;
//           },
//           OnSelect = async (CreatureData creature) => {
//             GameState.Gold -= 200;

//             await DialogBox.ShowDialog([
//               new DialogItem { Text = "Thanks for the gold, ya loser.", Speaker = AllCreatures.MrChicken },
//               new DialogItem { Text = "...", Speaker = AllCreatures.You },
//               new DialogItem { Text = "Hehehehehe...............", Speaker = AllCreatures.MrChicken },
//             ], creature);
//           },
//         },

//         new DialogOption {
//           OptionText = "[color=red]I'm sorry, I can't do that[/color]",
//           OnSelect = async (CreatureData creature) => {
//             await DialogBox.ShowDialog([
//               new DialogItem {
//                 Text = "I'm going to tell your mom on you",
//                 Speaker = AllCreatures.MrChicken,
//                 OnComplete = async (CreatureData creature) => {
//                   GameState.Gold += 10;
//                 }
//               },
//             ], creature);

//             GameState.CustomerResults.Add(new(
//               Creature: creature,
//               TipEarned: 5,
//               Satisfaction: CustomerSatisfaction.Upset,
//               DayIndex: GameState.DayIndex
//             ));

//             return;
//           }
//         }
//       ]
//     },
//   ];

//   public static List<IDialogItem> MrsCow = [
//       new DialogItem { Text = "Hello, I am Mrs. Cow", Speaker = AllCreatures.MrsCow },
//       new DialogItem { Text = "I'm exceedingly aware.", Speaker = AllCreatures.You },
//       new DialogOptions {
//         Text = "Please, I beg you. I WANT MILK.",
//         Speaker = AllCreatures.MrsCow,
//         Options = [
//           new DialogOption {
//             OptionText = "WTF. That seems... problematic.",
//             IsAvailable = () => {
//               return GameState.Gold > 10;
//             }
//           },

//           new DialogOption { OptionText = "OK... whatever." }
//         ]
//       },
//   ];

//   public static List<IDialogItem> MrBlegg = [
//     new DialogItem { Text = "Hello, I am [color=green]Mr. Blegg[/color].", Speaker = AllCreatures.MrBlegg },
//     new DialogItem {
//       Text = "Oh no. No. NO. NOT THE BLEGG.",
//       Speaker = AllCreatures.You,
//       OnComplete = async (CreatureData creature) => {
//         MrBlegg = MrBleggSecond;
//       }
//     },
//   ];

//   public static List<IDialogItem> MrBleggSecond = [
//     new DialogItem { Text = "Hello, I am [color=green]Mr. Blegg[/color].", Speaker = AllCreatures.MrBlegg },
//     new DialogItem { Text = "Not again. Please, no.", Speaker = AllCreatures.You },
//   ];

//   public static List<IDialogItem> NoDialogYet = [
//     new DialogItem { Text = "I don't have dialog yet.", Speaker = AllCreatures.MrBlegg },
//   ];

//   public static List<IDialogItem> MrPig = [
//     new DialogItem { Text = "Hello.", Speaker = AllCreatures.MrPig },
//     new DialogItem { Text = "Hi.", Speaker = AllCreatures.You },
//     new DialogItem { Text = "Please make me some food.", Speaker = AllCreatures.You,
//       OnComplete = async (CreatureData creature) => {
//         await CookingScreen.Cook();
//       }
//     },
//   ];


//   public static List<IDialogItem> MrPigWithMouse = [
//     new DialogItem {
//       Text = "Mr. Mouse, you're late.",
//       Speaker = AllCreatures.MrPig,
//     },
//     new DialogItem {
//       Text = "...",
//       Speaker = AllCreatures.MrMouse,
//     },
//     new DialogItem {
//       Text = "I'm sorry, I was held up by a [color=yellow]cat[/color].",
//       Speaker = AllCreatures.MrMouse,
//     },
//   ];

//   public static List<IDialogItem> MrMouse = [
//     new DialogItem { Text = "I don't have dialog yet.", Speaker = AllCreatures.MrMouse },
//   ];

//   public static List<IDialogItem> MrHamster = [
//     new DialogItem { Text = "I don't have dialog yet.", Speaker = AllCreatures.MrHamster },
//   ];

//   public static List<IDialogItem> MrSquirrel = [
//     new DialogItem { Text = "I don't have dialog yet.", Speaker = AllCreatures.MrSquirrel },
//   ];
// }
public static class NextDialog {
  private static Dictionary<CreatureId, List<IDialogItem>> _dialogMap = new() {
    [CreatureId.You] = new()
  };

  public static List<IDialogItem> GetDialogForCreature(CreatureId creatureId) {
    if (_dialogMap.TryGetValue(creatureId, out var dialog)) {
      return dialog;
    }
    return AllDialog.NoDialogYet;
  }

  public static void SetDialogForCreature(CreatureId creatureId, List<IDialogItem> dialog) {
    _dialogMap[creatureId] = dialog;
  }
}
