using System;
using System.Collections.Generic;

namespace ld56;

public interface IDialogItem { }

public struct DialogReward : IDialogItem {
  public string Text { get; set; }
  public Action<bool> GetReward { get; set; }
}

public struct DialogBeginCooking : IDialogItem {
}

public struct DialogItem : IDialogItem {
  public string Text { get; set; }
  public string Speaker { get; set; }
}

public struct DialogOption {
  public string OptionText { get; set; }
  public Func<bool>? IsAvailable { get; set; }
  public Func<List<IDialogItem>>? OnSelect { get; set; }
}

public struct DialogOptions : IDialogItem {
  public List<DialogOption> Options { get; set; }
}

public static class AllDialog {
  public static List<IDialogItem> MrChicken = [
    new DialogItem { Text = "Hello, I am [color=green]Mr. Chicken[/color].", Speaker = "Mr. Chicken" },
    new DialogItem { Text = "I'm aware.", Speaker = "You" },
    new DialogItem { Text = "Please, [color=gray]I beg you[/color]. I want a drink that reminds me of the sea.", Speaker = "Mr. Chicken" },
    new DialogOptions {
      Options = [
        new DialogOption {
          OptionText = "[color=green]Start cooking[/color]",
          OnSelect = () => {
            return [
              new DialogBeginCooking(),
            ];
          }
        },
        new DialogOption {
          OptionText = "[color=red]I'm sorry, I can't do that[/color]",
          OnSelect = () => {
            return [
              new DialogItem { Text = "I'm going to tell your mom on you", Speaker = "Mr. Chicken" },
            ];
          }
        }
      ]
    },
  ];

  public static List<IDialogItem> MrsCow = [
      new DialogItem { Text = "Hello, I am Mrs. Cow", Speaker = "Mrs. Cow" },
      new DialogItem { Text = "I'm exceedingly aware.", Speaker = "You" },
      new DialogItem { Text = "Please, I beg you. I WANT MILK.", Speaker = "Mrs. Cow" },
      new DialogOptions {
        Options = [
          new DialogOption {
            OptionText = "WTF. That seems... problematic.",
            IsAvailable = () => {
              return false;
            }
          },
          new DialogOption { OptionText = "OK... whatever." }
        ]
      },
  ];
}

