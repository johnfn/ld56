namespace ld56;

public static class GameConstants {
  public static int WALKING_SPEED {
    get {
      return GameState.HYPERSPEED ? 2000 : 500;
    }
  }
}
