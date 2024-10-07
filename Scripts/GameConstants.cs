namespace ld56;

public static class GameConstants {
  public static int WALKING_SPEED {
    get {
      return GameState.HYPERSPEED ? 2000 : 500;
    }
  }
  public static float EndOfDayTime = 10.0f;
}
