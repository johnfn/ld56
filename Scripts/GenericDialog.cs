using Godot;
using System;

public partial class GenericDialog : PanelContainer {
  public static GenericDialog Instance;

  public override void _Ready() {
    Instance = this;

    Visible = false;

    Nodes.MarginContainer_VBoxContainer_Button.Pressed += () => {
      Visible = false;
    };
  }

  public void Show(string content) {
    Nodes.MarginContainer_VBoxContainer_Label.Text = content;
    Visible = true;
  }
}
