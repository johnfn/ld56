using System.Collections.Generic;

namespace ld56;

public static class AllDialog {
  public static List<IDialogItem> MrChicken = [
    new DialogItem { Text = "Hello, I am [color=green]Mr. Chicken[/color].", Speaker = AllCreatures.MrChicken },
    new DialogItem { Text = "I'm aware.", Speaker = AllCreatures.You },
    new DialogOptions {
      Text = "Please, [color=gray]I beg you[/color]. I want a drink that reminds me of the sea.",
      Speaker = AllCreatures.MrChicken,
      Options = [
        new DialogOption {
          OptionText = "[color=green]Start cooking[/color]",
          OnSelect = async (Creature creature) => {
            var result = await CookingScreen.Cook();

            await DialogBox.ShowDialog([
              new DialogItem { Text = $"I made you some {result.DisplayName}", Speaker = AllCreatures.You },
              new DialogItem {
                Text = "Bad news, my friend.",
                Speaker = AllCreatures.MrChicken,
                OverrideSpeakerName = "I HATE YOU",
              },
              new DialogItem {
                Text = "You see, I HATE YOUR STUPID MEAL.",
                Speaker = AllCreatures.MrChicken,
                OnComplete = () => {
                  GameState.Gold -= 10;

                  GameState.CustomerResults.Add(new(
                    Creature: creature,
                    TipEarned: 0,
                    Satisfaction: CustomerSatisfaction.Angry,
                    DayIndex: GameState.DayIndex
                  ));
                }
              },
            ], creature);

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
          OnSelect = async (Creature creature) => {
            GameState.Gold -= 200;

            await DialogBox.ShowDialog([
              new DialogItem { Text = "Thanks for the gold, ya loser.", Speaker = AllCreatures.MrChicken },
              new DialogItem { Text = "...", Speaker = AllCreatures.You },
              new DialogItem { Text = "Hehehehehe...............", Speaker = AllCreatures.MrChicken },
            ], creature);
          },
        },

        new DialogOption {
          OptionText = "[color=red]I'm sorry, I can't do that[/color]",
          OnSelect = async (Creature creature) => {
            await DialogBox.ShowDialog([
              new DialogItem {
                Text = "I'm going to tell your mom on you",
                Speaker = AllCreatures.MrChicken,
                OnComplete = () => {
                  GameState.Gold += 10;
                }
              },
            ], creature);

            GameState.CustomerResults.Add(new(
              Creature: creature,
              TipEarned: 5,
              Satisfaction: CustomerSatisfaction.Upset,
              DayIndex: GameState.DayIndex
            ));

            return;
          }
        }
      ]
    },
  ];

  public static List<IDialogItem> MrsCow = [
      new DialogItem { Text = "Hello, I am Mrs. Cow", Speaker = AllCreatures.MrsCow },
      new DialogItem { Text = "I'm exceedingly aware.", Speaker = AllCreatures.You },
      new DialogOptions {
        Text = "Please, I beg you. I WANT MILK.",
        Speaker = AllCreatures.MrsCow,
        Options = [
          new DialogOption {
            OptionText = "WTF. That seems... problematic.",
            IsAvailable = () => {
              return GameState.Gold > 10;
            }
          },

          new DialogOption { OptionText = "OK... whatever." }
        ]
      },
  ];

  public static List<IDialogItem> MrBleggFirst = [
    new DialogItem { Text = "Hello, I am [color=green]Mr. Blegg[/color].", Speaker = AllCreatures.MrBlegg },
    new DialogItem {
      Text = "Oh no. No. NO. NOT THE BLEGG.",
      Speaker = AllCreatures.You,
      OnComplete = () => {
        NextDialog.For[AllCreatures.MrBlegg] = MrBleggSecond;
      }
    },
  ];

  public static List<IDialogItem> MrBleggSecond = [
    new DialogItem { Text = "Hello, I am [color=green]Mr. Blegg[/color].", Speaker = AllCreatures.MrBlegg },
    new DialogItem { Text = "Not again. Please, no.", Speaker = AllCreatures.You },
  ];

  public static List<IDialogItem> NoDialogYet = [
    new DialogItem { Text = "I don't have dialog yet.", Speaker = AllCreatures.MrBlegg },
  ];
}


public static class NextDialog {
  public static Dictionary<Creature, List<IDialogItem>> For = new() {
    [AllCreatures.MrChicken] = AllDialog.MrChicken,
    [AllCreatures.MrsCow] = AllDialog.MrsCow,
    [AllCreatures.MrBlegg] = AllDialog.MrBleggFirst,

    [AllCreatures.MrPig] = AllDialog.NoDialogYet,
    [AllCreatures.MrHamster] = AllDialog.NoDialogYet,
    [AllCreatures.MrMouse] = AllDialog.NoDialogYet,
    [AllCreatures.MrSquirrel] = AllDialog.NoDialogYet,
  };
}
