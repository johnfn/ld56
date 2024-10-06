using System.Collections.Generic;

namespace ld56;

public static class AllDialog {
  public static List<IDialogItem> MrChicken = [
    new DialogItem { Text = "Hello, I am [color=green]Mr. Chicken[/color].", Speaker = "Mr. Chicken" },
    new DialogItem { Text = "I'm aware.", Speaker = "You" },
    new DialogOptions {
      Text = "Please, [color=gray]I beg you[/color]. I want a drink that reminds me of the sea.",
      Speaker = "Mr. Chicken",
      Options = [
        new DialogOption {
          OptionText = "[color=green]Start cooking[/color]",
          OnSelect = async (Creature creature) => {
            var result = await CookingScreen.Cook();

            await DialogBox.ShowDialog([
              new DialogItem { Text = $"I made you some {result.DisplayName}", Speaker = "You" },
              new DialogItem { Text = "Bad news, my friend.", Speaker = "Mr. Chicken" },
              new DialogItem {
                Text = "You see, I HATE YOUR STUPID MEAL.",
                Speaker = "Mr. Chicken",
                GetReward = () => {
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
          OnSelect = async (Creature creature) => {
            GameState.Gold -= 200;

            await DialogBox.ShowDialog([
              new DialogItem { Text = "Thanks for the gold, ya loser.", Speaker = "Mr. Chicken" },
              new DialogItem { Text = "...", Speaker = "You" },
              new DialogItem { Text = "Hehehehehe...............", Speaker = "Mr. Chicken" },
            ], creature);
          },
        },

        new DialogOption {
          OptionText = "[color=red]I'm sorry, I can't do that[/color]",
          OnSelect = async (Creature creature) => {
            await DialogBox.ShowDialog([
              new DialogItem {
                Text = "I'm going to tell your mom on you",
                Speaker = "Mr. Chicken",
                GetReward = () => {
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
      new DialogItem { Text = "Hello, I am Mrs. Cow", Speaker = "Mrs. Cow" },
      new DialogItem { Text = "I'm exceedingly aware.", Speaker = "You" },
      new DialogOptions {
        Text = "Please, I beg you. I WANT MILK.",
        Speaker = "Mrs. Cow",
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
}

