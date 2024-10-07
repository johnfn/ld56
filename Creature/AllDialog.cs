using System.Collections.Generic;

namespace ld56;

public static class AllDialog {
  public static List<IDialogItem> Hazel = [
    // new DialogItem {
    //   Text = "Hello, I am [color=green]Hazel[/color].",
    //   Speaker = AllCreatures.Hazel,
    // },
    // new DialogItem {
    //   Text = "Ugh, I'm so hungry...",
    //   Speaker = AllCreatures.Hazel,
    // },
    // new DialogItem {
    //   Text = "Can you fix me something [color=green]healthy[/color]?",
    //   Speaker = AllCreatures.Hazel,
    // },
    new DialogItem {
      Text = "Anything with a [color=green]leaf[/color] would be great.",
      Speaker = AllCreatures.Hazel,
      OnComplete = async (CreatureData creature) => {
        await CookingScreen.Cook();
      }
    },
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
