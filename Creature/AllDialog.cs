using System.Collections.Generic;
using System.Linq;

namespace ld56;

public static class AllDialog {

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
      Text = "…can I take your order?", Speaker = CreatureId.None},
    new DialogItem {
      Text = "The name’s Detective Tom Shortcoat.", Speaker = CreatureId.Tom},
    new DialogItem {
      Text = "My friends call me Tom. My enemies call me Shortcoat.", Speaker = CreatureId.Tom},
    new DialogItem {
      Text = "Any my lovers, well, that’s not something I ought to discuss in polite company.", Speaker = CreatureId.Tom},
    new DialogItem {
      Text = "Um. Can I take your order, Detective Shortcoat?", Speaker = CreatureId.None},
    new DialogItem {
      Text = "The dame had powder-blue eyes that grew as big as dinner plates when she saw me walk through the door.", Speaker = CreatureId.Tom},
    new DialogItem {
      Text = "The apron looked well enough on her, but they tell stories about beautiful blondes with million-dollar smiles,", Speaker = CreatureId.Tom},
    new DialogItem {
      Text = "and let’s just say her smile could maybe buy a cup of coffee if you lent her a couple bucks.", Speaker = CreatureId.Tom},
    new DialogItem {
      Text = "Excuse me???", Speaker = CreatureId.None},
    new DialogItem {
      Text = "All my nutrition lately had come from whiskey and cigarette smoke, I mused,", Speaker = CreatureId.Tom},
    new DialogItem {
      Text = "so I reulctantly ordered a [color=af973e]veggie omelet.[/color]", Speaker = CreatureId.Tom},
    new DialogItem {
      Text = "...coming right up...", Speaker = CreatureId.None,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Egg, IngredientId.Onion, IngredientId.Mushroom]);
      },
    }
  ];


  // Hazel
  public static List<IDialogItem> Hazel = [
    new DialogItem {
      Text = "Hi~ How's it going~", Speaker = CreatureId.Hazel},
    new DialogItem {
      Text = "Doing great, and you?", Speaker = CreatureId.None},
    new DialogItem {
      Text = "Couldn't be better~", Speaker = CreatureId.Hazel},
    new DialogItem {
      Text = "May I have an [color=af3e48]onion soup[/color] please~", Speaker = CreatureId.Hazel},
    new DialogItem {
      Text = "Absolutely!", Speaker = CreatureId.None,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Milk, IngredientId.Onion]);
      }
    }
  ];


  // Chip
  public static List<IDialogItem> Chip = [
  new DialogItem {
      Text = "Whoa, Chip! You look banged up.", Speaker = CreatureId.None},
    new DialogItem {
      Text = "All good, Lena. Can’t learn to skateboard without cracking a few eggs!", Speaker = CreatureId.Chip},
    new DialogItem {
      Text = "And you know what? That sounds pretty good. Can you get me anything with [color=af973e]egg[/color], please?", Speaker = CreatureId.Chip},
    new DialogItem {
      Text = "Coming right up!", Speaker = CreatureId.None,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Egg]);
      }
    }
];


  // Kero
  public static List<IDialogItem> Kero = [
  new DialogItem {
      Text = "Hi Kero! Looking good today!", Speaker = CreatureId.None},
    new DialogItem {
      Text = "Thanks, Lena. It’s all thanks to this new diet.", Speaker = CreatureId.Kero},
    new DialogItem {
      Text = "And speaking of… I’ll have anything with [color=277c2e]leaf[/color], please.", Speaker = CreatureId.Kero},
    new DialogItem {
      Text = "Coming right up!", Speaker = CreatureId.None,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Leaf]);
      }
    }
];


  // Rufus
  public static List<IDialogItem> Rufus = [
  new DialogItem {
      Text = "So hungry… I would love something [color=8d3eaf]aromantic.[/color]", Speaker = CreatureId.Rufus},
    new DialogItem {
      Text = "Did you mean [color=8d3eaf]aromatic?[/color]", Speaker = CreatureId.None},
    new DialogItem {
      Text = "?? No.", Speaker = CreatureId.Rufus},
    new DialogItem {
      Text = "Oh. Coming right up, I guess?", Speaker = CreatureId.None,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Leaf]);
      }
    }
];


  // Bonnie
  public static List<IDialogItem> Bonnie = [
  new DialogItem {
      Text = "Howdy, miss.", Speaker = CreatureId.Bonnie},
    new DialogItem {
      Text = "Howdy!", Speaker = CreatureId.None},
    new DialogItem {
      Text = "This here’s a mighty fine B&B, I reckon. I’ve got a hankerin’ fer some [color=3e77af]flapjacks[/color]. Anything you can do fer ol’ Bonnie?", Speaker = CreatureId.Bonnie},
    new DialogItem {
      Text = "Why, of course!", Speaker = CreatureId.None,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Flour]);
      }
    }
];


  // Poe
  public static List<IDialogItem> Poe = [
  new DialogItem {
      Text = "I would like a—", Speaker = CreatureId.Poe},
    new DialogItem {
      Text = "(Huh? You don’t?)", Speaker = CreatureId.Poe},
    new DialogItem {
      Text = "Okay, never mind. I’ll get something else.", Speaker = CreatureId.Poe},
    new DialogItem {
      Text = "Um... who are you talking to?", Speaker = CreatureId.None},
    new DialogItem {
      Text = "You can’t see them? I—", Speaker = CreatureId.Poe},
    new DialogItem {
      Text = "(What? Oh, sorry.)", Speaker = CreatureId.Poe},
 new DialogItem {
      Text = "Nobody at all. Could I get a [color=277c2e]salad,[/color] please?", Speaker = CreatureId.Poe},
    new DialogItem {
      Text = "Uh, sure.", Speaker = CreatureId.None,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Leaf]);
      }
    }
];


  // Speedy
  public static List<IDialogItem> Speedy = [
  new DialogItem {
      Text = "Gimme any flapjack! I gotta carbo-load!", Speaker = CreatureId.Speedy},
    new DialogItem {
      Text = "Any toppings in particular?", Speaker = CreatureId.None},
    new DialogItem {
      Text = "Throw whatever together! Just do it quickly!!", Speaker = CreatureId.Speedy},
    new DialogItem {
      Text = "Right away!", Speaker = CreatureId.None,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Flour]);
      }
    }
];


  // Pip
  public static List<IDialogItem> Pip = [
  new DialogItem {
      Text = "Hnngggh… I can’t make up my mind…!! (What do I tell her??)", Speaker = CreatureId.Pip},
    new DialogItem {
      Text = "It’s ok! Want me to come back later?", Speaker = CreatureId.None},
    new DialogItem {
      Text = "No, I think I'm ready, but—oh, wait... (this third thing looks so good)...!!", Speaker = CreatureId.Pip},
        new DialogItem {
      Text = "I'll give you a few more minutes.", Speaker = CreatureId.None},
    new DialogItem {
      Text = "No, wait! I've changed my mind! I'll have...", Speaker = CreatureId.Pip},
    new DialogItem {
      Text = "...", Speaker = CreatureId.Pip},
    new DialogItem {
      Text = "...", Speaker = CreatureId.None},
    new DialogItem {
      Text = "...could you maybe pick something for me, please...?", Speaker = CreatureId.Pip},
    new DialogItem {
      Text = "S-sure.", Speaker = CreatureId.None,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook();
      }
    }
];


// Emily
    public static List<IDialogItem> Emily = [
    new DialogItem {
      Text = "Ahem.", Speaker = CreatureId.Emily},   
    new DialogItem {
      Text = "Some golden victuals do desire I;\n‘pon morel duty cook, perchance to cry", Speaker = CreatureId.Emily},
    new DialogItem {
      Text = "Uh... what did you mean by this?", Speaker = CreatureId.None},   
        new DialogItem {
      Text = "Well, I never! Some philistines simply cannot appreciate poetry. An omelet of vegetable, if you do so please.", Speaker = CreatureId.Emily},
    new DialogItem {
      Text = "Oh, sure. Coming right up!", Speaker = CreatureId.None,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook([IngredientId.Egg, IngredientId.Onion, IngredientId.Mushroom]);
      }
    }
  ];





  // Example dialogue
  public static List<IDialogItem> Example = [
    new DialogItem {
      Text = "Anything with a [color=green]leaf[/color] would be great.",
      Speaker = CreatureId.MrChicken,
      OnComplete = async (CreatureId creatureId) => {
        var recipe = await CookingScreen.Cook();
      }
    },
  ];

  public static List<IDialogItem> MrChicken = new()
  {
    new DialogItem { Text = "Hello, I am [color=green]Mr. Chicken[/color].", Speaker = CreatureId.None },
    new DialogItem { Text = "I'm aware.", Speaker = CreatureId.None },
    new DialogOptions {
      Text = "Please, [color=gray]I beg you[/color]. I want a drink that reminds me of the sea.",
      Speaker = CreatureId.None,
      Options = new()
      {
        new DialogOption {
          OptionText = "[color=green]Start cooking[/color]",
          OnSelect = async (CreatureId creatureId) => {
            var result = await CookingScreen.Cook();

            await DialogBox.ShowDialog([
              new DialogItem { Text = $"I made you some {result.DisplayName}", Speaker = CreatureId.None} ,
              new DialogItem {
                Text = "Bad news, my friend.",
                Speaker = CreatureId.None,
                OverrideSpeakerName = "I HATE YOU",
              },
              new DialogItem {
                Text = "You see, I HATE YOUR STUPID MEAL.",
                Speaker = CreatureId.None,
                OnComplete = async (CreatureId creatureId) => {
                  GameState.Gold -= 10;

                  GameState.CustomerResults.Add(new(
                    CreatureId: creatureId,
                    TipEarned: 0,
                    Satisfaction: CustomerSatisfaction.Angry,
                    DayIndex: GameState.DayIndex
                  ));
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
              new DialogItem { Text = "Thanks for the gold, ya loser.", Speaker = CreatureId.None},
              new DialogItem { Text = "...", Speaker = CreatureId.None},
              new DialogItem { Text = "Hehehehehe...............", Speaker = CreatureId.None},
            ], creatureId);
          },
        },

        new DialogOption {
          OptionText = "[color=red]I'm sorry, I can't do that[/color]",
          OnSelect = async (CreatureId creatureId) => {
            await DialogBox.ShowDialog([
              new DialogItem {
                Text = "I'm going to tell your mom on you",
                Speaker = CreatureId.None,
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
    new DialogItem { Text = "Hello, I am Mrs. Cow", Speaker = CreatureId.None },
    new DialogItem { Text = "I'm exceedingly aware.", Speaker = CreatureId.None },
    new DialogOptions {
      Text = "Please, I beg you. I WANT MILK.",
      Speaker = CreatureId.None,
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

  public static List<IDialogItem> MrBlegg = new()
  {
    new DialogItem { Text = "Hello, I am [color=green]Mr. Blegg[/color].", Speaker = CreatureId.None },
    new DialogItem {
      Text = "Oh no. No. NO. NOT THE BLEGG.",
      Speaker = CreatureId.None,
      OnComplete = async (CreatureId creatureId) => {
       MrBlegg = MrBleggSecond;
      }
    }
  };

  public static List<IDialogItem> MrBleggSecond = new()
  {
    new DialogItem { Text = "Hello, I am [color=green]Mr. Blegg[/color].", Speaker = CreatureId.None},
    new DialogItem { Text = "Not again. Please, no.", Speaker = CreatureId.None,
      OnComplete = async (CreatureId creatureId) => {
       MrBlegg = MrBleggSecond;
      }


    }
  };

  public static List<IDialogItem> NoDialogYet = new()
  {
    new DialogItem { Text = "I don't have dialog yet.", Speaker = CreatureId.None },
  };

  public static List<IDialogItem> MrPig = new()
  {
    new DialogItem { Text = "Hello.", Speaker = CreatureId.None },
    new DialogItem { Text = "Hi.", Speaker = CreatureId.None },
    new DialogItem {
      Text = "Please make me some food.",
      Speaker = CreatureId.None,
      OnComplete = async (CreatureId creatureId) => {
        await CookingScreen.Cook();
      }
    },
  };


  public static List<IDialogItem> MrPigWithMouse = [
    new DialogItem {
      Text = "Mr. Mouse, you're late.",
      Speaker = CreatureId.None,
    },
    new DialogItem {
      Text = "...",
      Speaker = CreatureId.None,
    },
    new DialogItem {
      Text = "I'm sorry, I was held up by a [color=yellow]cat[/color].",
      Speaker = CreatureId.MrMouse,
    },
  ];

  public static List<IDialogItem> MrMouse = [
    new DialogItem { Text = "I don't have dialog yet.", Speaker = CreatureId.None}
  ];

  public static List<IDialogItem> MrHamster = [
    new DialogItem { Text = "I don't have dialog yet.", Speaker = CreatureId.None}
  ];

  public static List<IDialogItem> MrSquirrel = [
    new DialogItem { Text = "I don't have dialog yet.", Speaker = CreatureId.None}
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
    [CreatureId.None] = new()
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
