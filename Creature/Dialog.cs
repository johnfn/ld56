using System;
using System.Collections.Generic;

namespace ld56;

public interface IDialogComponent { }

public struct DialogReward : IDialogComponent {
  public string Text { get; set; }
  public Action<bool> GetReward { get; set; }
}

public struct DialogItem : IDialogComponent {
  public string Text { get; set; }
  public string Speaker { get; set; }
}

public struct DialogOption {
  public string OptionText { get; set; }
  public Func<bool>? IsAvailable { get; set; }
}

public struct DialogOptions : IDialogComponent {
  public List<DialogOption> Options { get; set; }
}

public struct Dialog {
  public List<IDialogComponent> Items { get; set; }
}

public static class AllDialog {
  public static Dialog MrChicken = new Dialog {
    Items = [
      new DialogItem { Text = "Hello, I am Mr. Chicken", Speaker = "Mr. Chicken" },
      new DialogItem { Text = "I'm aware.", Speaker = "You" },
      new DialogItem { Text = "Please, I beg you. I want a drink that reminds me of the sea.", Speaker = "Mr. Chicken" },
      new DialogOptions {
        Options = [
          new DialogOption {
            OptionText = "Use the special sea salt your mom made you?",
            IsAvailable = () => {
              return false;
            }
          },
          new DialogOption { OptionText = "I'm sorry, I can't do that" }
        ]
      },
    ],
  };

  public static Dialog MrsCow = new Dialog {
    Items = [
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
    ],
  };

}

