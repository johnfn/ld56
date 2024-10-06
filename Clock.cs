using Godot;
using System;

namespace ld56;

public partial class Clock : TextureRect {

  private float _startRotation = Mathf.DegToRad(-127f);
  private float _endRotation = Mathf.DegToRad(52f);

  public override void _Ready() {
    var timeLabel = Nodes.TimeLabelContainer;
    timeLabel.Visible = false;

    MouseEntered += () => timeLabel.Visible = true;
    MouseExited += () => timeLabel.Visible = false;

    Reset();
  }

  public void Reset() {
    Nodes.ClockHand.Rotation = _startRotation;
  }

  public override void _Process(double delta) {
    var currentTime = Root.Instance.CurrentDayTime;
    var endOfDayTime = Root.Instance.EndOfDayTime;

    // Convert currentTime to a clock hand rotation, between -127 (start of day) and 52 (end of day)
    var clockHandRotation = Mathf.Lerp(_startRotation, _endRotation, (float)(currentTime / endOfDayTime));
    Nodes.ClockHand.Rotation = clockHandRotation;

    // Update time label
    // start of day is 8:00 AM
    // end of day is 10:00 PM

    var startHour = 8; // 8:00 AM
    var endHour = 22; // 10:00 PM

    var totalMinutes = (currentTime / endOfDayTime) * ((endHour - startHour) * 60);
    var hours = startHour + (int)(totalMinutes / 60);
    var minutes = (int)(totalMinutes % 60);

    var period = hours >= 12 ? "PM" : "AM";
    if (hours > 12) hours -= 12;
    if (hours == 0) hours = 12;

    var timeString = $"{hours}:{minutes:D2}";

    Nodes.TimeLabelContainer_HBoxContainer_TimeLabel.Text = timeString;
    Nodes.TimeLabelContainer_HBoxContainer_AMPMLabel.Text = period;
  }
}
